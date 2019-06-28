using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.Services.Abstract
{
    public interface IService<TViewModel>
    {
        IEnumerable<TViewModel> GetDTOs();
        TViewModel GetDTO(int id);

        Task SaveAsync(TViewModel viewModel);

        Task DeleteAsync(int id);
    }
}
