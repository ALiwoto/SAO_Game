// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using SAO.Security;

namespace SAO.LoadingService
{
    /// <summary>
    /// This Class Should Serialize in 
    /// <see cref="Constants.ThereIsConstants.Path.ServerConfiguration_File_Name"/>
    /// </summary>
    [Serializable]
    public class ServerConfig
    {
        //-------------------------------------------------
        #region Constant's Region
        public const string CharSeparator = "ｗ";
        #endregion
        //-------------------------------------------------
        #region Properties Region
        /// <summary>
        /// the server status.
        /// The Code is: 1.
        /// </summary>
        public ServerStatus ServerStatus { get; }
        /// <summary>
        /// the last version of the game.
        /// The Code is: 2.
        /// </summary>
        public GameVersion LastVersion { get; }
        /// <summary>
        /// the update info path, which is necessary for updating the game.
        /// The Code is: 3.
        /// </summary>
        public StrongString UpdateInfoPath { get; }
        /// <summary>
        /// It should be setted when the server is on Break or on Updating mode.
        /// the Accessing date.
        /// The Code is: 4.
        /// </summary>
        public StrongString AccessDate { get; }
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        /// <summary>
        /// this class should Serialize in 
        /// <see cref="Constants.ThereIsConstants.Path.ServerConfiguration_File_Name"/> and
        /// this file should download from the Server in the start of Game.
        /// </summary>
        /// <param name="theCurrentStatusValue"></param>
        /// <param name="theLastVersionValue"></param>
        /// <param name="updateInfoPathValue"></param>
        public ServerConfig(ServerStatus theCurrentStatusValue, GameVersion theLastVersionValue,
            StrongString updateInfoPathValue, StrongString accessDateValue)
        {
            ServerStatus    = theCurrentStatusValue;
            LastVersion     = theLastVersionValue;
            UpdateInfoPath  = updateInfoPathValue;
            AccessDate      = accessDateValue;
        }
        #endregion
        //-------------------------------------------------
        public StrongString GetForServer()
        {
            StrongString myString = 
                ((int)ServerStatus).ToString()  + CharSeparator + // 1
                LastVersion.GetForServer()      + CharSeparator + // 2
                UpdateInfoPath                  + CharSeparator + // 3
                AccessDate                      + CharSeparator;  // 4
            return myString;
        }
        //-------------------------------------------------
    }
}
