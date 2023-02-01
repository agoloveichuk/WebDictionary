using Domain.Entities;

namespace Infrastructure.Data.Repositories
{
    public interface IWordRepository
    {
        Task<IEnumerable<Word>> GetAllByDictionaryIdAsync(int dictionaryId);
    }
}