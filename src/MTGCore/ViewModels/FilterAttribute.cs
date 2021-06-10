using System;

namespace MTGCore.ViewModels
{
    public class FilterAttribute : Attribute
    {
        public FilterAttribute(int order)
        {
            FieldOrder = order;
        }
        public int FieldOrder { get; set; }
    }
}
