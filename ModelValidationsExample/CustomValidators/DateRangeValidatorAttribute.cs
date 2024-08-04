using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidationsExample.CustomValidators
{
    public class DateRangeValidatorAttribute: ValidationAttribute
    {
        public string FromDate { get;set; }
        public DateRangeValidatorAttribute(string fromdate)
        {
            FromDate = fromdate;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value!=null)
            {

                //For getting value of ToDate
                DateTime ToDate=(DateTime)value;




                //For getting value of FromDate

                //DateTime FromDate=(DateTime)value;
                PropertyInfo? FromDateProperty = validationContext.ObjectType.GetProperty(FromDate);
                DateTime from_date = Convert.ToDateTime(FromDateProperty.GetValue(validationContext.ObjectInstance));


                if (ToDate <from_date)
                {
                    return new ValidationResult($"{from_date} should be lesser than {ToDate}");
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
