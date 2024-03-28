using System;
using System.Collections.Generic;

namespace DAL.HMO;

public partial class Producer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Vaccine> Vaccines { get; set; } = new List<Vaccine>();
}
