using System.ComponentModel.DataAnnotations;
using WeiXinAPI.Model;

namespace WeiXinAPI.ValidationAttributes
{
    public class CityDeadAndCityCured:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            var addDto = (CityAddDto)validationContext.ObjectInstance;
            if(addDto.DeadPopulation==addDto.CurdPopulation)
            {
                return new ValidationResult(errorMessage:"死亡人等于",new[] { nameof(CityAddDto)});
            }
            return ValidationResult.Success;
        }
    }
}
