namespace AppUnipsico.Api.Models
{
    public class UserBaseModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserDisplayName { get; set; } = string.Empty;
        public DateTime UserDateOfBirth { get; set; }
        public string UserCpf { get; set; } = string.Empty;
        public string UserPassword { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public bool UserIsActive { get; set; }
        public DateTime UserDateCreated { get; set; }
        public int UserTypeId { get; set; }
        public virtual UserTypeModel UserType { get; set; } = new UserTypeModel();
    }
}
