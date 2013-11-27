using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brevitee.Data
{
    public class LiteralFilterToken : FilterToken
    {
        public LiteralFilterToken(string value)
        {
            this.Value = value;
        }

        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}
