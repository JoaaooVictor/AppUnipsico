namespace AppUnipsico.Api.Models
{
    public class AddressModel
    {
        public Guid AddressId { get; set; }
        public string PublicPlace { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string Town { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public virtual InstitutionModel? Institution { get; set; }
    }
}
