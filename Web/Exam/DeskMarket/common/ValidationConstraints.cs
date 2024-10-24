namespace DeskMarket.common
{
    public static class ValidationConstraints
    {
        public static class Product
        {
            public const int ProductNameMinLength = 2;
            public const int ProductNameMaxLength = 60;
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 250;
            public const int ImageUrlMaxLength = 2048;
            public const double PriceMinRange = 1.00;
            public const double PriceMaxRange = 3000.00;
            public const string DateTimeFormat = "dd-MM-yyyy";
        }

        public static class  Category
        {
            public const int CategoryNameMinLength = 3;
            public const int CategoryNameMaxLength = 20;
        }
    }
}
