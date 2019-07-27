using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Patterns.Repository
{
    public interface IPresenter<Input, Output>
    {
        Task<IEnumerable<Output>> GetAllAsync();

        Task<Output> GetItemByIdAsync(int id);

        Task<Output> CreateAsync(Input item);

        Task<Output> UpdateAsync(Input item);

        Task DeleteAsync(int id);
    }
}
