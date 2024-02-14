using AppUnipsico.Api.Models.Enums;

namespace AppUnipsico.Api.Models
{
    public class ConsultModel
    {
        public Guid ConsultId { get; set; }
        public ConsultStatus ConsultStatus { get; set; }
        public Guid PatientId { get; set; }
        public PatientModel Patient { get; set; } = new PatientModel();
        public Guid StudentId { get; set; }
        public StudentModel Student { get; set; } = new StudentModel();
        public Guid TeacherId { get; set; }
        public TeacherModel Teacher { get; set; } = new TeacherModel();
    }
}
