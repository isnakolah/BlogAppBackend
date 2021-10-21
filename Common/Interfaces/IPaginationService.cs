using Blog.Common.Models.ServiceResult;
using Blog.Models.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Common.Interfaces
{
    public interface IPaginationService
    {
        Task<PaginatedServiceResult<TOut>> CreateAsync<TIn, TOut>(IQueryable<TIn> source) where TIn : AuditableEntity where TOut : class;
    }
}
