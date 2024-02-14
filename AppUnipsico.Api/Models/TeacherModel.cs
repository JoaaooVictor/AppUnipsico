namespace AppUnipsico.Api.Models
{
    public class TeacherModel : UserBaseModel
    {
        public virtual IEnumerable<ConsultModel> Consults { get; set; }
    }
}
