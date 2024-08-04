using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.CustomValidators
{
    public class MinimumYearVaidatorAttribute: ValidationAttribute
    {
        public int MinimumYear { get;set; }


        //parameterless constructor
        public MinimumYearVaidatorAttribute()
        { 
        
        }

        //paramerterized constructor
        public MinimumYearVaidatorAttribute(int minimumyear)
        {
            MinimumYear = minimumyear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date= (DateTime)value;
                int year = date.Year;
                if (year >= MinimumYear)
                {
                    return new ValidationResult($"Minimum year age should be {MinimumYear}");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return null;
        }

    }
}
