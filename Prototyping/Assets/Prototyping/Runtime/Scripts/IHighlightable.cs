using System;

namespace Andtech.Prototyping
{

    public interface IHighlightable
    {

        #region EVENT
        event EventHandler RequestedHighlight;
        event EventHandler RequestedDehighlight;
        #endregion
    }
}
