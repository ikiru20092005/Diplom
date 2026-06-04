using CoreStoreCRM.Models;

namespace CoreStoreCRM
{
    public static class SessionManager
    {
        public static User CurrentUser { get; set; }

        public static bool IsLoggedIn => CurrentUser != null;

        public static bool IsManager => CurrentUser?.RoleId == 2;

        public static bool IsAdmin => CurrentUser?.RoleId == 3;

        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}
