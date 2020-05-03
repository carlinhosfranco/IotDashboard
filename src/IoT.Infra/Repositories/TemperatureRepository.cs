using System.Collections.Generic;
using System.Threading.Tasks;
using IoT.Domain.Entities;
using IoT.Domain.Repositories;
using IoT.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IoT.Infra.Repositories
{
    public class TemperatureRepository : ITemperatureRepository
    {
        private readonly AppDbContext _dbContext;

        public TemperatureRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Temperature>> GetAllTemperatures()
        {
            var temps = await _dbContext.Temperatures.ToListAsync();

            return temps;
        }

        public async Task SaveTemperature(Temperature temp)
        {
            await _dbContext.Temperatures.AddAsync(temp);            
        }
    }
}