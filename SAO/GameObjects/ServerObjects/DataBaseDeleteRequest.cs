// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using Octokit;
using SAO.Security;

namespace SAO.GameObjects.ServerObjects
{
    public class DataBaseDeleteRequest : DeleteFileRequest
    {
        //-------------------------------------------------
        #region Constructors Region
        public DataBaseDeleteRequest(StrongString theMessage, StrongString theSha) :
            base(theMessage.GetValue(), theSha.GetValue())
        {
            // do nothing here ... (for now)
        }
        #endregion
        //-------------------------------------------------
    }
}
