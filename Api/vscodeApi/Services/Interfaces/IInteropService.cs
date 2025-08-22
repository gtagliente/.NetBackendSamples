using System.Collections.Generic;
using System.Threading.Tasks;
using Clients.CleanArchitectureClient;
  


namespace vscodeApi.Interfaces;

public interface IInteropService
{
    Task<IEnumerable<Blog>> GetAllBlogs();
}
