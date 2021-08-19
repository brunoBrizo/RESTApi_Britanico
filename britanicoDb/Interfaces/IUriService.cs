using britanicoCore.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace britanicoDb.Interfaces
{
    public interface IUriService
    {
        Uri GetLogErrorPaginationUri(LogErrorQueryFilter logQuery, string actionUrl);
    }
}
