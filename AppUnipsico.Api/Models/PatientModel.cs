namespace AppUnipsico.Api.Models
{
    public class PatientModel : UserBaseModel
    {
        public virtual IEnumerable<ConsultModel> Consults { get; set; }
    }
}
