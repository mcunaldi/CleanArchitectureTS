using CleanArchitecture.Infrastructure.Authentication;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.WebAPI.OptionsSetop;

public sealed class JwtOptionsSetup(IConfiguration configuration) : IConfigureOptions<JwtOptions>
{
    public void Configure(JwtOptions options)
    {
        configuration.GetSection("Jwt").Bind(options);
    }
}
