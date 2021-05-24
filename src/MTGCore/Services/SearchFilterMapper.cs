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

        public Dictionary<string, string> map(SearchFilter filter)
        {

            PropertyInfo[] properties = typeof(SearchFilterWithColours).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Type type = property.PropertyType;

                var methodInfo = typeof(SearchFilterMapper).GetMethod(nameof(SearchFilterMapper.ValueToString));
                var genericMethodInfo = methodInfo.MakeGenericMethod(type);
                var result = genericMethodInfo.Invoke(null, new object[] { property, filter });

                var pair = new KeyValuePair<string, string>(property.Name.ToLower(), (string)result);

                if (!string.IsNullOrEmpty(pair.Value))
                    filterParameters.Add(pair.Key, pair.Value);
            }

            return filterParameters;
        }

        public static string ValueToString<T>(PropertyInfo property, SearchFilter filter)
        {
            var type = typeof(T);

            if (type == typeof(string))
            {
                return (string)property.GetValue(filter);
            }
            else if (typeof(IEnumerable).IsAssignableFrom(type) && type != typeof(string))
            {
                var list = (List<string>)property.GetValue(filter);
                return String.Join(",", list.Select(x => x.ToString()).ToArray());
            } else
            {
                throw new SearchFilterMapperException($"the type of {type.Name} is not supported in {nameof(SearchFilterMapper)}");
            }

        }

    }
}

