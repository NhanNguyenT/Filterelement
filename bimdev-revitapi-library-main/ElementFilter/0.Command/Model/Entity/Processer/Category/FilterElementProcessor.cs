﻿using Autodesk.Revit.DB;
using Model.ViewModel;
using SingleData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Model.Entity
{
    public class FilterElementProcessor : NotifyClass
    {
        //thuoc tinh : viet hoa chu dau
        //gia tri mac dinh cua view la Activeview
        private View? view;
        public View View
        {
            get => view ??= this.GetView();
            set => view = value;
        }

        private List<Element>? allElements;
        public List<Element> AllElements => allElements ??= this.GetAllElements();

        private List<Category>? allcategories;

        public List<Category> AllCategories => allcategories ??= this.GetAllCategories();

        //public List<Category> Categories { get; set; } = new List<Category>();
        public Dict<Category> Categories { get; set; } = new Dict<Category>();

        public List<ElementId> CategoryIds => this.Categories.Select(x => x.Id).ToList();

        private IEnumerable<Element>? filterElementsByCategory;
        public IEnumerable<Element> FilterElementsByCategory
        {
            get => filterElementsByCategory ??= this.GetFilterElementsByCategory();
            set
            {
                filterElementsByCategory = value;
                this.RefreshParameterProcessor();
            }
        }
        private FilterElementByParameterProcessor? parameterProcessor;
        public FilterElementByParameterProcessor ParameterProcessor
        {
            get => parameterProcessor ??= this.GetParameterProcessor();
            set
            {
                parameterProcessor = value;
                OnPropertyChanged();
            }
        }
    }
}
