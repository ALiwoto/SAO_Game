using System;
using System.Text;
using System.Threading.Tasks;
using SAO.SandBox;
using SAO.Security;
using SAO.GameObjects.Troops;
using SAO.GameObjects.Heroes;
using SAO.GameObjects.ServerObjects;
using SAO.GameObjects.GameResources;

namespace SAO.GameObjects.Players
{
    public class Player : PlayerInfo
    {
        //-------------------------------------------------
        #region Constants Region
        /// <summary>
        /// Save it with this order: <see cref="CastleLvl"/> + ..
        /// </summary>
        public const string EndFileName_Player = "_ポレやー";
        public const string EndFileName_Heroes = "_緋色渦";
        public const string EndFileName_Villages = "_ウィれー儒";
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public HeroManager PlayerHeroes { get; set; }
        public Village[] PlayerVillages { get; set; }
        /// <summary>
        /// The PlayerTroops in the castle.
        /// </summary>
        public TroopManager PlayerTroops { get; set; } 
        public MagicalTroop PlayerMagicalTroops { get; set; }
        //-------------------------------------------------
        /// <summary>
        /// This parameter Should be set in: <see cref="EndFileName_Player"/>
        /// </summary>
        public ushort CastleLvl { get; set; }
        public PlayerResources PlayerResources { get; set; }
        #endregion
        //-------------------------------------------------
        #region Constructor Region
        protected Player()
        {
            ;/*
                * nothing is here,
                * please come back again.
                * thanks, wotoTeam Corp. ALi.w
             */
        }
        #endregion
        //-------------------------------------------------
        #region Ordinary Method's Region
        private void SetParams(StrongString serverValue)
        {
            StrongString[] myStrings = serverValue.Split(CharSeparater);

            CastleLvl = myStrings[0].ToUInt16();
        }
        protected void SetPlayerParams(StrongString serverValue)
        {
            SetParams(serverValue);
        }
        #endregion
        //-------------------------------------------------
        #region Online Methods Region
        public async Task<bool> ReloadPlayer()
        {
            var targetFile = PlayerName + EndFileName_Player;

            var existingFile =
                await ThereIsServer.Actions.GetAllContentsByRef(ThereIsServer.ServersInfo.MyServers[0], 
                targetFile);
            if (existingFile.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return false;
            }
            SetParams(existingFile.Decode());
            return true;
        }
        public async Task<DataBaseDataChangedInfo> UpdatePlayer()
        {
            var targetFile = PlayerName + EndFileName_Player;
            string myCon = CastleLvl.ToString() + CharSeparater;
            var existingFile =
                await ThereIsServer.Actions.GetAllContentsByRef(ThereIsServer.ServersInfo.MyServers[0], 
                        targetFile);
            if (existingFile == null || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return null;
            }
            return await ThereIsServer.Actions.UpdateFile(ThereIsServer.ServersInfo.MyServers[0], 
                        targetFile,
                        new DataBaseUpdateRequest("Testing for Creating", myCon, 
                        existingFile[0].Sha.GetStrong()));
        }
        #endregion
        //-------------------------------------------------
    }
}
