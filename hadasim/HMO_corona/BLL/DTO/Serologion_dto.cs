using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class Serologion_dto
    {
        public string Id { get; set; } = null!;

        public DateTime? PositiveDate { get; set; }

        public DateTime? RecoveryDate { get; set; }

        public bool? Status { get; set; }
    }
}
