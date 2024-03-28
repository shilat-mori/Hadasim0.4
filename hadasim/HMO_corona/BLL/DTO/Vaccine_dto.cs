using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class Vaccine_dto
    {
        public int Id { get; set; }

        public DateTime? VacDate { get; set; }

        public int? Producter { get; set; }
    }
}
