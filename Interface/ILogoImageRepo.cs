using FR_Groups_websites.Models;

namespace FR_Groups_websites.Interface
{
    public interface ILogoImageRepo
    {
        Task<IEnumerable<LogoImage>> GetAllAsync();
        Task<LogoImage?> GetByIdAsync(int id);
        Task AddAsync(LogoImage logoImage);
        Task UpdateAsync(LogoImage logoImage);
        Task DeleteAsync(int id);

    }
}
