#region

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

#endregion

namespace MoneyShare.Application.Models;

public class ApplicationUser : IdentityUser
{
    [MaxLength(100)] public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiryTime { get; set; }
}