using MTGCore.Services.Exceptions;
using MTGCore.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;

namespace MTGCore.Services
{
    public class SearchFilterMapper : ISearchFilterMapper
    {

        private readonly QueryBuilder _builder = new QueryBuilder();

        public string map(SearchFilter filters) => ParseQueryStringFromObject(filters);

        private void ParseQueryStringFromPropertyInfo(PropertyInfo obj, object parentObj)
        {
            switch (obj.PropertyType)
            {
                case var str when str == typeof(string):
                    _builder.TryAdd(obj.Name, (string)obj.GetValue(parentObj));
                    break;
                case var strList when typeof(IEnumerable).IsAssignableFrom(strList):
                    _builder.TryAdd(obj.Name, (IEnumerable<string>)obj.GetValue(parentObj));
                    break;
            }
        }

        private string ParseQueryStringFromObject(object obj)
        {
            var propertyInfo = obj.GetType().GetProperties();
            propertyInfo.OrderBy(x=> x.GetCustomAttribute<FilterAttribute>() == null ? 99 : x.GetCustomAttribute<FilterAttribute>().FieldOrder).ToList().ForEach(m => ParseQueryStringFromPropertyInfo(m, obj));
            return _builder.ToQueryString().Value;
        }

    }

}

