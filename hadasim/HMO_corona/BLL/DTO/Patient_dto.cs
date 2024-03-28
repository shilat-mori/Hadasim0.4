using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class Patient_dto
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

    }
}
