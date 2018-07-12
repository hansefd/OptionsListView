namespace Options.Core
{
    public class GroupedOptions : Options
    {
        public string GroupTitle { get; }

        public GroupedOptions(string groupTitle, bool multipleSelection = false) : base(multipleSelection)
        {
            GroupTitle = groupTitle;
        }
    }
}