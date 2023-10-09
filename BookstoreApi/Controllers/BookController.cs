using BookstoreApi.Models;
using BookstoreApi.Repository;
using BookstoreApi.Viewmodel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public IBookRepository bookRepository;
        public BookController(IBookRepository _bookRepository)
        {
            bookRepository = _bookRepository;
        }

        [HttpGet]
        [Route("getbooksbypublisher")]
        public async Task<IActionResult> GetBooksByPublisherAuthorTitle()
        {
            try
            {
                var Booklist = await bookRepository.GetBooksByPublisherAuthorTitle();

                return Ok(Booklist);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("getbooksbyauthor")]
        public async Task<IActionResult> GetBooksByAuthor()
        {
            try
            {
                var Booklist = await bookRepository.GetBooksByAuthorTitle();

                return Ok(Booklist);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("gettotalprice")]
        public async Task<IActionResult> GetTotalPrice()
        {
            try
            {
                var Totalprice = await bookRepository.GetTotalPrice();

                return Ok(Totalprice);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("AddBooks")]
        public async Task<IActionResult> AddBooks([FromBody] List<BookDetails> BookList)
        {
            try
            {
                return Ok(await bookRepository.AddBooks(BookList));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
