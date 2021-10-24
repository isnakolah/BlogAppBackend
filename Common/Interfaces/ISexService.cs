using Blog.Common.Models.ServiceResult;
using Blog.DTOs.Sexes;
using System.Threading.Tasks;

namespace Blog.Common.Interfaces
{
    public interface ISexService
    {
        Task<ServiceResult<GetSexDTO[]>> GetAllSexesAsync();
    }
}
