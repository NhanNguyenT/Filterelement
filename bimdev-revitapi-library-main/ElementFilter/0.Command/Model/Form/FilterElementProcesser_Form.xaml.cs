using Autodesk.Revit.DB;
using Model.Data;
using SingleData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Utility;

namespace Model.Form
{
    /// <summary>
    /// Interaction logic for PM_ProjectUC.xaml
    /// </summary>
    public partial class FilterElementProcesser_Form : System.Windows.Window
    {
        private FilterElementData data => FilterElementData.Instance;

        private RevitData revitData => RevitData.Instance;

        public FilterElementProcesser_Form()
        {
            InitializeComponent();
        }

        private void select_Clicked(object sender, RoutedEventArgs e)
        {
            var sel = revitData.Selection;

            var procesor = data.Processor;
            procesor.RefeshGetFilterElementsByCategory();

            sel.SetElement(procesor.FilterElementsByCategory);
        }
    }
}
