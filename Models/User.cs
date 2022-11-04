using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROG6212.Models
{
    /* The User class hold the username and hashed password for the current user.
     * The class is static as we will only be needing one throughout the runtime of the program.
     */
    public class User
    {
        [Key, MaxLength(100)]
        public string username { get; set; } = null!; // The logged in Username.
        [StringLength(64, MinimumLength = 64, ErrorMessage = "This field must be 64 characters")]
        public string password { get; set; } = null!; // The password.
        public ICollection<Module> modules { get; set; } = null!;

    }
}
