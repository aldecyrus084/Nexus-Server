using MediatR;
using Nexus.Application.DTO;
using Nexus.Application.Interface;
using Nexus.Application.Interface.Persistence;
using Nexus.Application.Interface.Repository;
using Nexus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Application.Features.Customer.Create
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, GenericResponseDTO<CustomerResponseDTO>>
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        public CreateCustomerHandler(ICustomerRepository customerRepo, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _customerRepo = customerRepo;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }
        public async Task<GenericResponseDTO<CustomerResponseDTO>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var hashPassword = _passwordHasher.HashPassword(request.Password);
                var customer = new Customers(request.Name, request.Username, hashPassword, request.IpAddress);
                await _customerRepo.CreateCustomerAsync(customer);

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                return new GenericResponseDTO<CustomerResponseDTO>
                {
                    isSuccess = true,
                    message = "Customer added successfully.",
                    Data = new CustomerResponseDTO
                    {
                        CustomerId = customer.CustomerId,
                        Name = customer.Name,
                        Username = customer.Username,
                        isActive = customer.isActive,
                        IpAddress = customer.IpAddress
                    }
                };

            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new GenericResponseDTO<CustomerResponseDTO>
                {
                    isSuccess = false,
                    message = ex.Message,
                };
            }
        }
    }
}
