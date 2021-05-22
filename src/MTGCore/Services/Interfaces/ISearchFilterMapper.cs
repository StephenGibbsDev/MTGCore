using MTGCore.ViewModels;
using System.Collections.Generic;

namespace MTGCore.Services
{
    public interface ISearchFilterMapper
    {
        Dictionary<string, string> map(SearchFilter filter);
    }
}