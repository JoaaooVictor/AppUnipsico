namespace AppUnipsico.Api.Models
{
    public class UserTypeModel
    {
        public int UserTypeModelId { get; set; }
        public string UserTypeName { get; set; }
        public string UserTypeDescription { get; set; }
        public DateTime UserTypeDateCreated { get; set; }
        public bool UserTypeIsAdmin { get; set; }
    }
}
