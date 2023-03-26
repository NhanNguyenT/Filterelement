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
    public class FilterElementProcessor
    {
        //thuoc tinh : viet hoa chu dau
        //gia tri mac dinh cua view la Activeview
        private View? view;
        public View View 
        { 
            get => view ??=this.GetView(); 
            set => view = value;
        }

        private List<Element>? allElements;
        public List<Element> AllElements => allElements ??= this.GetAllElements();

        private List<Category>? allcategories;

        public List<Category> AllCatergories => allcategories ??= this.GetAllCategories();

        public List<BuiltInCategory>? BuiltInCategories { get; set; }

        private IEnumerable<Element>? filterElements;
        public IEnumerable<Element> FilteredElements => filterElements ??= this.GetFilteredElements();
    
    }
}
