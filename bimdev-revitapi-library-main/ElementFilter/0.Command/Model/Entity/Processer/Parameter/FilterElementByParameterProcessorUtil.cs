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
    public static class FilterElementByParameterProcessorUtil
    {
        public static void Test(this FilterElementByParameterProcessor q)
        {
            var allElements = q.AllElements;

            var firstElement = allElements.First();

            var parameters = firstElement.ParametersMap.Cast<Parameter>();

            MessageBox.Show(parameters.CombineString(x => x.Definition.Name));
        }
        public static List<Model.Entity.FilterElementProcessorNS.Parameter> GetParameters(this FilterElementByParameterProcessor q)
        {
            var allElements = q.AllElements!;
            var parameters = new List<Model.Entity.FilterElementProcessorNS.Parameter>();

            foreach (var element in allElements)
            {
                var elementParameters = element.ParametersMap.Cast<Autodesk.Revit.DB.Parameter>();
                foreach (var elementParameter in elementParameters)
                {
                    var parameterName = elementParameter.Definition.Name;
                    var parameter = parameters.FirstOrDefault(x => x.Name == parameterName);
                    if (parameter == null)
                    {
                        parameter = new Model.Entity.FilterElementProcessorNS.Parameter{ Name = parameterName };
                        parameters.Add(parameter);
                    }

                    var elementParameterValue = elementParameter.AsValueString();

                    var parameterValues = parameter.Values;
                    var parameterValue = parameterValues.FirstOrDefault(x => x.Value== elementParameterValue);
                    if(parameterValue == null)
                    {
                        parameterValue = new Model.Entity.FilterElementProcessorNS.ParameterValue
                        {
                            Value = elementParameterValue,
                        };
                        parameter.Values.Add(parameterValue);
                    }

                    parameterValue.Elements.Add(element);
                    //if (!parameterValues.Contains(elementParameterValue))
                    //{
                    //    parameterValues.Add(elementParameterValue);
                    //}
                }
            }
            return parameters;
        }
    }
}
