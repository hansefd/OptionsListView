namespace Options.Core
{
    public class GroupOptions : Options
    {
        public string GroupTitle { get; }

        public GroupOptions(string groupTitle, bool multipleSelection = false) : base(multipleSelection)
        {
            GroupTitle = groupTitle;
        }
    }
}