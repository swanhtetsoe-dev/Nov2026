using System;
using System.Collections.Generic;

namespace Nov2026.Database.Models;

public partial class Project1Question
{
    public int QuestionId { get; set; }

    public int QuestionNo { get; set; }

    public string QuestionName { get; set; } = null!;

    public virtual ICollection<Project1Answer> Project1Answers { get; set; } = new List<Project1Answer>();
}
