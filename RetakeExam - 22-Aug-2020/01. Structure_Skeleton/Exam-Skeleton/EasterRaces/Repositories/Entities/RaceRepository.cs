using System.Collections.Generic;
using System.Linq;

using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;

        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public void Add(IRace model) => this.models.Add(model);

        public IReadOnlyCollection<IRace> GetAll() => this.models.AsReadOnly();

        public IRace GetByName(string name) => this.models.FirstOrDefault(m => m.Name == name);

        public bool Remove(IRace model) => this.models.Remove(model);
    }
}
