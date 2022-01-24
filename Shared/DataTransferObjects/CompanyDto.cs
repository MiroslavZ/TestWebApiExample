

namespace Shared.DataTransferObjects
{
    //[Serializable]
    //public record CompanyDto(Guid Id, string Name, string FullAddress); //for get requests
    
    //this one for pretty xml answers
    public record CompanyDto
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? FullAddress { get; init; }
    }
}
