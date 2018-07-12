using System.Collections;
using Options.Core;

namespace Options.Forms.Adapters
{
    public interface IOptionsListViewDelegate
    {
        void UpdateOptionState(Option selectedOption);
        void UpdateSource(IEnumerable source);
    }
}