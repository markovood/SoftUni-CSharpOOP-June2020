using System;
using System.Linq;
using System.Text;

using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Repositories;
using SantaWorkshop.Utilities.Messages;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private DwarfRepository dwarves;
        private PresentRepository presents;

        public Controller()
        {
            this.dwarves = new DwarfRepository();
            this.presents = new PresentRepository();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf = null;
            switch (dwarfType)
            {
                case "HappyDwarf":
                    dwarf = new HappyDwarf(dwarfName);
                    this.dwarves.Add(dwarf);
                    break;
                case "SleepyDwarf":
                    dwarf = new SleepyDwarf(dwarfName);
                    this.dwarves.Add(dwarf);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType); // TODO: . or no
            }

            return string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            var dwarf = this.dwarves.FindByName(dwarfName);
            if (dwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }

            IInstrument instrument = new Instrument(power);
            dwarf.AddInstrument(instrument);

            return string.Format(OutputMessages.InstrumentAdded, power, dwarfName);
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            IPresent present = new Present(presentName, energyRequired);
            this.presents.Add(present);

            return string.Format(OutputMessages.PresentAdded, presentName);
        }

        public string CraftPresent(string presentName)
        {
            var present = this.presents.FindByName(presentName);

            var suitable = this.dwarves.Models.Where(d => d.Energy >= 50).ToList();
            if (suitable.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }

            var workshop = new Workshop();


            foreach (var dwarf in suitable)
            {
                workshop.Craft(present, dwarf);
                if (dwarf.Energy == 0)
                {
                    this.dwarves.Remove(dwarf);
                }
            }

            if (present.IsDone())
            {
                return string.Format(OutputMessages.PresentIsDone, presentName);
            }
            else
            {
                return string.Format(OutputMessages.PresentIsNotDone, presentName);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            int crafted = this.presents.Models.Where(p => p.IsDone()).Count();

            sb.AppendLine($"{crafted} presents are done!");
            sb.AppendLine($"Dwarfs info:");
            foreach (var dwarf in this.dwarves.Models)
            {
                sb.AppendLine($"Name: {dwarf.Name}");
                sb.AppendLine($"Energy: {dwarf.Energy}");
                sb.AppendLine($"Instruments: {dwarf.Instruments.Count(i => i.IsBroken() == false)} not broken left");
            }

            return sb.ToString().Trim();
        }
    }
}
