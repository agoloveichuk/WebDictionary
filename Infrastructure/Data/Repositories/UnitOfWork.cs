using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDictionary.Data;

namespace Infrastructure.Data.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private WebDictionaryContext context;
        private GenericRepository<Dictionary>? dictionaryRepository;
        //private GenericRepository<Word> courseRepository;
        //private GenericRepository<Phrase> courseRepository;
        public UnitOfWork()
        {
            var contextOptions = new DbContextOptionsBuilder<WebDictionaryContext>()
                .UseSqlServer("Data Source=(local);Initial Catalog=WebDictionary; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                .Options;
            this.context = new WebDictionaryContext(contextOptions);
        }


        public GenericRepository<Dictionary> DictionaryRepository
        {
            get
            {

                if (this.dictionaryRepository == null)
                {
                    this.dictionaryRepository = new GenericRepository<Dictionary>(context);
                }
                return dictionaryRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
