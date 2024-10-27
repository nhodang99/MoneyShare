using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace MoneyShare.Infrastructure.Authentication.Options;
public class JwtOptionsSetup(IConfiguration configuration) : IConfigureOptions<JwtOptions>
{
    private const string JwtSection = "Jwt";

    public void Configure(JwtOptions options)
    {
        configuration.GetSection(JwtSection).Bind(options);
    }
}
