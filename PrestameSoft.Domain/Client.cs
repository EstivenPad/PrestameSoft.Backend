using PrestameSoft.Domain.Common;

namespace PrestameSoft.Domain
{
    public class Client : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Identification { get; set; } = string.Empty;
    }
}
