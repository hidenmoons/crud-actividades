using System;
using System.Collections.Generic;

namespace Crud_Actividades.Models;

public partial class Survey
{
    public int IdSurvey { get; set; }

    public int ActivityId { get; set; }

    public string? Answers { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdateAt { get; set; }

    public virtual Activity Activity { get; set; } = null!;
}
