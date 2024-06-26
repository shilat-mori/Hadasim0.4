﻿using System;
using System.Collections.Generic;

namespace DAL.HMO;

public partial class PatientAddress
{
    public int Id { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public int? Number { get; set; }

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
