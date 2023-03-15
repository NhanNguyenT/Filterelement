using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Utility;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.UI;
using Model.Entity;

namespace Model.RevitCommand
{
    [Transaction(TransactionMode.Manual)]
    public class TestCommand : RevitCommand
    {
        public override void Execute()
        {
            //Input : View,BuiltCategories
            //Output : FilterElement

            var elements = new FilteredElementCollector(doc, doc.ActiveView.Id).WhereElementIsNotElementType().ToList()
                .Where(x => x.Category != null);

            var catergories = elements.Select(x => x.Category).Distinct(new Categorycomparer());

            var inputBuiltInCategories = new List<BuiltInCategory>
            { BuiltInCategory.OST_StructuralFraming, BuiltInCategory.OST_StructuralColumns };

            var filteredElements = elements.Where(x => inputBuiltInCategories.Contains((BuiltInCategory)x .Category.Id.IntegerValue));
            //TaskDialog.Show("Revit", catergories.CombineString(x=> x.Name));

            sel.SetElement(filteredElements);

           //sel.SetElement(elements);


        }
    }
    [Transaction(TransactionMode.Manual)]
    public class TestCommand2 : RevitCommand
    {
       
        public override void Execute()
        {

            var processor = new FilterElementProcessor
            {
                view = doc.ActiveView,
                BuiltInCategories = new List<BuiltInCategory>
            { BuiltInCategory.OST_StructuralFraming, BuiltInCategory.OST_StructuralColumns }
               
            };
            var filterElements = processor.FilteredElements;

            sel.SetElement(filterElements);

        }
    }

    public class Categorycomparer : IEqualityComparer<Category>
    {
        public bool Equals(Category x, Category y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Category obj)
        {
            return obj.Id.IntegerValue;
        }
    }
}