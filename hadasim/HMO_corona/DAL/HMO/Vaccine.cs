using System;
using System.Collections.Generic;

namespace DAL.HMO;

public partial class Vaccine
{
    public int Id { get; set; }

    public DateTime? VacDate { get; set; }

    public int? Producer { get; set; }

    public virtual ICollection<CoronaVaccine> CoronaVaccineVac1Navigations { get; set; } = new List<CoronaVaccine>();

    public virtual ICollection<CoronaVaccine> CoronaVaccineVac2Navigations { get; set; } = new List<CoronaVaccine>();

    public virtual ICollection<CoronaVaccine> CoronaVaccineVac3Navigations { get; set; } = new List<CoronaVaccine>();

    public virtual ICollection<CoronaVaccine> CoronaVaccineVac4Navigations { get; set; } = new List<CoronaVaccine>();

    public virtual Producer? ProducerNavigation { get; set; }
}
