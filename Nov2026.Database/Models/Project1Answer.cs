using System;
using System.Collections.Generic;

namespace Nov2026.Database.Models;

public partial class Project1Answer
{
    public int AnswerId { get; set; }

    public int QuestionId { get; set; }

    public int AnswerNo { get; set; }

    public string AnswerResult { get; set; } = null!;

    public virtual Project1Question Question { get; set; } = null!;
}
