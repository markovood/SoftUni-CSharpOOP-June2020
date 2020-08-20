using System;
using System.Collections.Generic;
using System.Linq;

using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Repositories.Contracts;

namespace SantaWorkshop.Repositories
{
    public class DwarfRepository : IRepository<IDwarf>
    {
        private List<IDwarf> dwarves;

        public DwarfRepository()
        {
            this.dwarves = new List<IDwarf>();
        }

        public IReadOnlyCollection<IDwarf> Models => this.dwarves.AsReadOnly();

        public void Add(IDwarf model) => this.dwarves.Add(model);

        public IDwarf FindByName(string name) => this.dwarves.FirstOrDefault(d => d.Name == name);

        public bool Remove(IDwarf model) => this.dwarves.Remove(model);
    }
}
