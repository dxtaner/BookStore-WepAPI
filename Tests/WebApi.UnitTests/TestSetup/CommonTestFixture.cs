using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.UnitTests.TestSetup;

namespace TestSetup
{
    public class CommonTestFixture
    {
        public BookStoreDbContext Context { get; set; }
        public IMapper Mapper;

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase("BookStoreTestDB").Options;
            Context = new BookStoreDbContext(options);

            Context.Database.EnsureCreated();
            Context.AddBooks();
            Context.AddGenres();
            Context.AddAuthors();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
        }
    }
}