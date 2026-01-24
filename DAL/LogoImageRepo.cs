using FR_Groups_websites.DB;
using FR_Groups_websites.Interface;
using FR_Groups_websites.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FR_Groups_websites.DAL
{
    public class LogoImageRepo : ILogoImageRepo
    {
        private readonly AppDbContext _context;

        public LogoImageRepo(AppDbContext context)
        {
            _context = context;   
        }

        public async Task<IEnumerable<LogoImage>> GetAllAsync()
        {
            return await _context.logoImages
           .FromSqlRaw("SELECT * FROM T_LogoImages ORDER BY ID DESC")
           .ToListAsync();
        }



        public async Task<LogoImage?> GetByIdAsync(int id)
        {
            return await _context.logoImages
            .FromSqlRaw("SELECT * FROM T_LogoImages WHERE ID = {0}", id)
            .FirstOrDefaultAsync();
        }

        public async Task AddAsync(LogoImage logoImage)
        {
            await _context.Database.ExecuteSqlRawAsync(
            "INSERT INTO T_LogoImages (ImagePath) VALUES ({0})",
            logoImage.ImagePath
            );
        }


        public async Task UpdateAsync(LogoImage logoImage)
        {
            await _context.Database.ExecuteSqlRawAsync(
            "UPDATE T_LogoImages SET ImagePath = {0} WHERE ID = {1}",
            logoImage.ImagePath,
            logoImage.ID
            );
        }


        public async Task DeleteAsync(int id)
        {
            await _context.Database.ExecuteSqlRawAsync(
            "DELETE FROM T_LogoImages WHERE ID = {0}", id
            );
        }
    }
}
