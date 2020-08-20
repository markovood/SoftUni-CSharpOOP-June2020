using System;
using System.Collections.Generic;
using System.Linq;

using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Utilities.Messages;

namespace SantaWorkshop.Models.Dwarfs
{
    public abstract class Dwarf : IDwarf
    {
        private string name;
        private int energy;
        private List<IInstrument> instruments;

        protected Dwarf(string name, int energy)
        {
            this.instruments = new List<IInstrument>();

            this.Name = name;
            this.Energy = energy;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDwarfName);
                }

                this.name = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            protected set
            {
                if (value < 0)
                {
                    this.energy = 0;
                }
                else
                {
                    this.energy = value;
                }
            }
        }
        public ICollection<IInstrument> Instruments => this.instruments.AsReadOnly();

        public void AddInstrument(IInstrument instrument)
        {
            this.instruments.Add(instrument);
        }

        public virtual void Work()
        {
            this.Energy -= 10;
            var notBrokenInstrument = this.instruments.FirstOrDefault(i => i.IsBroken() == false);
            if (notBrokenInstrument != null)
            {
                notBrokenInstrument.Use();
            }
        }
    }
}
