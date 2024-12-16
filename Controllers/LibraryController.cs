using FirstApi.Communication.Requests;
using FirstApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FirstApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LibraryController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        return Ok(Library.Books);
    }       
    
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(long id)
    {
        var book = new Library().getBookById(id);
        if(book is not null) return Ok(book);

        return NotFound();
    }    
    
    [HttpPost]
    [ProducesResponseType(typeof(int) ,StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] RequestCreateBook book)
    {
        var newBook = new Book(book.Title, book.Genre, book.Author, book.Price, book.Quantity);
        new Library().AddBook(newBook);
        return Created(String.Empty, newBook.Id);
    }    

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(long id)
    {
        var bookId = new Library().RemoveBook(id);

        if (bookId is not null) return NoContent();
        return NotFound();
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(long id, [FromBody] RequestCreateBook book)
    {
        var updatedBookId = new Library().UpdateBook(id, book);
        if (updatedBookId is not null) return NoContent();
        return NotFound();
    }
}
