using System;
using System.Collections.Generic;

namespace DAL.HMO;

public partial class CoronaVaccine
{
    public string Id { get; set; } = null!;

    public int? Vac1 { get; set; }

    public int? Vac2 { get; set; }

    public int? Vac3 { get; set; }

    public int? Vac4 { get; set; }

    public bool? Status { get; set; }

    public virtual Vaccine? Vac1Navigation { get; set; }

    public virtual Vaccine? Vac2Navigation { get; set; }

    public virtual Vaccine? Vac3Navigation { get; set; }

    public virtual Vaccine? Vac4Navigation { get; set; }
}
