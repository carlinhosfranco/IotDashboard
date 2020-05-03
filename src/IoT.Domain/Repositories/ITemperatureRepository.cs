using System.Collections.Generic;
using System.Threading.Tasks;
using IoT.Domain.Entities;

namespace IoT.Domain.Repositories
{
    public interface ITemperatureRepository
    {
        Task<IList<Temperature>> GetAllTemperatures();
        Task SaveTemperature(Temperature temp);
    }
}