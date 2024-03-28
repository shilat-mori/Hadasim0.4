using System;
using System.Collections.Generic;

namespace DAL.HMO;

public partial class Serologion
{
    public string Id { get; set; } = null!;

    public DateTime? PositiveDate { get; set; }

    public DateTime? RecoveryDate { get; set; }

    public bool? Status { get; set; }
}
