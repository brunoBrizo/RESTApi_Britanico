using System;
using System.Collections.Generic;
using System.Text;

namespace britanicoCore.QueryFilters
{
    public class LogErrorQueryFilter
    {
        public int EmpId { get; set; }
        public string StackTrace { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        //paginacion
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
