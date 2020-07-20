using System;

using Logger.Layouts.Contracts;

namespace Logger.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Format
        {
            get
            {
                return "<log>" + Environment.NewLine +
                    "\t<date>{0}</date>" + Environment.NewLine +
                    "\t<level>{1}</level>" + Environment.NewLine +
                    "\t<message>{2}</message>" + Environment.NewLine +
                    "</log>";
            }
        }
    }
}