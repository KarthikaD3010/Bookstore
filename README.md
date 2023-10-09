# Bookstore

    The Bookstore project is created for the purpose of read and save book information. This includes apis to read book details from database, save the same and calculate total price of books.

    APIs:
         https://localhost:44337/api/book/getbooksbypublisher  
         This api will give you a sorted list of books, which are sorted by publisher,author and then title.

         https://localhost:44337/api/book/getbooksbyauthor
         This api will give you a sorted list of books, which are sorted by author and then title.

         https://localhost:44337/api/book/gettotalprice
        This api will give you the sum of price of all books present in database.

        https://localhost:44337/api/book/AddBooks
        This api will let us add a book or list of books in database.

   Find the Postman collection for reference:
   Postmancollection/Bookstore.postman_collection.json  

   Find the Script for Database tables and data
   script/script.sql 


## install

    Download or clone the project.
    Open project in Visual studio.
    I used Visualstudio 2019, .net core3.1.
    Run database script in MsSql server
    start the program and then test the apis using give api links.
    








