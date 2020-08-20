using System.Collections.Generic;
using System.Linq;

using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories.Contracts;

namespace SantaWorkshop.Repositories
{
    public class PresentRepository : IRepository<IPresent>
    {
        private List<IPresent> presents;

        public PresentRepository()
        {
            this.presents = new List<IPresent>();
        }

        public IReadOnlyCollection<IPresent> Models => this.presents.AsReadOnly();

        public void Add(IPresent model) => this.presents.Add(model);

        public IPresent FindByName(string name) => this.presents.FirstOrDefault(p => p.Name == name);

        public bool Remove(IPresent model) => this.presents.Remove(model);
    }
}