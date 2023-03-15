using Autodesk.Revit.DB;
using SingleData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class FilterElementProcessor
    {
        public View? view { get; set; }

        public List<BuiltInCategory>? BuiltInCategories { get; set; }

        private IEnumerable<Element>? filterElements;
        public IEnumerable<Element> FilteredElements
        {
            get
            {
                if (this.filterElements == null)
                {

                    var doc = RevitData.Instance.Document;
                    var view = this.view!;
                    var builtInCatergories = this.BuiltInCategories!;

                    var elements = new FilteredElementCollector(doc, view.Id).WhereElementIsNotElementType().ToList()
                        //bo qua null
                        .Where(x => x.Category != null);

                    this.filterElements = elements.Where(x => builtInCatergories.Contains((BuiltInCategory)x.Category.Id.IntegerValue));
                }
                return this.FilteredElements;
                
            }
        }
    }
}
