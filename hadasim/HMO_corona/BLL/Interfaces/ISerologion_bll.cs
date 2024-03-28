using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISerologion_bll:ICRUD_dto<Serologion_dto, string>
    {
        public int Unvaccinated();
        public List<int> LastMonthSicks();
    }
}
