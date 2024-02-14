namespace AppUnipsico.Api.Models
{
    public class StudentModel : UserBaseModel
    {
        public virtual IEnumerable<ConsultModel> Consults { get; set; }
    }
}
