using MTGCore.Services.Exceptions;
using MTGCore.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MTGCore.Services
{
    public class SearchFilterMapper : ISearchFilterMapper
    {
        private Dictionary<string, string> filterParameters = new Dictionary<string, string>();

        private Dictionary<Type, Delegate> typeProcessorMap = new Dictionary<Type, Delegate>() 
        {
            { typeof(List<string>), new Func<PropertyInfo,SearchFilter,string>((x,y) => {return StringListResolver.ValueToString(x,y);}) },
            { typeof(string), new Func<PropertyInfo,SearchFilter,string>((x,y) => {return StringResolver.ValueToString(x,y);}) }
        };

        public Dictionary<string, string> map(SearchFilter filter)
        {

            var properties = typeof(SearchFilterWithColours).GetProperties().Where(val => val.GetValue(filter,null) != null).ToList();

            foreach (PropertyInfo property in properties)
            {
                Type type = property.PropertyType;

                var result = typeProcessorMap[type].DynamicInvoke(property, filter);

                var pair = new KeyValuePair<string, string>(property.Name.ToLower(), (string)result);

                if (!string.IsNullOrEmpty(pair.Value))
                    filterParameters.Add(pair.Key, pair.Value);
            }

            return filterParameters;
        }
    }


    public class StringResolver 
    {
        public static string ValueToString(PropertyInfo property, SearchFilter filter)
        {
            return (string)property.GetValue(filter);
        }
    }

    public class StringListResolver 
    {
        public static string ValueToString(PropertyInfo property, SearchFilter filter)
        {
            var list = (List<string>)property.GetValue(filter);
            return String.Join(",", list.Select(x => x.ToString()).ToArray());
        }
    }
}

