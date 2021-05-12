// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Text;
using System.Threading.Tasks;
using SAO.Constants;
using SAO.SandBox;
using SAO.Security;
using SAO.GameObjects.Math;
using SAO.GameObjects.ServerObjects;

namespace SAO.GameObjects.Kingdoms
{
    public sealed class LevelRankings : Rankings
    {
        /// <summary>
        /// File name in the server.
        /// </summary>
        public const string LevelRankingsFileName = "レウェローランキング.Sao";
        /// <summary>
        /// Value is Kizu, use in server.
        /// </summary>
        public const string OutCharSeparator = "傷";
        /// <summary>
        /// The Value is Ame, use in server to separate the players' Info from each other.
        /// </summary>
        public const string InCharSeparator = "雨";
        /// <summary>
        /// This is 50.
        /// 0b110010
        /// </summary>
        public const uint MAXIMUM_RANKS = 0b110010;
        //-----------------------------------------
        //----------------------
        /// <summary>
        /// 
        /// The Check Code is 1.
        /// </summary>
        public StrongString[] PlayerNames { get; private set; }
        /// <summary>
        /// 
        /// The Check Code is 2.
        /// </summary>
        public uint[] PlayerLevels { get; private set; }
        /// <summary>
        /// 
        /// The Check Code is 3.
        /// </summary>
        public Unit[] PlayerTotalExp { get; private set; }
        //----------------------
        /// <summary>
        /// Set in the game, not in the server.
        /// </summary>
        public KingdomInfo Kingdom { get; set; }
        //----------------------
        //-----------------------------------------
        private LevelRankings()
        {
            RankingsMode = RankingsMode.LevelRankings;
        }
        //-----------------------------------------
        //-----------------------------------------
        public static async Task<DataBaseDataChangedInfo> CreateLevelRankings(KingdomInfo kingdom)
        {
            LevelRankings levelRankings = new LevelRankings()
            {
                Kingdom = kingdom,
                PlayerNames = new StrongString[MAXIMUM_RANKS],
                PlayerLevels = new uint[MAXIMUM_RANKS],
                PlayerTotalExp = new Unit[MAXIMUM_RANKS],
            };
            for(int i = 0; i < MAXIMUM_RANKS; i++)
            {
                levelRankings.PlayerNames[i] = ThereIsConstants.Path.NotSet;
                levelRankings.PlayerLevels[i] = 0;
                levelRankings.PlayerTotalExp[i] = Unit.GetBasicUnit();
            }
            return await ThereIsServer.Actions.CreateFile(ThereIsServer.ServersInfo.MyServers[kingdom.Index],
                LevelRankingsFileName, new DataBaseCreation("Created_BY_SAO", 
                QString.Parse(levelRankings.GetForServer())));
        }
        public static async Task<LevelRankings> GetLevelRankings(KingdomInfo kingdom)
        {
            LevelRankings levelRankings = new LevelRankings()
            {
                Kingdom = kingdom,
                PlayerNames = new StrongString[MAXIMUM_RANKS],
                PlayerLevels = new uint[MAXIMUM_RANKS],
                PlayerTotalExp = new Unit[MAXIMUM_RANKS],
            };
            var Existing = await ThereIsServer.Actions.GetAllContentsByRef(
                ThereIsServer.ServersInfo.MyServers[kingdom.Index], LevelRankingsFileName);
            await Task.Delay(100);
            if (Existing.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return null;
            }
            StrongString[] myStrings = Existing.Decode().Split(OutCharSeparator);
            StrongString[] InStrings;
            for(int i = 0; i < MAXIMUM_RANKS; i++)
            {
                InStrings = myStrings[i].Split(InCharSeparator);
                levelRankings.PlayerNames[i] = InStrings[0];
                levelRankings.PlayerLevels[i] = InStrings[1].ToUInt16();
                levelRankings.PlayerTotalExp[i] = Unit.ConvertToUnit(InStrings[2]);
            }

            return levelRankings;
        }
        public StrongString GetForServer()
        {
            StrongString myString = "";
            for(int i = 0; i < MAXIMUM_RANKS; i++)
            {
                myString += 
                    PlayerNames[i]                      + InCharSeparator + // 1
                    PlayerLevels[i].ToString()          + InCharSeparator + // 2
                    PlayerTotalExp[i].GetForServer()    + InCharSeparator + // 3
                    OutCharSeparator;
            }
            return myString;
        }
        public async Task<DataBaseDataChangedInfo> UpdateLevelRankings()
        {
            var Existing = await ThereIsServer.Actions.GetAllContentsByRef(
                ThereIsServer.ServersInfo.MyServers[Kingdom.Index], LevelRankingsFileName);
            if (Existing.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return null; // don't set ServerSettings.IsWaitingForServerChecking = false;
            }
            return await ThereIsServer.Actions.UpdateFile(
                ThereIsServer.ServersInfo.MyServers[Kingdom.Index], LevelRankingsFileName,
                new DataBaseUpdateRequest("BY SAO_Game", QString.Parse(GetForServer()), Existing[0].Sha));
        }
        //-----------------------------------------
    }
}
