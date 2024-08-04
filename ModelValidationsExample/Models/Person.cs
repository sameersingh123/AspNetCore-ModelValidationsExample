using ModelValidationsExample.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.Models
{
    //Performing validations of model class
    public class Person:IValidatableObject
    {
        [Required(ErrorMessage = "{0} name cannot be null or empty")]
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        [RegularExpression("^[A-Za-z .]*$", ErrorMessage = "{0} should contain only alphabets, space and dot(.)")]
        public string? PersonName { get; set; }



        [EmailAddress(ErrorMessage = "{0} shoulbe be a valid email address")]
        [Required(ErrorMessage ="{0} cannot be blank")]
        public string? Email {  get; set; }



        [Phone(ErrorMessage ="{0} should be 10 digits")]
        public string? Phone { get; set; }


        [Required(ErrorMessage ="{0} cannot be blank")]
        public string? Password {  get; set; }


        [Required(ErrorMessage ="{0} cannot be blank")]
        [Compare("Password", ErrorMessage ="{0} and {1} do not match")]
        public string? ConfirmPassword {  get; set; }



        [Range(0, 500, ErrorMessage ="{0} should be between {1} and {2}")]
        public double? Price { get; set; }


        [MinimumYearVaidator(2000)]
        public DateTime? DateOfBirth { get; set; }

        public DateTime? FromDate { get;set; }


        [DateRangeValidator("FromDate")]
        public DateTime? ToDate { get; set; }

        public int? Age { get; set; }

        public List<string?> Tags { get; set; }=new List<string?>(){ };

        public override string ToString()
        {
            return ($"Person object- Name:{PersonName}, Email:{Email}, Phone:{Phone}, Password:{Password}, ConfirmPassword:{ConfirmPassword}," +
                $"Price: {Price}, DateOfBirth: {DateOfBirth} " );
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           if(DateOfBirth.HasValue==false && Age.HasValue==false)
            {
                yield return new ValidationResult("Either of Age of DateOfBirth should be supplied");
            }
        }
    }
}
