using Microsoft.AspNetCore.Mvc;

namespace Challange4.Repositorio
{
    public interface IResumoRepositorio
    {
         Task<IActionResult> ResumoMes(string data1, string data2);
      
    }
}
