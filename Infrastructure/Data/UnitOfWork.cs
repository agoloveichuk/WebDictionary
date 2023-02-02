using Domain.Entities;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using WebDictionary.Data;

namespace Infrastructure.Data
{
    public class UnitOfWork : IDisposable
    {
        private WebDictionaryContext context;
        private GenericRepository<Dictionary>? dictionaryRepository;
        private GenericRepository<Word>? wordRepository;
        //private GenericRepository<Phrase> courseRepository;
        public UnitOfWork()
        {
            var contextOptions = new DbContextOptionsBuilder<WebDictionaryContext>()
                .UseSqlServer("Data Source=(local);Initial Catalog=WebDictionary; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                .Options;
            context = new WebDictionaryContext(contextOptions);
        }


        public GenericRepository<Dictionary> DictionaryRepository
        {
            get
            {

                if (dictionaryRepository == null)
                {
                    dictionaryRepository = new GenericRepository<Dictionary>(context);
                }
                return dictionaryRepository;
            }
        }

        public GenericRepository<Word> WordRepository
        {
            get
            {

                if (wordRepository == null)
                {
                    wordRepository = new GenericRepository<Word>(context);
                }
                return wordRepository;
            }
        }


        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
