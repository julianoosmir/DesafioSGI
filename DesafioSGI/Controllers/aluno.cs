using Microsoft.AspNetCore.Mvc;

namespace DesafioSGI.Controllers
{
    public class aluno : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}