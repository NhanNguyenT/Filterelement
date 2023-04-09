using Autodesk.Revit.DB;
using SingleData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Model.Entity
{
    public class FilterElementByParameterProcesser
    {
       public IEnumerable<Element>? AllElements { get;set; }

        private List<FilterElementProcessorNS.Parameter>? parameters;
        public List<FilterElementProcessorNS.Parameter> Parameters =>this.parameters ??= this.GetParameters();
    }
}
