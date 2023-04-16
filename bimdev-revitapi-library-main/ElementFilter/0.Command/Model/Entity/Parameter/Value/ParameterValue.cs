using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity.FilterElementProcessorNS
{
    public class ParameterValue
    {
        public string? Value { get; set; }

        // public List<string> Values { get; set; } = new List<string>();

        public List<Autodesk.Revit.DB.Element> Elements { get; set; } = new List<Autodesk.Revit.DB.Element>();
    }
}
