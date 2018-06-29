using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Domain;
using Livraria.Model;
using Livraria.Repositories;
using Livraria.Services;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [Route("api/books")]
    [Produces("application/json")]
    public class BooksController : Controller
    {
        private readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<BookResponseViewModel>), 200)]
        public IActionResult Get()
        {
            return Ok(_service.FindAll());
        }

        [HttpGet("stock")]
        [ProducesResponseType(typeof(List<BookResponseViewModel>), 200)]
        public IActionResult GetInStock()
        {
            return Ok(_service.FindAllInStock());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BookResponseViewModel), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            var book = _service.FindById(id);
            if (book == null) 
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BookResponseViewModel), 201)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] BookViewModel book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_service.Save(book));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BookResponseViewModel), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Put(int id, [FromBody] BookViewModel book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            book.ID = id;
            var bookVM = _service.Save(book);
            if (bookVM == null)
            {
                return NotFound();
            }
            return Ok(bookVM);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int id)
        {
            if (!_service.Delete(id))
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost("sell")]
        [ProducesResponseType(typeof(BookViewModel), 200)]
        [ProducesResponseType(400)]
        public IActionResult Sell([FromBody] BookSellViewModel book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookVM = _service.Sell(book);
            if(bookVM == null) {
                return BadRequest();
            }
            return Ok();
        }
    }
}
