﻿using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Utility;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.UI;
using Model.Entity;
using Model.Form;
using Model.Data;

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

            var catergories = elements.Select(x => x.Category).Distinct(new CategoryComparer());

            var inputBuiltInCategories = new List<BuiltInCategory>
            { BuiltInCategory.OST_StructuralFraming, BuiltInCategory.OST_StructuralColumns };

            var filteredElements = elements.Where(x => inputBuiltInCategories.Contains((BuiltInCategory)x .Category.Id.IntegerValue));
            //TaskDialog.Show("Revit", catergories.CombineString(x=> x.Name));

            sel.SetElement(filteredElements);

           //sel.SetElement(elements);


        }
    }
 

    [Transaction(TransactionMode.Manual)]
    public class TestCommand3 : RevitCommand
    {
        private FilterElementData data => FilterElementData.Instance;

        public override void Execute()
        {
            var form = data.Form;   
            form.Show();

        }
    }
    [Transaction(TransactionMode.Manual)]
    public class TestCommand4 : RevitCommand
    {
  
        public override void Execute()
        {
            var categoryProcesser = new FilterElementProcessor();
            categoryProcesser.Categories = new Dict<Category>() { categoryProcesser.AllCategories[0] };

            var parameterProcesser = new FilterElementByParameterProcessor
            {
                AllElements = categoryProcesser.FilterElementsByCategory
            };
            parameterProcesser.Test();
        }
    }

}
