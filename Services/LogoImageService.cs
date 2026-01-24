using FR_Groups_websites.Interface;
using FR_Groups_websites.Models;

namespace FR_Groups_websites.Services
{
    public class LogoImageService: ILogoImageService
    {

        private readonly ILogoImageRepo _repo;  

        public LogoImageService(ILogoImageRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<LogoImage>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<LogoImage?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task AddAsync(LogoImage logoImage)
        {
            await _repo.AddAsync(logoImage);
        }


        public async Task UpdateAsync(LogoImage logoImage)
        {
            await _repo.UpdateAsync(logoImage);
        }


        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
