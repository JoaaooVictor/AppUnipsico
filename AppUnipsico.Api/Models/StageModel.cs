namespace AppUnipsico.Api.Models
{
    public class StageModel
    {
        public Guid StageId { get; set; }
        public DateTime DateStage { get; set; }
        public Guid StudentId { get; set; }
        public StudentModel Student { get; set; }
        public Guid TeacherId { get; set; }
        public TeacherModel Teacher { get; set; }
        public Guid InstitutionId { get; set; }
        public InstitutionModel Institution { get; set; }
    }
}
