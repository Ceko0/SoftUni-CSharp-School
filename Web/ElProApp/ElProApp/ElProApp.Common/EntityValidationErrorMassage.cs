
namespace ElProApp.Common
{
    public static class EntityValidationErrorMessage
    {
        public static class Master
        {
            public const string ErrorMassageFieldIsRequired = "Полето е задължително";
            public const string ErrorMassageFieldForNameIsRequired = "Полето за име е задължително";
        }

        public static class Employee
        {
            public const string ErrorMassageNameMinLength = "Името трябва да бъде поне 2 символа.";
            public const string ErrorMassageNameMaxLength = "Името не може да надвишава 20 символа.";
            public const string ErrorMassageMoney = "Стойността трябва да е с максимум 4 цифри преди и 2 след десетичната запетая.";
        }

        public static class Building
        {
            public const string ErrorMassageBuildingNameMinLength = $"Името на сградата трябва да бъде поне 3 символа.";
            public const string ErrorMassageBuildingNameMaxLength = $"Името на сградата не може да надвишава 50 символа.";
            public const string ErrorMassageLocationMinLength = "Местоположението трябва да бъде поне 10 символа.";
            public const string ErrorMassageLocationMaxLength = "Местоположението не може да надвишава 100 символа.";
        }

        public static class Team
        {
            public const string ErrorMassageNameMinLength = "Името на екипа трябва да бъде поне 5 символа.";
            public const string ErrorMassageNameMaxLength = "Името на екипа не може да надвишава 100 символа.";
        }

        public static class Job
        {
            public const string ErrorMassageNameMinLength = "Името на работата трябва да бъде поне 5 символа.";
            public const string ErrorMassageNameMaxLength = "Името на работата не може да надвишава 50 символа.";
            public const string ErrorMassagePrice = "Стойността трябва да е с максимум 4 цифри преди и 2 след десетичната запетая.";
        }

        public static class jobDobe
        {
            public const string ErrorMassageQuantity = "Стойността трябва да е с максимум 6 цифри преди и до 2 след десетичната запетая.";
            public const string ErrorMassageDaysForJob = "Дните за свършена работа трябва да са между 1 и 30.";
        }

        public static class UserLogin
        {
            public const string ErrorMassageNameMinLength = "Името трябва да бъде поне 5 символа.";
            public const string ErrorMassageNameMaxLength = "Името не може да надвишава 20 символа.";
            public const string ErrorMassagePasswordMinLength = "Паролата трябва да бъде поне 8 символа.";
            public const string ErrorMassagePasswordMaxLength = "Паролата  не трябва да бъде повече от 30 символа.";
            public const string ErrorMassagePasswordInvalid = "Паролата трябва да съдържа само букви и цифри.";
        }
    }
}
