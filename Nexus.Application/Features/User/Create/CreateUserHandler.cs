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

namespace Nexus.Application.Features.User.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, GenericResponseDTO<UserResponseDTO>>
    {
        private readonly IUserRepository _userRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _hasher;

        public CreateUserHandler(IUserRepository userRepo, IUnitOfWork unitOfWork, IPasswordHasher hasher)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
            _hasher = hasher;
        }
        public async Task<GenericResponseDTO<UserResponseDTO>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var hashPassword = _hasher.HashPassword(request.Password);
                var user = new Users(request.Full_Name, request.Username, hashPassword, request.Role);
                await _userRepo.CreateUserAsync(user);

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                return new GenericResponseDTO<UserResponseDTO>
                {

                    isSuccess = true,
                    message = "User created successfully!",
                    Data = new UserResponseDTO
                    {
                        UserId = user.UsersId,
                        Full_Name = user.Full_Name,
                        Username = user.Username,
                        Role = user.Role,
                        IsActive = user.isActive
                    }
                };
            }
            catch(Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new GenericResponseDTO<UserResponseDTO>
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }
        }
    }
}
