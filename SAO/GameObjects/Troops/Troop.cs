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
    /// There is 4 types of Troops:
    /// Saber, Archer, Lancer, Assassin.
    /// NOTICE: Please do the Parsing in order...
    /// <see cref="Saber"/>, <see cref="Archer"/>, <see cref="Lancer"/>, <see cref="Assassin"/>
    /// </summary>
    public abstract partial class Troop
    {
        //-----------------------------------
        /// <summary>
        /// Use this to separate the heroes type from each other.
        /// </summary>
        public const string OutCharSeparator = "よ";
        /// <summary>
        /// But use this in each type, for separate their parameters.
        /// </summary>
        public const string InCharSeparator = "つ";
        public const string EndFileName = "_菟ループす";
        //-----------------------------------
        public const uint BasicLevel = 1;
        //-----------------------------------
        /// <summary>
        /// The Basic Power in the level1.
        /// </summary>
        public static Unit BasicPower 
        { 
            get 
            {
                return new Unit(0, 0, 0, 20);
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
        /// <summary>
        /// Parse the string value to Troops in the following order:
        /// <see cref="Saber"/>, <see cref="Archer"/>, <see cref="Lancer"/>, <see cref="Assassin"/>
        /// </summary>
        /// <param name="theString"></param>
        /// <returns></returns>
        public static Troop[] ParseToTroops(StrongString theString)
        {
            Troop[] troops = new Troop[4]; //There is 4 types of Troop.
            StrongString[] myStrings = theString.Split(OutCharSeparator);
            troops[0] = Saber.ParseToSaber(myStrings[0]);
            troops[1] = Archer.ParseToArcher(myStrings[1]);
            troops[2] = Lancer.ParseToLancer(myStrings[2]);
            troops[3] = Assassin.ParseToAssassin(myStrings[3]);
            return troops;
        }
        public static Troop[] GetBasicTroops()
        {
            Troop[] troops = new Troop[4];
            troops[0] = Saber.GetBasicSaber();
            troops[1] = Archer.GetBasicArcher();
            troops[2] = Lancer.GetBasicLancer();
            troops[3] = Assassin.GetBasicAssassin();
            return troops;
        }
        /// <summary>
        /// Get the string value of these Troops for the Server DataBase.
        /// </summary>
        /// <param name="myTroops"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        /// <returns></returns>
        public static StrongString GetForServer(Troop[] myTroops)
        {
            if(myTroops == null)
            {
                throw new ArgumentNullException();
            }
            StrongString myString =
                myTroops[0].GetForServer() + OutCharSeparator + // Saber
                myTroops[1].GetForServer() + OutCharSeparator + // Archer
                myTroops[2].GetForServer() + OutCharSeparator + // Lancer
                myTroops[3].GetForServer() + OutCharSeparator; //Assassin
            return myString;
        }
        /// <summary>
        /// Create player's troops for the first time.
        /// </summary>
        /// <param name="troops"></param>
        public async static Task<DataBaseDataChangedInfo> CreatePlayerTroops(Troop[] troops)

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
        public async static void SavePlayerTroops(Troop[] troops)
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
        public async static Task<Troop[]> LoadPlayerTroops()
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
            return ParseToTroops(existingFile.Decode());
        }
        //-----------------------------------
        protected virtual StrongString GetForServer()
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
