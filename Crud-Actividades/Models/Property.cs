using System;
using System.Collections.Generic;

namespace Crud_Actividades.Models;

public partial class Property
{
    public int IdProperty { get; set; }

    public string Tittle { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdateAt { get; set; }

    public DateTime? DisableAt { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();
}
