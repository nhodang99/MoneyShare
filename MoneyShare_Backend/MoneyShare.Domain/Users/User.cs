using MoneyShare.Domain.Base;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Groups_Users;
using System.ComponentModel.DataAnnotations;

namespace MoneyShare.Domain.Users
{
    public partial class User : DeleteEntity<int>
    {
        [Required(ErrorMessage = "User name is required")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 50 characters")]
        public required string UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public required string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public required string Password { get; set; }

        public virtual ICollection<Group_User>? Groups_Users { get; set; }
        public virtual ICollection<Bill>? Bills { get; set; }

        public User()
        {
            Groups_Users = new HashSet<Group_User>();
            Bills = new HashSet<Bill>();
        }
    }
}
