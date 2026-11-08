namespace Nov2026.WebApi.Models
{
    public class AnswerCreateRequestModel
    {
        public int QuestionId { get; set; }
        public int AnswerNo { get; set; }
        public string AnswerResult { get; set; } = null!;
    }

    public class AnswerUpdateRequestModel
    {
        public int? QuestionId { get; set; }
        public int? AnswerNo { get; set; }
        public string? AnswerResult { get; set; }
    }
}
