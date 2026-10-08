using MediatR;
using Nexus.Application.DTO;
using Nexus.Application.Interface.Helper;
using Nexus.Application.Interface.Persistence;
using Nexus.Application.Interface.Repository;
using Nexus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Application.Features.AddTime
{
    public class TimeHandler : IRequestHandler<TimeCommand, GenericResponseDTO<TimeResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPcSessionRepository _pcSessionRepo;
        private readonly IClientPCRepository _clienPcRepo;
        private readonly ICustomerTimeRepository _customerTimeRepo;
        private readonly IPointTransactionRepository _pointTransactionRepo;
        private readonly ITimeTransactionRepository _timeTransactionRepo;
        private readonly IRateRepository _rateRepo;

        public TimeHandler(IUnitOfWork unitOfWork, IPcSessionRepository pcSessionRepo, IClientPCRepository clientPcRepo, ICustomerTimeRepository customerTimeRepo, IPointTransactionRepository pointTransactionRepo, ITimeTransactionRepository timeTransactionRepo, IRateRepository rateRepo)
        {
            _unitOfWork = unitOfWork;
            _pcSessionRepo = pcSessionRepo;
            _clienPcRepo = clientPcRepo;
            _customerTimeRepo = customerTimeRepo;
            _pointTransactionRepo = pointTransactionRepo;
            _timeTransactionRepo = timeTransactionRepo;
            _rateRepo = rateRepo; 
        }

        public async Task<GenericResponseDTO<string>> Handle(TimeCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                
                
                var clientpc = await _clienPcRepo.getClientPCByIdAsync(request.PCId);
                if(clientpc == null)
                {
                    return new GenericResponseDTO<string>
                    {
                        isSuccess = false,
                        message = "Client pc not found"
                    };
                }

                var result = await TimePointCalculator(request.AmountInserted, clientpc.isVip);


                var pcSession = new PCSession(request.CustomerId, request.PCId, result.time);
                await _pcSessionRepo.CreatePcSessionAsync(pcSession);


                var pointTransaction = new PointTransactions(request.CustomerId, result.point, "Earn", $"Earn-From-{pcSession.SessionId}", "Earn");
                await _pointTransactionRepo.CreatePointAsync(pointTransaction);

                var customer = await _customerTimeRepo.GetCustomerTimeByCustomerIdAsync(request.CustomerId);
                if (customer == null)
                {
                    return new GenericResponseDTO<TimeResponseDTO>
                    {
                        isSuccess = false,
                        message = "Customer time not found",
                        Data 

                    };
                }

                var timeTransaction = new TimeTransactions(request.CustomerId, result.time, customer.AvailableSeconds >= 0 ? "Purchase" : "AddTime", "");
                await _timeTransactionRepo.CreateTimeTransactionAsync(timeTransaction);

                customer.UpdateCustomerTime(result.time);

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                decimal overallPoints;


                return new GenericResponseDTO<TimeResponseDTO>
                {
                    isSuccess = true,
                    message = "Time recorded successfully."
                };



            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new GenericResponseDTO<int>
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }
        }

        private decimal PointCalculator(int time)
        {
            return time;
        }

        private async Task<(int time, decimal point)> TimePointCalculator(int amount, bool isVip)
        {
            var rates = await _rateRepo.GetRatesByStatusAsync(isVip);
            if (rates == null || !rates.Any())
                throw new Exception("No rates configured.");

            if (amount <= 0)
                throw new Exception("Amount must be greated than zero");

            var remainingAmount = amount;
            var totalSeconds = 0;
            decimal totalPoints = 0;

            var orderedRates = rates.OrderByDescending(x => x.Credit).ToList();
            
            foreach(var rate in orderedRates)
            {
                var quantity = remainingAmount / rate.Credit;
                if (quantity <= 0)
                    continue;

                totalSeconds += quantity + rate.Time;
                totalPoints += quantity * rate.Time;
                remainingAmount %= rate.Credit;
            }

            return (totalSeconds, totalPoints);

        }
    }
}
