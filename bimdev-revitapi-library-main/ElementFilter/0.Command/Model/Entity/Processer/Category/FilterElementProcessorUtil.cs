using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Events;
using Model.Entity;
using SingleData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Utility 
{
    public static class FilterElementProcessorUtil
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

        //Filter Element
         public static IEnumerable<Element> GetFilterElementsByCategory(this FilterElementProcessor q)
        {

            var CatergoryIds = q.CategoryIds!;
            return q.AllElements.Where(x => CatergoryIds.Contains(x.Category.Id));
        }

        public static void RefeshGetFilterElementsByCategory(this FilterElementProcessor q)
        {
            q.FilterElementsByCategory = null;
        }

        //Parameter Proceser
        public static FilterElementByParameterProcessor GetParameterProcesser(this FilterElementProcessor q)
        {
            return new FilterElementByParameterProcessor
            {
                AllElements= q.FilterElementsByCategory
            };   
        }
        public static void RefreshParameterProcessor(this FilterElementProcessor q)
        {
           q.ParameterProcesser = null;

            //MessageBox.Show("parameter dc refresh");
        }
    }
}
