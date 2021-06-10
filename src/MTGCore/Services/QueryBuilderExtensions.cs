using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTGCore.Services
{
    public static class QueryBuilderExtensions
    {
        public static void TryAdd(this QueryBuilder builder, string key, string value)
        {
            if (value != null)
            {
                builder.Add(key.ToLower(), value);
            }
        }

        public static void TryAdd(this QueryBuilder builder, string key, IEnumerable<string> values)
        {
            if (values != null)
            {
                var csv = string.Join(",", values);
                TryAdd(builder, key.ToLower(), csv);
            }
        }
    }
}
