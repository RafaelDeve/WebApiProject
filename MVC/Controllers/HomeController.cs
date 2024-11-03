using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;
using System.Linq; // Asegúrate de tener este using para trabajar con LINQ
using Microsoft.EntityFrameworkCore; // Si usas Entity Framework

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly YourDbContext _context; // Asegúrate de que este es tu contexto de base de datos

        // Constructor con inyección de dependencias para el logger y el contexto de la base de datos
        public HomeController(ILogger<HomeController> logger, YourDbContext context)
        {
            _logger = logger;
            _context = context; // Inyecta el contexto
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GetAllBooks() // Agrega el método GetAllBooks
        {
            var books = _context.Book.ToList(); // Obtén la lista de libros
            return View(books); // Devuelve la vista con la lista de libros
        }

        public IActionResult EditBook(int id)
        {
            var book = _context.Book.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book); // Devuelve la vista con el modelo del libro para editar
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Update(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(GetAllBooks)); // Redirige a la lista de libros
            }
            return View(book);
        } 

        public ActionResult Delete(int id)
        {
            var book = _context.Book.Find(id); // Busca el libro por su ID
            if (book == null)
            {
                return NotFound(); // Retorna NotFound si el libro no existe
            }
            ViewBag.Title = "Delete Book";
            return View(book); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var book = _context.Book.Find(id); 
            if (book == null)
            {
                return NotFound(); 
            }

            _context.Book.Remove(book); 
            _context.SaveChanges(); 
            return RedirectToAction("GetAllBooks"); 
        }

        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Book.Add(book);
                _context.SaveChanges(); 
                return RedirectToAction("GetAllBooks");
            }
            return View(book); 
        }
        
        public IActionResult Details(int id)
        {
            var book = _context.Book.Find(id); 
            if (book == null)
            {
                return NotFound();
            }
            return View(book); 
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
