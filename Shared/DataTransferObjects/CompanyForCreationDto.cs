
namespace Shared.DataTransferObjects
{
    //for post requests
    public record CompanyForCreationDto(string Name, string Address, string Country,
        IEnumerable<EmployeeForCreationDto> Employees);
}
