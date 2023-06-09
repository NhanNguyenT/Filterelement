﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity.FilterElementProcessorNS
{
    public class Parameter
    {
        public string? Name { get; set; }

        //public List<string> Values { get; set; } = new List<string>();

        //public List<Autodesk.Revit.DB.Element> Elements { get; set; } = new List<Autodesk.Revit.DB.Element>();

        public List<ParameterValue> Values { get; set; } = new List<ParameterValue>();

        public ParameterValue? SelectedValue { get; set; }
    }
}
