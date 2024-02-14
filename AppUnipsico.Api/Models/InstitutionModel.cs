namespace AppUnipsico.Api.Models
{
    public class InstitutionModel
    {
        public Guid InstitutionId { get; set; }
        public string InstitutionName { get; set; }
        public Guid AddressId { get; set; }
        public virtual AddressModel Address { get; set; }
        public virtual ICollection<StageModel> Stages { get; set; }
    }
}
