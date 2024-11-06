#region

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MoneyShare.Application.Interfaces.Authentication;
using MoneyShare.Application.Models;
using MoneyShare.Infrastructure.Authentication.Options;

#endregion

namespace MoneyShare.Infrastructure.Authentication;

public class JwtProvider(IOptions<JwtOptions> options, IConfiguration configuration) : IJwtProvider
{
    private readonly JwtOptions _options = options.Value;

    public (string, string) Generate(ApplicationUser user, bool isAdmin = false)
    {
        var accessToken = GenerateAccessToken(user, isAdmin);
        var refreshToken = GenerateRefreshToken(user);

        return (accessToken, refreshToken);
    }

    private string GenerateAccessToken(ApplicationUser user, bool isAdmin)
    {
        var claims = new Claim[]
        {
            new(JwtRegisteredClaimNames.Sub, user.Id),
            new(JwtRegisteredClaimNames.Email, user.Email!),
            new(ClaimTypes.Role, isAdmin ? UserRoles.Admin : UserRoles.User)
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_options.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        _ = int.TryParse(configuration["Jwt:ExpirationInMinutes"], out var tokenValidityInMinutes);

        var accessToken = new JwtSecurityToken(
            _options.Issuer,
            _options.Audience,
            claims,
            null,
            DateTime.UtcNow.AddMinutes(tokenValidityInMinutes),
            signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(accessToken);
    }

    private static string GenerateRefreshToken(ApplicationUser user)
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        var refreshToken = Convert.ToBase64String(randomNumber);

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(60);

        return refreshToken;
    }
}