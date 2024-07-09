using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagementSystem.Application.Exceptions;
using LibraryManagementSystem.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Application.Features.Commands.CreateUser
{
    public class CreateUserCommandHandler :IRequestHandler<CreateUserCommandRequest,CreateUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
          IdentityResult result = await _userManager.CreateAsync(new()
            {
                UserName = request.Username,
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname,

            }, request.Password);

            if (result.Succeeded)
                return new()
                {
                    Succeeded = true,
                    Message = "Kullanıcı başarıyla oluşturuldu."
                };
            throw new UserCreateFailedException();
        }
    }
}
