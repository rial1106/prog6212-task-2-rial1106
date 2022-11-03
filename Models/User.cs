namespace PROG6212.Models
{
    /* The User class hold the username and hashed password for the current user.
     * The class is static as we will only be needing one throughout the runtime of the program.
     */
    internal static class User
    {

        public static string Username; // The logged in Username.
        public static string Password; // The password.

        // Getters and Setters.
        public static string Username1
        {
            get
            {
                return Username;
            }

            set
            {
                Username = value;
            }
        }

        public static string Password1
        {
            get
            {
                return Password;
            }

            set
            {
                Password = value;
            }
        }

    }
}
