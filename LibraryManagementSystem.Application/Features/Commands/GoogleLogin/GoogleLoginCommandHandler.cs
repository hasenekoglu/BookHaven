using Google.Apis.Auth;
using LibraryManagementSystem.Application.Token;
using LibraryManagementSystem.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Application.Features.Commands.GoogleLogin;

public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest,GoogleLoginCommandResponse>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenHandler _tokenHandler;

    public GoogleLoginCommandHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request,
        CancellationToken cancellationToken)
    {
        var settings = new GoogleJsonWebSignature.ValidationSettings()
        {
            Audience = new List<string>
                { "815634901383-53df2e1lii6ufrh6u81j8a4golaj1s36.apps.googleusercontent.com" }

        };
        var payLoad = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, settings);

        var info = new UserLoginInfo(request.Provider, payLoad.Subject, request.Provider);
        AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

        bool result = user != null;
        if (user == null)
        {
            user = await _userManager.FindByEmailAsync(payLoad.Email);
            if (user == null)
            {
                user = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = payLoad.Email,
                    UserName = payLoad.Email,
                    Name = payLoad.Name
                };
                var identityResult =await _userManager.CreateAsync(user);
                result = identityResult.Succeeded;
            }
        }

        if (result)
            await _userManager.AddLoginAsync(user, info);
        else
            throw new Exception("Invalid external authentication");

        Dtos.Token token = _tokenHandler.CreateAccessToken(5);

        return new()
        {
            Token = token
        };
    }
}