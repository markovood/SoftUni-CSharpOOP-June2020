using System.Collections.Generic;
using System.Linq;

using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private List<IDriver> models;

        public DriverRepository()
        {
            this.models = new List<IDriver>();
        }

        public void Add(IDriver model) => this.models.Add(model);

        public IReadOnlyCollection<IDriver> GetAll() => this.models.AsReadOnly();

        public IDriver GetByName(string name) => this.models.FirstOrDefault(m => m.Name == name);

        public bool Remove(IDriver model) => this.models.Remove(model);
    }
}
