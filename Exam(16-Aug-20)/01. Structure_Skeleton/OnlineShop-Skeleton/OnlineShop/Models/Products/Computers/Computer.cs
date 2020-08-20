using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) :
            base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();

        public void AddComponent(IComponent component)
        {
            if (this.Components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.Peripherals.Any(p => p.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (this.Components.Count == 0 || this.Components.All(c => c.GetType().Name != componentType))
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            IComponent toRemove = this.Components.First(c => c.GetType().Name == componentType);
            this.components.Remove(toRemove);
            return toRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (this.Peripherals.Count == 0 || this.Peripherals.All(p => p.GetType().Name != peripheralType))
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            IPeripheral toRemove = this.Peripherals.First(p => p.GetType().Name == peripheralType);
            this.peripherals.Remove(toRemove);
            return toRemove;
        }

        public override double OverallPerformance 
        {
            get
            {
                if (this.Components.Count > 0)
                {
                    double perf = this.Components.Sum(c => c.OverallPerformance);
                    return base.OverallPerformance + (perf / this.Components.Count);
                }

                return base.OverallPerformance;
            }
        }

        public override decimal Price 
        {
            get 
            {
                decimal componetsPr = this.Components.Sum(c => c.Price);
                decimal periferialPr = this.Peripherals.Sum(p => p.Price);
                return base.Price + componetsPr + periferialPr;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({this.Components.Count}):");
            foreach (var component in this.Components)
            {
                sb.AppendLine($"  {component}");
            }

            double avgPerf = this.Peripherals.Sum(p => p.OverallPerformance) / this.Peripherals.Count;
            string avgPerfStr = this.Peripherals.Count == 0 ? $"{this.Peripherals.Count:F2}" : $"{avgPerf:F2}";
            sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({avgPerfStr}):");
            foreach (var peripherial in this.Peripherals)
            {
                sb.AppendLine($"  {peripherial}");
            }

            return sb.ToString().Trim();
        }
    }
}