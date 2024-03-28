using System;
using System.Collections.Generic;

namespace DAL.HMO;

public partial class Patient
{
    public string Id { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? AddressId { get; set; }

    public DateTime? BurnDate { get; set; }

    public string? Phone { get; set; }

    public string? Tel { get; set; }

    public string? Pic { get; set; }

    public bool? Status { get; set; }

    public virtual PatientAddress? Address { get; set; }
}
