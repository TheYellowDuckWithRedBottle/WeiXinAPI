﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WeiXinAPI.Enitities;
using WeiXinAPI.ValidationAttributes;

namespace WeiXinAPI.Model
{
   
    public class CityAddDto:IValidatableObject
    {
      
        public string CityName { get; set; }
        public int TotalPopulation { get; set; }
        public int ConfirmedPopulation { get; set; }
        public int CurdPopulation { get; set; }
        public int DeadPopulation { get; set; }

        public IEnumerable<ValidationResult> Validate (ValidationContext validationContext)
        {
        if(TotalPopulation==ConfirmedPopulation)
            {
                yield return new ValidationResult(errorMessage:"总人数和确认人数不能相同",new[] { nameof(CityAddDto)});
            }
        }
    }
}
