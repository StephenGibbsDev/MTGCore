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

        public Dictionary<string, string> map(SearchFilter filter)
        {

            PropertyInfo[] properties = typeof(SearchFilterWithColours).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var name = property.Name;
                string value = null;

                //todo: find a better way to do this that is more extendable with any incoming type
                if (property.PropertyType == typeof(string))
                {
                    value = (string)property.GetValue(filter);
                }

                if (property.PropertyType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                {
                    var list = (List<string>)property.GetValue(filter);
                    value = String.Join(",", list.Select(x => x.ToString()).ToArray());
                }

                KeyValuePair<string, string> parameter = new KeyValuePair<string, string>(name.ToLower(), value);

                if (!string.IsNullOrEmpty(parameter.Value))
                    filterParameters.Add(parameter.Key, parameter.Value);
            }

            return filterParameters;
        }
    }
}

