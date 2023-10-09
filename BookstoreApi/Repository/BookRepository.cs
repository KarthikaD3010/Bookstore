using BookstoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookstoreApi.Viewmodel;

namespace BookstoreApi.Repository
{
    public class BookRepository :IBookRepository
    {
        public BookstoreContext bookstoreContext;
        public BookRepository(BookstoreContext _context)
        {
            bookstoreContext = _context;
        }

        public async Task<List<BookDetails>> GetBooksByPublisherAuthorTitle()
        {
            List<BookDetails> Booklist = new List<BookDetails>();
            try
            {
                // Booklist = await bookstoreContext.BookDetails.ToListAsync();
                Booklist = await bookstoreContext.BookDetails.FromSqlRaw($"GetListByPublisher").ToListAsync();
               
                return Booklist;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BookDetails>> GetBooksByAuthorTitle()
        {
            List<BookDetails> Booklist = new List<BookDetails>();
            try
            {
                Booklist = await bookstoreContext.BookDetails.FromSqlRaw($"GetListByAuthorthentitle").ToListAsync();
                return Booklist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<decimal> GetTotalPrice()
        {
            try
            {
                decimal Total = new decimal();
                Total = await bookstoreContext.BookDetails.SumAsync(s => s.Price);
                return Total;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> AddBooks(List<BookDetails> ListBooks)
        {
            try
            {
                string Result = string.Empty;
                Result = "Failed to Add Books";

                if (ListBooks!=null && ListBooks.Count > 0)
                {
                    await bookstoreContext.BookDetails.AddRangeAsync(ListBooks);
                    var Issaved = await bookstoreContext.SaveChangesAsync();
                    if (Issaved > 0)
                    {
                        Result = "Books Inserted Successfully";
                    }
                }
                return Result;
            }
            catch(Exception ex)
            {
                throw ex;

            }
        }
    }
}
