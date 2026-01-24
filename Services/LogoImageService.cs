using FR_Groups_websites.Interface;
using FR_Groups_websites.Models;

namespace FR_Groups_websites.Services
{
    public class LogoImageService : ILogoImageService
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
            if (id <= 0)
                throw new ArgumentException("Invalid ID");

            return await _repo.GetByIdAsync(id);
        }

        public async Task AddAsync(LogoImage logoImage)
        {
            if (logoImage == null)
                throw new ArgumentNullException(nameof(logoImage));

            if (string.IsNullOrWhiteSpace(logoImage.ImagePath))
                throw new ArgumentException("ImagePath is required");

            await _repo.AddAsync(logoImage);
        }

        public async Task UpdateAsync(LogoImage logoImage)
        {
            if (logoImage == null || logoImage.ID <= 0)
                throw new ArgumentException("Invalid logo data");

            if (string.IsNullOrWhiteSpace(logoImage.ImagePath))
                throw new ArgumentException("ImagePath is required");

            var existing = await _repo.GetByIdAsync(logoImage.ID);
            if (existing == null)
                throw new KeyNotFoundException("Logo not found");

            await _repo.UpdateAsync(logoImage);
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid ID");

            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException("Logo not found");

            await _repo.DeleteAsync(id);
        }
    }
}
