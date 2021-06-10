using MTGCore.ViewModels;
using System.Collections.Generic;

namespace MTGCore.Services
{
    public interface ISearchFilterMapper
    {
        public string map(SearchFilter filters);
    }
}