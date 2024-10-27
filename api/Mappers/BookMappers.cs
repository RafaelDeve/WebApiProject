using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Dtos.Book;
namespace api.Mappers

{
    public static class BookMappers
    {
        public static BookDto ToBookDto(this Book bookModel)
        {
            return new BookDto{
                Id = bookModel.Id,
                Title = bookModel.Title,
                Genre = bookModel.Genre,
                Year = bookModel.Year,
                Author = bookModel.Author
            };
        }

        public static Book ToBookFromCreateDTO(this CreateBookRequestDto bookDto)
        {
            return new Book
            {
                Title = bookDto.Title,
                Genre = bookDto.Genre,
                Year = bookDto.Year,
                Author = bookDto.Author
            };
        }
    }
}