using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectExcercise.Application.Common.Interfaces
{
    public interface IQueryHandler<TIn, TResult>
    {
        Task<TResult> ExecuteQuery(TIn request, CancellationToken cancellationToken);
    }
}
