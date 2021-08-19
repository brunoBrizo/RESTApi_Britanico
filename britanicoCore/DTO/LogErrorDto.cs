using System;
using System.Collections.Generic;
using System.Text;

namespace britanicoCore.DTO
{
    public class LogErrorDto
    {

        public DateTime? Fecha { get; set; }

        public string StackTrace { get; set; }

        public string Msg { get; set; }
        public int EmpId { get; set; }
    }
}
