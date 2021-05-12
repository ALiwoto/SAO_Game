// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Threading.Tasks;
using Octokit;
using SAO.SandBox;
using SAO.Security;
using SAO.Constants;
using SAO.GameObjects.Players;
using SAO.GameObjects.ServerObjects;

namespace SAO.GameObjects.Kingdoms
{
    /// <summary>
    /// King                1
    /// Queen               2
    /// MinisterOfWar       3
    /// MinisterOfWealth    4
    /// Hierarch            5
    /// Guardians' Chief    6
    /// Clown               7
    /// </summary>
    public class KingdomThrone
    {
        //-------------------------------------------------
        #region Constants Region
        /// <summary>
        /// KingdomThrone File Name for getting and saving it from and to in server.
        /// </summary>
        public const string KingdomThroneFileName = "ソロノ";
        /// <summary>
        /// The Value is: Gunsotsu
        /// </summary>
        public const string CharSeparator = "軍卒";
        /// <summary>
        /// The MAXIMUM of the Throne Position count.
        /// This is 7.
        /// </summary>
        public const int MAXIMUM_POSITION = 0b111;
        #endregion
        //-------------------------------------------------
        #region Server Properties Region
        public StrongString King_PlayerName { get; set; }
        public StrongString Queen_PlayerName { get; set; }
        public StrongString MinisterOfWar_PlayerName { get; set; }
        public StrongString MinisterOfWealth_PlayerName { get; set; }
        public StrongString Hierarch_PlayerName { get; set; }
        public StrongString Guardians_Chief_PlayerName { get; set; }
        public StrongString Clown_PlayerName { get; set; }
        #endregion
        //-------------------------------------------------
        #region Offline Properties Region
        public KingdomInfo Kingdom { get; set; }
        #endregion
        //-------------------------------------------------
        #region Constructor
        private KingdomThrone()
        {
            ;
        }
        #endregion
        //-------------------------------------------------
        #region Offline Methods Region
        public StrongString GetForServer()
        {
            StrongString myString = 
                King_PlayerName                 + CharSeparator + // 1
                Queen_PlayerName                + CharSeparator + // 2
                MinisterOfWar_PlayerName        + CharSeparator + // 3
                MinisterOfWealth_PlayerName     + CharSeparator + // 4
                Hierarch_PlayerName             + CharSeparator + // 5
                Guardians_Chief_PlayerName      + CharSeparator + // 6
                Clown_PlayerName                + CharSeparator;  // 7
            return myString;
        }
        /// <summary>
        /// NOTICE: The object of <see cref="PlayerInfo"/>
        /// that I will return, does not exists in the server,
        /// please do it yourself.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public PlayerInfo GetPlayerInfo(ThronePositions position)
        {
            PlayerInfo player = null;
            switch (position)
            {
                case ThronePositions.King:
                    player = PlayerInfo.GetPlayerInfo(King_PlayerName);
                    break;
                case ThronePositions.Queen:
                    player = PlayerInfo.GetPlayerInfo(Queen_PlayerName);
                    break;
                case ThronePositions.MinisterOfWar:
                    player = PlayerInfo.GetPlayerInfo(MinisterOfWar_PlayerName);
                    break;
                case ThronePositions.MinisterOfWealth:
                    player = PlayerInfo.GetPlayerInfo(MinisterOfWealth_PlayerName);
                    break;
                case ThronePositions.Hierarch:
                    player = PlayerInfo.GetPlayerInfo(Hierarch_PlayerName);
                    break;
                case ThronePositions.Guardians_Chief:
                    player = PlayerInfo.GetPlayerInfo(Guardians_Chief_PlayerName);
                    break;
                case ThronePositions.Clown:
                    player = PlayerInfo.GetPlayerInfo(Clown_PlayerName);
                    break;
                default:
                    break;
            }
            return player;
        }
        #endregion
        //-------------------------------------------------
        #region Online and non-static Methods region
        public async Task<RepositoryContentChangeSet> UpdateKingdomThrone()
        {
            return await ThereIsServer.Actions.CreateFile(ThereIsServer.ServersInfo.MyServers[Kingdom.Index],
                KingdomThroneFileName, new DataBaseCreation("BY SAO_Game", QString.Parse(GetForServer())));
        }
        #endregion
        //-------------------------------------------------
        #region static mathods region
        //These methods are server and online working
        //so you should use await keyword for them.
        public static async Task<RepositoryContentChangeSet> CreateKingdomThrone(KingdomInfo kingdomInfo)
        {
            KingdomThrone kingdomThrone = new KingdomThrone()
            {
                King_PlayerName             = ThereIsConstants.Path.NotSet, // 1
                Queen_PlayerName            = ThereIsConstants.Path.NotSet, // 2
                MinisterOfWar_PlayerName    = ThereIsConstants.Path.NotSet, // 3
                MinisterOfWealth_PlayerName = ThereIsConstants.Path.NotSet, // 4
                Hierarch_PlayerName         = ThereIsConstants.Path.NotSet, // 5
                Guardians_Chief_PlayerName  = ThereIsConstants.Path.NotSet, // 6
                Clown_PlayerName            = ThereIsConstants.Path.NotSet, // 7
            };

            return await ThereIsServer.Actions.CreateFile(ThereIsServer.ServersInfo.MyServers[kingdomInfo.Index],
                KingdomThroneFileName, new DataBaseCreation("BY SAO_Game", 
                QString.Parse(kingdomThrone.GetForServer())));

        }
        public static async Task<KingdomThrone> GetKingdomThrone(KingdomInfo kingdom)
        {
            KingdomThrone kingdomThrone = new KingdomThrone();
            var Existing =
                await ThereIsServer.Actions.GetAllContentsByRef(ThereIsServer.ServersInfo.MyServers[kingdom.Index],
                KingdomThroneFileName);
            if (Existing.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return null;
            }
            StrongString[] myStrings = Existing.Decode().Split(CharSeparator);
            kingdomThrone.King_PlayerName = myStrings[0];
            kingdomThrone.Queen_PlayerName = myStrings[1];
            kingdomThrone.MinisterOfWar_PlayerName = myStrings[2];
            kingdomThrone.MinisterOfWealth_PlayerName = myStrings[3];
            kingdomThrone.Hierarch_PlayerName = myStrings[4];
            kingdomThrone.Guardians_Chief_PlayerName = myStrings[5];
            kingdomThrone.Clown_PlayerName = myStrings[6];
            return kingdomThrone;
        }
        #endregion
        //-------------------------------------------------
    }
}
