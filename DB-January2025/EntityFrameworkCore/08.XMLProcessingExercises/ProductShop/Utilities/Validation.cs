namespace ProductShop.Utilities
{
    using System.ComponentModel.DataAnnotations;

    public class Validation
    {
        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator
                .TryValidateObject(dto, validateContext, validationResults, true);

            return isValid;
        }
    }
}
