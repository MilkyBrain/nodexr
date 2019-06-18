﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace RegexNodes.Shared.NodeTypes
{
    public class OrNode : Node, INode
    {
        public override string Title => "Or";

        public override List<INodeInput> NodeInputs
        {
            get
            {
                return new List<INodeInput> { Inputs };
            }
        }

        protected InputCollection Inputs { get; set; } = new InputCollection() { Title = "Inputs" };

        public override string GetValue()
        {
            //string result = $"(?:{Input1.GetValue()}|{Input2.GetValue()})";
            string result = @"(?:";
            //foreach(InputProcedural input in Inputs.Inputs)
            //{
            //    result += input.GetValue();
            //}
            result += String.Join("|", from input
                                       in Inputs.Inputs
                                       select input.GetValue());
            result += ")";
            CachedValue = result;
            return result;
        }
    }
}