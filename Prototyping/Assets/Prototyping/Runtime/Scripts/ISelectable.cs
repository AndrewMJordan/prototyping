using System;

namespace Andtech.Prototyping
{

    public interface ISelectable
    {

        #region EVENT
        event EventHandler RequestedSelect;
        event EventHandler RequestedDeselect;
        #endregion
    }
}
