using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CleanArchitecture.Infrastructure.Authentication;
public sealed class JwtProvider(
    IOptions<JwtOptions> jwtOptions,
    UserManager<User> userManager) : IJwtProvider
{
    public async Task<LoginCommandResponse> CreateTokenAsync(User user)
    {
        var claims = new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Name, user.UserName),
            new Claim("NameLastName", user.NameLastName)
        };

        DateTime expires = DateTime.Now.AddMinutes(2);

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: jwtOptions.Value.Issuer,
            audience: jwtOptions.Value.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey)), SecurityAlgorithms.HmacSha512)
            );

        string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        string refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpires = expires.AddMinutes(3);

        await userManager.UpdateAsync(user);

        LoginCommandResponse response = new(
            token,
            refreshToken,
            user.RefreshTokenExpires,
            user.Id);

        return response;
    }
}
