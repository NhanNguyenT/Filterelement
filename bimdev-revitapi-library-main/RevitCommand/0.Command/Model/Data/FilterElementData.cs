using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;
using Model.Form;

namespace Model.Data
{
    class FilterElementData
    {
        //singleton
        private static FilterElementData? instance;
        public static FilterElementData Instance => instance ??= new FilterElementData();

        //form
        public FilterElementProcesser_Form? form;
        public FilterElementProcesser_Form Form => form ??= new FilterElementProcesser_Form{DataContext = this};
        //data
        private FilterElementProcessor? processor;
        public FilterElementProcessor Processor => processor ??= new FilterElementProcessor();

    }
}
