// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Text;
using System.Threading.Tasks;
using SAO.SandBox;
using SAO.Constants;
using SAO.Security;
using SAO.GameObjects.Math;
using SAO.GameObjects.ServerObjects;

namespace SAO.GameObjects.Kingdoms
{
    public class PowerRankings : Rankings
    {
        //-------------------------------------------------
        #region Constants Region
        /// <summary>
        /// File name in the server.
        /// </summary>
        public const string PowerRankingsFileName = "ぱウェーランキング.Sao";
        /// <summary>
        /// The Value is Kizu, use in server to separate the players from each other.
        /// </summary>
        public const string OutCharSeparator = "傷";
        /// <summary>
        /// The Value is Ame, use in server to separate the players' Info from each other.
        /// </summary>
        public const string InCharSeparator = "雨";
        /// <summary>
        /// This is 50.
        /// </summary>
        public const uint MAXIMUM_RANKS = 0b110010;
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public StrongString[] PlayerNames { get; set; }
        public Unit[] PlayerPowers { get; set; }
        public KingdomInfo Kingdom { get; set; }
        #endregion
        //-------------------------------------------------
        #region Constructors Region
        private PowerRankings()
        {
            RankingsMode = RankingsMode.PowerRankings;
        }
        #endregion
        //-------------------------------------------------
        #region Ordinary Methods Region
        public StrongString GetForServer()
        {
            StrongString myString = string.Empty;
            for (int i = 0; i < MAXIMUM_RANKS; i++)
            {
                myString += 
                    PlayerNames[i]                  + InCharSeparator + // 1
                    PlayerPowers[i].GetForServer()  + InCharSeparator + // 2
                    OutCharSeparator;
            }
            return myString;
        }
        public async Task<DataBaseDataChangedInfo> UpdatePowerRankings()
        {
            var Existing = await ThereIsServer.Actions.GetAllContentsByRef(
                ThereIsServer.ServersInfo.MyServers[Kingdom.Index], PowerRankingsFileName);
            if (Existing.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return null; // don't set ServerSettings.IsWaitingForServerChecking = false;
            }
            return await ThereIsServer.Actions.UpdateFile(
                ThereIsServer.ServersInfo.MyServers[Kingdom.Index], PowerRankingsFileName,
                new DataBaseUpdateRequest("BY SAO_Game", QString.Parse(GetForServer()), 
                Existing.Sha));
        }
        #endregion
        //-------------------------------------------------
        #region static Methods Region
        public static async Task<DataBaseDataChangedInfo> CreatePowerRankings(KingdomInfo kingdom)
        {
            PowerRankings powerRankings = new PowerRankings()
            {
                Kingdom = kingdom,
                PlayerNames = new StrongString[MAXIMUM_RANKS],
                PlayerPowers = new Unit[MAXIMUM_RANKS]
            };
            for (int i = 0; i < MAXIMUM_RANKS; i++)
            {
                powerRankings.PlayerNames[i] = ThereIsConstants.Path.NotSet;
                powerRankings.PlayerPowers[i] = Unit.GetBasicUnit();
            }
            return await ThereIsServer.Actions.CreateFile(ThereIsServer.ServersInfo.MyServers[kingdom.Index],
                PowerRankingsFileName, new DataBaseCreation("Created_BY_SAO", 
                QString.Parse(powerRankings.GetForServer())));

            
        }
        public static async Task<PowerRankings> GetPowerRankings(KingdomInfo kingdom)
        {
            PowerRankings powerRankings = new PowerRankings()
            {
                Kingdom = kingdom,
                PlayerNames = new StrongString[MAXIMUM_RANKS],
                PlayerPowers = new Unit[MAXIMUM_RANKS]
            };
            var Existing = await ThereIsServer.Actions.GetAllContentsByRef(
                ThereIsServer.ServersInfo.MyServers[kingdom.Index], PowerRankingsFileName);
            if (Existing.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return null; // don't set ServerSettings.IsWaitingForServerChecking = false;
            }
            StrongString[] myStrings = Existing.Decode().Split(OutCharSeparator);
            StrongString[] InStrings;
            for (int i = 0; i < MAXIMUM_RANKS; i++)
            {
                InStrings = myStrings[i].Split(InCharSeparator);
                powerRankings.PlayerNames[i] = InStrings[0];
                powerRankings.PlayerPowers[i] = Unit.ConvertToUnit(InStrings[1]);
            }
            return powerRankings;
        }
        #endregion
        //-------------------------------------------------
    }
}
