namespace Nov2026.WebApi.Models
{
    public class QuestionCreateRequestModel
    {
        public int QuestionNo { get; set; }
        public string QuestionName { get; set; } = null!;
    }

    public class QuestionUpdateRequestModel
    {
        public int? QuestionNo { get; set; }
        public string? QuestionName { get; set; }
    }
}
