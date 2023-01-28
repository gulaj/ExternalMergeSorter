namespace Generator.Api
{
    public interface IDictionaryService
    {
        Task<IEnumerable<string>> GetAllWords();
    }
}