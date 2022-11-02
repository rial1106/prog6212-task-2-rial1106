namespace PROG6212.Models
{
    /* The User class hold the username and hashed password for the current user.
     * The class is static as we will only be needing one throughout the runtime of the program.
     */
    internal static class User
    {

        private static string Username; // The logged in Username.
        private static string Password; // How many weeks long the semester is.

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

        public static int Password1
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
