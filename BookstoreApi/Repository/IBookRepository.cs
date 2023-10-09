using BookstoreApi.Models;
using BookstoreApi.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreApi.Repository
{
    public interface IBookRepository
    {
        Task<List<BookViewmodel>> GetBooksByPublisherAuthorTitle();
        Task<List<BookViewmodel>> GetBooksByAuthorTitle();
        Task<decimal> GetTotalPrice();
        Task<string> AddBooks(List<BookDetails> ListBooks);
    }
}
