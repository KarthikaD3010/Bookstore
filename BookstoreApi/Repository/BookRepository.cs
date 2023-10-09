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

        public async Task<List<BookViewmodel>> GetBooksByPublisherAuthorTitle()
        {
            List<BookViewmodel> listViewmodel = new List<BookViewmodel>();
            List<BookDetails> Booklist = new List<BookDetails>();
            try
            {
                // Booklist = await bookstoreContext.BookDetails.ToListAsync();
                Booklist = await bookstoreContext.BookDetails.FromSqlRaw($"GetListByPublisher").ToListAsync();
                if (Booklist != null && Booklist.Count > 0)
                {
                    //iterate booklist to get each book details and generate seperate citations
                    foreach (BookDetails book in Booklist)
                    {
                        if (book != null)
                        {
                            BookViewmodel bookviewmodel = new BookViewmodel();
                            BookDetails bookdetails = book;
                            bookviewmodel.MLACitation =  GenerateMLACitation(book);
                            bookviewmodel.ChicagoCitation =  GenerateChicagoCitation(book);
                            listViewmodel.Add(bookviewmodel);
                        }
                    }
                }
                return listViewmodel;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BookViewmodel>> GetBooksByAuthorTitle()
        {
            List<BookViewmodel> listViewmodel = new List<BookViewmodel>();
            List<BookDetails> Booklist = new List<BookDetails>(); try
            {
                Booklist = await bookstoreContext.BookDetails.FromSqlRaw($"GetListByAuthorthentitle").ToListAsync();
                if (Booklist != null && Booklist.Count > 0)
                {
                    //iterate booklist to get each book details and generate seperate citations
                    foreach (BookDetails book in Booklist)
                    {
                        if (book != null)
                        {
                            BookViewmodel bookviewmodel = new BookViewmodel();
                            BookDetails bookdetails = book;
                            bookviewmodel.MLACitation = GenerateMLACitation(book);
                            bookviewmodel.ChicagoCitation = GenerateChicagoCitation(book);
                            listViewmodel.Add(bookviewmodel);
                        }
                    }
                }
                return listViewmodel;
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
        public async Task<string> AddBooks(List<PostBookViewModel> ListPostBookViewModel)
        {
            try
            {
                string Result = string.Empty;
                Result = "Failed to Add Books";

                List<BookDetails> ListBooks = new List<BookDetails>();
                if (ListPostBookViewModel != null && ListPostBookViewModel.Count > 0)
                {
                    foreach (var book in ListPostBookViewModel)
                    {
                        if (book != null)
                        {
                            BookDetails newbook = new BookDetails();
                            newbook.AuthorFirstName = book.AuthorFirstName;
                            newbook.AuthorLastName = book.AuthorLastName;
                            newbook.TitleOfSource = book.TitleOfContainer;
                            newbook.Publisher = book.Publisher;
                            newbook.PublicationDate = book.PublicationDate;
                            newbook.Price = book.Price;
                            newbook.PageRange = book.PageRange;
                            newbook.Url = book.Url;
                            newbook.VolumeNo = book.VolumeNo;
                            ListBooks.Add(newbook);
                        }
                    }
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

        public string GenerateMLACitation(BookDetails book)
        {
            string Resultstring = string.Empty;

            try
            {
                //Mla format : Author(last,first),"Titleofsource",Titleofcontainer,publisher,publicationdate,volno+pagenumber.
                string authorLastName = string.IsNullOrEmpty(book.AuthorLastName)?"" : $"{book.AuthorLastName},";
                string authorFirstName = string.IsNullOrEmpty(book.AuthorFirstName)? "" : $"{book.AuthorFirstName}.";
                string titleOfSource = string.IsNullOrEmpty(book.TitleOfSource) ? "" : $"\"{book.TitleOfSource}\"";
                string titleOfContainer = string.IsNullOrEmpty(book.TitleOfContainer) ? "" : $"{book.TitleOfContainer},";
                string publisher = string.IsNullOrEmpty(book.Publisher) ? "" : $"{book.Publisher},";
                string publicationDate = book.PublicationDate.ToString("dd-MM-yyyy");
                 publicationDate = string.IsNullOrEmpty(publicationDate) ? "" : $"{book.PublicationDate},";
                string volumeNo = string.IsNullOrEmpty(book.VolumeNo) ? "" : $"{book.VolumeNo}. ";
                string pageRange = string.IsNullOrEmpty(book.PageRange) ? "" : $"{book.PageRange}.";



                //Resultstring = $"{authorLastName}, {authorFirstName}. \"{titleOfSource}\" {titleOfContainer}, {publisher}, {publicationDate}, {volumeNo} {pageRange}";
                // Construct the Resultstring without unnecessary separators
                //string resultString = $"{authorLastName}{(!string.IsNullOrEmpty(authorFirstName) ? ", " + authorFirstName : "")}. \"{titleOfSource}\"{(!string.IsNullOrEmpty(titleOfContainer) ? " " + titleOfContainer : "")}, {publisher}, {publicationDate}, {volumeNo}{pageRange}";
                Resultstring = $"{authorLastName}{authorFirstName}{titleOfSource}{titleOfContainer}{publisher}{publicationDate}{volumeNo}{pageRange}";

            }
            catch (Exception ex)
            {
               // throw ex;
            }
            return Resultstring;
        }
        public string GenerateChicagoCitation(BookDetails book)
        {
            string Resultstring = string.Empty;

            try
            {
                //ChicagoCitation format 
                string authorLastName = string.IsNullOrEmpty(book.AuthorLastName) ? "" : $"{book.AuthorLastName},";
                string authorFirstName = string.IsNullOrEmpty(book.AuthorFirstName) ? "" : $"{book.AuthorFirstName}.";
                //To get year from date
                string publicationYear = book.PublicationDate.ToString("yyyy");
                publicationYear = string.IsNullOrEmpty(publicationYear) ? "" : $"{publicationYear}.";
                string titleOfSource = string.IsNullOrEmpty(book.TitleOfSource) ? "" : $"\"{book.TitleOfSource}\"";
                string titleOfContainer = string.IsNullOrEmpty(book.TitleOfContainer) ? "" : $"{book.TitleOfContainer},";
                string publisher = string.IsNullOrEmpty(book.Publisher) ? "" : $"{book.Publisher},";
                string volumeNo = string.IsNullOrEmpty(book.VolumeNo) ? "" : $"{book.VolumeNo} ";
                //To get month from date
                string publicationMonth = book.PublicationDate.ToString("MMMM");
                publicationMonth = string.IsNullOrEmpty(publicationMonth) ? "" : $"({publicationMonth}):";
                string pageRange = string.IsNullOrEmpty(book.PageRange) ? "" : $"{book.PageRange}.";
                string url = string.IsNullOrEmpty(book.Url) ? "" : $"{book.Url}.";
                Resultstring = $"{authorLastName}{authorFirstName}{publicationYear}{titleOfSource}{titleOfContainer}{publisher}{volumeNo}{publicationMonth}{pageRange}{url}";


                // Resultstring =  book.AuthorLastName + ", " + book.AuthorFirstName + ".\"" + book.TitleOfSource + "\" " + book.TitleOfContainer + "," + book.Publisher + "," + book.PublicationDate + "," + book.VolumeNo + ". " + book.PageRange + ".";
            }
            catch (Exception ex)
            {
                // throw ex;
            }
            return Resultstring;
        }
    }
}
