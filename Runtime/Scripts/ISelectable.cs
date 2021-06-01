/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

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