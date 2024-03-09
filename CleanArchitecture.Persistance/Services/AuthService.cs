using AutoMapper;
using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistance.Services;
public sealed class AuthService(
    UserManager<User> userManager,
    IMapper mapper,
    IMailService mailService,
    IJwtProvider jwtProvider) : IAuthService
{

    public async Task RegisterAsync(RegisterCommand request)
    {
        User user = mapper.Map<User>(request);
        IdentityResult  result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }

        string subject = "Yeni Kayıt";

        await mailService.SendMailAsync(request.Email, subject, "");
    }
    public async Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken)
    {
        User? user = await userManager.Users.Where(p => p.UserName == request.UserNameOrEmail || p.Email == request.UserNameOrEmail).FirstOrDefaultAsync(cancellationToken);

        if (user is null)
        {
            throw new Exception("Kullanıcı bulunamadı");
        }

        var result = await userManager.CheckPasswordAsync(user, request.Password);

        if (result)
        {
            LoginCommandResponse response = await jwtProvider.CreateTokenAsync(user);
            return response;
        }

        throw new Exception("Şifreniz yanlış!!");
    }
    public async Task<LoginCommandResponse> CreateTokenByRefreshTokenAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        User? user = await userManager.FindByIdAsync(request.UserId);

        if (user is null)                               throw new Exception("Kullanıcı bulunamadı");

        if (user.RefreshToken != request.RefreshToken)  throw new Exception("Refresh Token geçerli değil!");

        if (user.RefreshTokenExpires < DateTime.Now) throw new Exception("Refresh Token süresi dolmuş!");

        LoginCommandResponse response = await jwtProvider.CreateTokenAsync(user);
        return response;
    }
}
