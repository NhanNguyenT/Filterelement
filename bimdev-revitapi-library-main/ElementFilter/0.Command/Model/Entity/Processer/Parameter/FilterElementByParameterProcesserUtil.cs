using Autodesk.Revit.DB;
using Model.Entity;
using Nancy.ViewEngines;
using SingleData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Utility
{
    public static class FilterElementByParameterProcesserUtil
    {
        public static void Test(this FilterElementByParameterProcesser q)
        {
            var allElements = q.AllElements;

            var firstElement = allElements.First();

            var parameters = firstElement.ParametersMap.Cast<Autodesk.Revit.DB.Parameter>();

            MessageBox.Show(parameters.CombineString(x => x.Definition.Name));
        }
        public static List<Model.Entity.FilterElementProcessorNS.Parameter> GetParameters(this FilterElementByParameterProcesser q)
        {
            var allElements = q.AllElements!;
            var parameters = new List<Parameter>();

            foreach (var element in allElements)
            {
                var elementParameters = element.ParametersMap.Cast<Autodesk.Revit.DB.Parameter>();
                foreach (var elementParameter in elementParameters)
                {
                    var parameterName = elementParameter.Definition.Name;
                    var parameter = parameters.FirstOrDefault(x => x.Name == parameterName);
                    if (parameter = null)
                    {
                        parameter = new Parameter { Name = parameterName };
                        parameters.Add(parameter);
                    }

                    var elementParameterValue = elementParameter.AsValueString();

                    var parameterValues = parameter.Values;
                    if (!parameterValues.Contains(elementParameterValue))
                    {
                        parameterValues.Add(elementParameterValue);
                    }
                }
            }
            return parameters;
        }
    }
}
