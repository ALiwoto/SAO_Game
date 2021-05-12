// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Text;
using System.Threading.Tasks;
using WotoProvider.Enums;
using SAO.SandBox;
using SAO.Security;
using SAO.GameObjects.Math;
using SAO.GameObjects.ServerObjects;

namespace SAO.GameObjects.GameResources
{
    public class PlayerResources
    {
        //-------------------------------------------------
        #region Constants Region
        public const string EndFileName = "_リショーセズ";
        public const string InCharSeparator = "歌";
        public const string OutCharSeparator = "花";
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public Resources Resources { get; set; }
        #endregion
        //-------------------------------------------------
        #region Constructors Region
        private PlayerResources(Resources resourcesValue)
        {
            Resources = resourcesValue;
        }
        public Unit this[PlayerResourceType type]
        {
            get
            {
                return Resources[type];
            }
        }
        #endregion
        //-------------------------------------------------
        #region static Methods Region
        /// <summary>
        /// Parse the string value to Troops in the following order:
        /// <see cref="Saber"/>, <see cref="Archer"/>, <see cref="Lancer"/>, <see cref="Assassin"/>
        /// </summary>
        /// <param name="theString"></param>
        /// <returns></returns>
        public static PlayerResources ParseToPlayerResources(StrongString theString)
        {
            StrongString[] myStrings = theString.Split(OutCharSeparator);
            PlayerResources playerResources = 
                new PlayerResources(Resources.ParseToResources(myStrings[0]));
            return playerResources;
        }
        public static PlayerResources GetBasicPlayerResources()
        {
            return new PlayerResources(Resources.GetBasicResources());
        }
        /// <summary>
        /// Get the string value of these Troops for the Server DataBase.
        /// </summary>
        /// <param name="myTroops"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        /// <returns></returns>
        public static StrongString GetForServer(PlayerResources myPlayerResources)
        {
            if (myPlayerResources == null)
            {
                throw new ArgumentNullException();
            }
            return myPlayerResources.GetForServer();
        }
        /// <summary>
        /// Create player's troops for the first time.
        /// </summary>
        /// <param name="troops"></param>
        public static async Task<DataBaseDataChangedInfo> CreatePlayerResources(PlayerResources playerResources)

        {
            StrongString myString = GetForServer(playerResources);
            string targetFile = ThereIsServer.GameObjects.MyProfile.Username +
                EndFileName;
            return 
                await ThereIsServer.Actions.CreateFile(ThereIsServer.ServersInfo.MyServers[0], targetFile,
                        new DataBaseCreation("CreatingThePlayerResources", 
                        QString.Parse(myString, false)));
        }
        /// <summary>
        /// Save Player's troops(Update them to the server.)
        /// </summary>
        /// <param name="troops"></param>
        public static async Task<DataBaseDataChangedInfo> SavePlayerResources(PlayerResources playerResources)
        {
            StrongString myString = GetForServer(playerResources);
            string targetFile = ThereIsServer.GameObjects.MyProfile.Username +
                EndFileName;
            var ExistingFile =
                    await ThereIsServer.Actions.GetAllContentsByRef(ThereIsServer.ServersInfo.MyServers[0],
                targetFile);
            if (ExistingFile == null || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return null; // don't set ServerSettings.IsWaitingForServerChecking = false;
            }
            var minNow = ExistingFile[0];
            return await ThereIsServer.Actions.UpdateFile(ThereIsServer.ServersInfo.MyServers[0],
                targetFile,
                new DataBaseUpdateRequest("By SAO", 
                QString.Parse(myString, false), minNow.Sha));
        }
        public static async Task<PlayerResources> LoadPlayerResources()
        {
            string targetFile = ThereIsServer.GameObjects.MyProfile.Username +
                EndFileName;
            var existingFile =
                    await ThereIsServer.Actions.GetAllContentsByRef(ThereIsServer.ServersInfo.MyServers[0], 
                targetFile);
            if (existingFile == null || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return null; // don't set ServerSettings.IsWaitingForServerChecking = false;
            }
            var minNow = existingFile[0];
            StrongString CurrentText;
            if (minNow.EncodedContent != null)
            {
                CurrentText = 
                    Encoding.UTF8.GetString(Convert.FromBase64String(minNow.EncodedContent.GetValue()));
            }
            else
            {
                CurrentText = minNow.Content.GetStrong();
            }
            return ParseToPlayerResources(CurrentText);
        }
        #endregion
        //-------------------------------------------------
        #region protected Methods Region
        protected virtual StrongString GetForServer()
        {
            StrongString myString =
                Resources.GetForServer() + OutCharSeparator;
            return myString;
        }
        #endregion
        //-------------------------------------------------
    }
}
