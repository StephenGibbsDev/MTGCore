using MTGCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MTGCore.Services
{
    public class SearchFilterMapper : ISearchFilterMapper
    {

        public IEnumerable<KeyValuePair<string,string>> map(SearchFilter filter)
        {
            var filterParameters = new List<KeyValuePair<string, string>>();

            PropertyInfo[] properties = typeof(SearchFilter).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var name = property.Name;
                var value = (string)property.GetValue(filter);

                KeyValuePair<string,string> parameter = new KeyValuePair<string, string>(name.ToLower(),value);
                if (!String.IsNullOrEmpty(value))
                    filterParameters.Add(parameter);

            }

            return filterParameters;
        }
    }
}
