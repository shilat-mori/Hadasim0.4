﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PatientAddress_dto
    {
        public int Id { get; set; }

        public string? City { get; set; }

        public string? Street { get; set; }

        public int? Number { get; set; }

    }
}
