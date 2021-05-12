// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using Octokit;
using SAO.Security;
using SAO.Constants;

namespace SAO.GameObjects.ServerObjects
{
    public class DataBaseClient : GitHubClient
    {
        //-------------------------------------------------
        #region Constructor's Region
        public DataBaseClient(DataBaseHeader header, QString cridental) :
            base(header)
        {
            Credentials = new DataBaseCredential(cridental);
            SetRequestTimeout(ThereIsConstants.AppSettings.DefaultDataBaseTimeOut);
        }
        #endregion
        //-------------------------------------------------
    }
}
