using System;
using System.Linq;
using System.Reflection;

using Logger.Layouts.Contracts;

namespace Logger.Factories
{
    public class LayoutFactory
    {
        public ILayout GetLayout(string type)
        {
            var layoutType = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Name == type).FirstOrDefault();
            if (layoutType == null)
            {
                throw new ArgumentException("Invalid layout type");
            }

            return (ILayout)Activator.CreateInstance(layoutType);
        }
    }
}