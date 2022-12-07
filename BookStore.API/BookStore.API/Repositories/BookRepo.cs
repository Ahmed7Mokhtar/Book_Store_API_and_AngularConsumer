using AutoMapper;
using BookStore.API.Data;
using BookStore.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class BookRepo : IBookRepo
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookRepo(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            //var books = await _context.Books.Select(x => new BookModel
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description,
            //}).ToListAsync();

            //return books;

            var books = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(books);
        }

        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            //var book = await _context.Books.Where(b => b.Id == bookId).Select(b => new BookModel
            //{
            //    Id = b.Id,
            //    Title = b.Title,
            //    Description = b.Description,
            //}).FirstOrDefaultAsync();

            //return book;

            var book = await _context.Books.FindAsync(bookId);

            return _mapper.Map<BookModel>(book);
        }

        public async Task<int> AddNewBookAsync(AddBookModel bookModel)
        {
            var book = new Books
            {
                Title = bookModel.Title,
                Description = bookModel.Description,
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        public async Task UpdateBookAsync(int bookId, AddBookModel bookModel)
        {
            //var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId);
            //if(book != null)
            //{
            //    book.Title = bookModel.Title;
            //    book.Description = bookModel.Description;

            //    await _context.SaveChangesAsync();
            //}

            var book = new Books
            {
                Id=bookId,
                Title = bookModel.Title,
                Description = bookModel.Description,
            };

            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel)
        {
            var book = await _context.Books.FindAsync(bookId);
            if(book != null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(int bookId)
        {
            var book = new Books() { Id = bookId };

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
