using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Book;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDBcontext _context;
        public BookController(ApplicationDBcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll(){
            var books = _context.Book.ToList()
                .Select(s => s.ToBookDto());
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id) {
            var book = _context.Book.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book.ToBookDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateBookRequestDto bookDto){
            var bookModel = bookDto.ToBookFromCreateDTO();
            _context.Book.Add(bookModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = bookModel.Id}, bookModel.ToBookDto());
        }
    }
}