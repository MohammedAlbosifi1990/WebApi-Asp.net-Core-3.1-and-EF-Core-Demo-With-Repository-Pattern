using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi_Asp.net_Core_3._1_and_EF_Core_Demo.Data
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }


}
