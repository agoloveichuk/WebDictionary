using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebDictionary.Data
{
    public sealed class WebDictionaryContext : DbContext
    {
        public WebDictionaryContext(DbContextOptions<WebDictionaryContext> options)
            : base(options)
        {
        }

        public DbSet<Dictionary> Dictionary { get; set; }
        public DbSet<Word> Word { get; set; }
        public DbSet<Phrase> Phrase { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dictionary>()
                .HasMany(c => c.Words)
                .WithOne(p => p.Dictionary)
                .HasForeignKey(p => p.DictionaryId);

            modelBuilder.Entity<Dictionary>()
                .HasMany(c => c.Phrases)
                .WithOne(p => p.Dictionary)
                .HasForeignKey(p => p.DictionaryId);

            // seeding some data 
            modelBuilder.Entity<Dictionary>().HasData(
                new Dictionary { DictionaryId = 1, Name = "Animals", Description = "Animals" },
                new Dictionary { DictionaryId = 2, Name = "Days", Description = "Days" },
                new Dictionary { DictionaryId = 3, Name = "Food", Description = "Food" }
                );

            modelBuilder.Entity<Word>().HasData(
                new Word { WordId = 1, DictionaryId = 1, EnWord = "Cat", UaWord = "Кіт", Definition = "Animal Description" },
                new Word { WordId = 2, DictionaryId = 1, EnWord = "Dog", UaWord = "Собака", Definition = "Animal Description" },
                new Word { WordId = 3, DictionaryId = 1, EnWord = "Pig", UaWord = "Свиня", Definition = "Animal Description" },
                new Word { WordId = 4, DictionaryId = 1, EnWord = "Mouse", UaWord = "Миша", Definition = "Animal Description" }
                );

            modelBuilder.Entity<Phrase>().HasData(
                new Phrase { PhraseId = 1, DictionaryId = 1, EnPhrase = "Mantis Shrimp", UaPhrase = "Креветка богомол", Definition = "Animal Phrase Description" },
                new Phrase { PhraseId = 2, DictionaryId = 1, EnPhrase = "Wolf Fish", UaPhrase = "Риба Вовк", Definition = "Animal Phrase Description" }
                );
        }
    }
}
