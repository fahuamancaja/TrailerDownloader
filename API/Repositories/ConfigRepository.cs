using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TrailerDownloader.Context;
using TrailerDownloader.Models;
using TrailerDownloader.Repositories.Interfaces;

namespace TrailerDownloader.Repositories
{
    public class ConfigRepository : IConfigRepository
    {
        private readonly MovieDbContext _context;

        public ConfigRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<Config> GetConfigAsync()
        {
            return await _context.Config.FirstOrDefaultAsync();
        }

        public async Task<int> SaveConfigAsync(string path)
        {
            await RemoveDataFromDatabase();
            await _context.Config.AddAsync(new Config { BaseMediaPath = path });
            return await _context.SaveChangesAsync();
        }

        public async Task RemoveDataFromDatabase()
        {
            var config = await _context.Config.FirstOrDefaultAsync();
            var movies = await _context.Movie.ToListAsync();
            if(config != null || movies != null)
            {
                _context.Config.Remove(config);
                
                foreach (var movie in movies)
                    {
                        _context.Movie.Remove(movie);
                    }
            }
        }
    }
}
