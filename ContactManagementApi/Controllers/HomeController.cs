using Microsoft.AspNetCore.Mvc;
using ContactManagementApi.Models;

namespace ContactManagementApi.Controllers {

    public class HomeController : Controller {

        private IRepository repository { get; set; }

        public HomeController(IRepository repo) => repository = repo;

        public ViewResult Index() => View(repository.Contacts);

    }
}
