using System;
using System.Collections.Generic;

namespace Crud_Actividades.Models;

public partial class Activity
{
    public int IdActivity { get; set; }

    public int PropertyId { get; set; }

    public DateTime Schedule { get; set; }

    public string Title { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Status { get; set; } = null!;

    public virtual Property Property { get; set; } = null!;

    public virtual ICollection<Survey> Surveys { get; set; } = new List<Survey>();
}
