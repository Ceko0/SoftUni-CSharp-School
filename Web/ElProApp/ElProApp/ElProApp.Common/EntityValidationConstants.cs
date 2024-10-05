namespace ElProApp.Common
{
    public static class EntityValidationConstants
    {
        public static class employee
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 20;

        }

        public static class building
        {
            public const int BuildingNameMinLength = 3;
            public const int BuildingNameMaxLength = 50;
            public const int LocationMinLength = 10;
            public const int LocationMaxLength = 100;
        }

        public static class Team
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 100;
        }

        public static class job
        {
            public const int nameMinLength = 5;
            public const int nameMaxLength = 50;
        }

        public static class UserLogin
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 20;
            public const int PasswordMinLength = 8;
            public const int PasswordMaxLength = 30;
        }

        public static class Login
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 20;
        }
    }
}