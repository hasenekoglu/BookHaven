using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Application.Exceptions;
using LibraryManagementSystem.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Application.Features.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest,LoginUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginUserCommandHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.FindByNameAsync(request.UserNameOrEmail);

            if (user == null)
                user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);

            if (user == null)
                throw new NotFoundUserException("Kullanıcı veya şifre hatalı...");

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
           if (result.Succeeded)//Authentication başarılı
           {
               //Yetkileri belirlememiz gerekiyor!
           }

           return new();

        }
    }
}
