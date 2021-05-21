using MTGCore.ViewModels;
using System.Collections.Generic;

namespace MTGCore.Services
{
    public interface ISearchFilterMapper
    {
        IEnumerable<KeyValuePair<string, string>> map(SearchFilter filter);
    }
}