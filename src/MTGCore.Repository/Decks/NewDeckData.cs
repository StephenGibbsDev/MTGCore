namespace MTGCore.Repository.Decks
{
    public class NewDeckData
    {
        public NewDeckData(string title, string description)
        {
            Title = title;
            Description = description;
        }
        
        public string Title { get; }
        public string Description { get; }
    }
}