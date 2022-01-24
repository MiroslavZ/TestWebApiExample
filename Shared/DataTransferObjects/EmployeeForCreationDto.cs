using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    //for post requests
    public record EmployeeForCreationDto : EmployeeForManipulationDto;
}
