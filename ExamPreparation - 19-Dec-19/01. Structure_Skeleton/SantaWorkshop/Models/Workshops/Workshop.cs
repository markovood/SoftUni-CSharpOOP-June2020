
using System.Linq;

using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Craft(IPresent present, IDwarf dwarf)
        {
            if (dwarf.Energy > 0 && dwarf.Instruments.Any(i => i.IsBroken() == false))
            {
                while (true)
                {
                    if (present.IsDone() || dwarf.Energy <= 0 || dwarf.Instruments.All(i => i.IsBroken()))
                    {
                        break;
                    }

                    present.GetCrafted();
                    dwarf.Work();
                }
            }
        }
    }
}
