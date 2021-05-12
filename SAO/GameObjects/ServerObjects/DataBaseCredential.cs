// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using Octokit;
using SAO.Security;

namespace SAO.GameObjects.ServerObjects
{
    class DataBaseCredential : Credentials
    {
        //-------------------------------------------------
        #region Constructor's Region
        public DataBaseCredential(QString value) :
            base(value.GetValue())
        {
            // do nothing here, (for now) ...
        }
        #endregion
        //-------------------------------------------------
    }
}
