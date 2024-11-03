using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.Extensions.Configuration;
using MVC.Models;
using MVC.Repository;

namespace MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly ServiceRepository _serviceRepo;

        private readonly YourDbContext _context;
        public BookController(IConfiguration configuration)
        {
            _serviceRepo = new ServiceRepository(configuration);
        }

       
        public ActionResult GetAllBooks()
        {
            try
            {
                HttpResponseMessage response = _serviceRepo.GetResponse("api/book/getall");
                response.EnsureSuccessStatusCode();
                List<Book> books = response.Content.ReadAsAsync<List<Book>>().Result; 
                ViewBag.Title = "All Books";
                return View(books);
            }
            catch (Exception)
            {
                throw;
            }
        }

        
        public ActionResult Details(int id)
        {
            HttpResponseMessage response = _serviceRepo.GetResponse($"api/book/getbyid/{id}");
            response.EnsureSuccessStatusCode();
            Book book = response.Content.ReadAsAsync<Book>().Result; 
            ViewBag.Title = "Book Details";
            return View(book);
        }

        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = _serviceRepo.GetResponse($"api/book/getbyid/{id}");
            response.EnsureSuccessStatusCode();
            Book book = response.Content.ReadAsAsync<Book>().Result;
            ViewBag.Title = "Edit Book";
            return View(book);
        }
 

        
    }
}
