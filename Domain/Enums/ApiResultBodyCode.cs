using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Enums;

public enum ApiResultBodyCode
{
    [Display(Name = "Operation done successfully")]
    Success = 1,

    [Display(Name = "Server error occurred")]
    ServerError = 2,

    [Display(Name = "Invalid arguments")]
    BadRequest = 3,

    [Display(Name = "Not found")]
    NotFound = 4,

    [Display(Name = "Duplication error")]
    Duplication = 5

}
