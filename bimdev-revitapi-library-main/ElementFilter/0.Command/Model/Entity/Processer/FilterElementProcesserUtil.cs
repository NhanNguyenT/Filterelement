using Autodesk.Revit.DB;
using Model.Entity;
using SingleData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility 
{
    public static class FilterElementProcesserUtil
    {
    private static RevitData revitData => RevitData.Instance;
    public static View GetView(this FilterElementProcessor q)
        {
            return revitData.Document.ActiveView;
        }

        public static List<Element> GetAllElements(this FilterElementProcessor q)
        {
            var doc = revitData.Document;
            var view = q.View;
            return new FilteredElementCollector(doc, view.Id).WhereElementIsNotElementType().
                Where(x => x.Category !=null).ToList();
        }
        public static List<Category> GetAllCategories(this FilterElementProcessor q)
        {
            return q.AllElements.Select(x=>x.Category).Distinct(new CategoryComparer()).ToList();
        }

    public static IEnumerable<Element> GetFilteredElements(this FilterElementProcessor q)
        {

            var CatergoryIds = q.CategoryIds!;

            return q.AllElements.Where(x => CatergoryIds.Contains(x.Category.Id));
        }

    }
}
