// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Text;
using System.Threading.Tasks;
using SAO.SandBox;
using SAO.Security;
using SAO.GameObjects.Math;
using SAO.GameObjects.ServerObjects;

namespace SAO.GameObjects.Troops
{
    /// <summary>
    /// There is no Saber or Lancer in the MagicalTroops.
    /// </summary>
    public class MagicalTroop
    {
        /// <summary>
        /// But use this in each type, for separate their parameters.
        /// </summary>
        public const string InCharSeparator = "つ";
        public const string EndFileName = "_魔法戦士";
        //-----------------------------------
        public const uint BasicLevel = 1;
        //-----------------------------------
        /// <summary>
        /// The Basic Power in the BasicLevel.
        /// </summary>
        public static Unit BasicPower
        {
            get
            {
                return new Unit(0, 0, 100, 0);
            }
        }
        //-----------------------------------
        /// <summary>
        /// The count of Troops in each types,
        /// for example: mrwoto has 10K Saber, 100K Archer, etc...
        /// </summary>
        public Unit Count { get; set; }
        /// <summary>
        /// The level of Troops in each types,
        /// for example: mrwoto has Saber lvl12 (all of his Sabers should be the same level).
        /// </summary>
        public uint Level { get; set; }
        /// <summary>
        /// The Power of Troops in each types,
        /// for example: mrwoto's Sabers Power is 120K (all of the Sabers should have the same power).
        /// </summary>
        public Unit Power { get; set; }
        //-----------------------------------
        //-----------------------------------
        private MagicalTroop(Unit countValue, uint levelValue, Unit powerValue)
        {
            Count = countValue;
            Level = levelValue;
            Power = powerValue;
        }
        //-----------------------------------
        //-----------------------------------
        //-----------------------------------
        public static MagicalTroop ParseToMagicalTroop(StrongString theString)
        {
            StrongString[] myStrings = theString.Split(InCharSeparator);
            MagicalTroop myMagicalTroop = new MagicalTroop(Unit.ConvertToUnit(myStrings[0]),
                myStrings[1].ToUInt16(), Unit.ConvertToUnit(myStrings[2]));
            return myMagicalTroop;
        }
        public static MagicalTroop GetBasicMagicalTroop()
        {
            return new MagicalTroop(Unit.GetBasicUnit(), BasicLevel,
                BasicPower);
        }
        public static StrongString GetForServer(MagicalTroop troops)
        {
            StrongString myString =
                troops.Count.GetForServer() + InCharSeparator +
                troops.Level.ToString() + InCharSeparator +
                troops.Power.GetForServer() + InCharSeparator;
            return myString;
        }
        /// <summary>
        /// Create player's troops for the first time.
        /// </summary>
        /// <param name="troops"></param>
        public async static Task<DataBaseDataChangedInfo> CreatePlayerMagicalTroops(MagicalTroop troops)

        {
            StrongString myString = GetForServer(troops);
            string targetFile = ThereIsServer.GameObjects.MyProfile.Username +
                EndFileName;
            return await ThereIsServer.Actions.CreateFile(ThereIsServer.ServersInfo.MyServers[0],
                targetFile,
                new DataBaseCreation("CreatingThePlayerSoldiers", QString.Parse(myString)));
        }
        /// <summary>
        /// Save Player's troops(Update them to the server.)
        /// </summary>
        /// <param name="troops"></param>
        public async static void SavePlayerTroops(MagicalTroop troops)
        {
            StrongString myString = GetForServer(troops);
            string targetFile = ThereIsServer.GameObjects.MyProfile.Username +
                EndFileName;
            var ExistingFile =
                    await ThereIsServer.Actions.GetAllContentsByRef(ThereIsServer.ServersInfo.MyServers[0], 
                targetFile);
            if (ExistingFile.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return;
            }
            await ThereIsServer.Actions.UpdateFile(ThereIsServer.ServersInfo.MyServers[0], 
                        targetFile,
                        new DataBaseUpdateRequest("By SAO", QString.Parse(myString), ExistingFile.Sha));
        }
        public async static Task<MagicalTroop> LoadPlayerMagicalTroop()
        {
            string targetFile = ThereIsServer.GameObjects.MyProfile.Username +
                EndFileName;
            var existingFile =
                    await ThereIsServer.Actions.GetAllContentsByRef(ThereIsServer.ServersInfo.MyServers[0], 
                targetFile);
            if (existingFile.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return null;
            }
            return ParseToMagicalTroop(existingFile.Decode());
        }
        //-----------------------------------
        public StrongString GetForServer()
        {
            StrongString myString =
                Count.GetForServer() + InCharSeparator +
                Level.ToString() + InCharSeparator +
                Power.GetForServer() + InCharSeparator;
            return myString;
        }
        //-----------------------------------
    }
}
