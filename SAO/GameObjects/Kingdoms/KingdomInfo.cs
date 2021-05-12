using System;
using System.Text;
using System.Threading.Tasks;
using SAO.SandBox;
using SAO.Security;
using SAO.GameObjects.Math;
using SAO.GameObjects.Chatting;
using SAO.GameObjects.ServerObjects;

namespace SAO.GameObjects.Kingdoms
{
    public class KingdomInfo
    {
        //-------------------------------------------------
        #region Constant's Region
        public const string KingdomInfoFileName = "キングダムインフォです";
        /// <summary>
        /// The Value is Gunsou, use it for separating the strings from server.
        /// </summary>
        public const string CharSeparatpr = "軍曹";
        #endregion
        //-------------------------------------------------
        #region Properties Region
        /// <summary>
        /// This is just a custom name which selected by the king of this kingdom.
        /// </summary>
        public StrongString KingdomName { get; set; }
        /// <summary>
        /// The power of the King of this Kingdom.
        /// </summary>
        public Unit KingsPower { get; set; }
        public ushort KingdomLevel { get; set; }
        //-------------------------------------------------
        // These guys should be saved in another files in this kingdom(don't load them in the same file 
        //   as KingdomInfo File, got it?) :
        public KingdomThrone Throne { get; set; }
        public KingdomRankings Rankings { get; set; }
        /// <summary>
        /// This will show you which Server you should use for this kingdom.
        /// DO NOT Use it in <see cref="GetForServer"/>
        /// North   : 1, 
        /// South   : 2,
        /// West    : 3,
        /// East    : 4,
        /// Center  : ? (5).
        /// check here: <see cref="SAO_Kingdoms"/>
        /// </summary>
        public uint Index { get; set; }
        public SAO_Kingdoms Provider { get; }
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        private KingdomInfo(SAO_Kingdoms provider)
        {
            Provider = provider;
        }
        #endregion
        //-------------------------------------------------
        #region Ordinary Method's Region
        private void SetParams(StrongString serverValue)
        {
            StrongString[] myStrings = serverValue.Split(CharSeparatpr);
            KingdomName     = myStrings[0];                     // 1
            KingsPower      = Unit.ConvertToUnit(myStrings[1]); // 2
            KingdomLevel    = myStrings[2].ToUInt16();          // 3
        }
        public ChatChannels GetKingdomChannel()
        {
            switch (Provider)
            {
                case SAO_Kingdoms.North:
                    return ChatChannels.K_1_Chat;
                case SAO_Kingdoms.South:
                    return ChatChannels.K_2_Chat;
                case SAO_Kingdoms.West:
                    return ChatChannels.K_3_Chat;
                case SAO_Kingdoms.East:
                    return ChatChannels.K_4_Chat;
                // case SAO_Kingdoms.Center: not completed yet.
                default:
                    throw new Exception();
            }
        }
        #endregion
        //-------------------------------------------------
        public static async Task<DataBaseDataChangedInfo> CreateKingdomInfo(SAO_Kingdoms index)
        {
            KingdomInfo kingdomInfo = new KingdomInfo(index)
            {
                Index = (uint)index,
                KingdomName = index.ToString(),
                KingsPower = Unit.GetBasicUnit(),
                KingdomLevel = 0,
            };
            return 
                await ThereIsServer.Actions.CreateFile(ThereIsServer.ServersInfo.MyServers[(uint)index],
                KingdomInfoFileName, new DataBaseCreation("Created By SAO_Game",
                QString.Parse(kingdomInfo.GetForServer(), false)));
        }
        public StrongString GetForServer()
        {
            string myString = 
                KingdomName.GetValue()                  + CharSeparatpr + // 1
                KingsPower.GetForServer().GetValue()    + CharSeparatpr + // 2
                KingdomLevel.ToString()                 + CharSeparatpr;  // 3
            return myString;
        }
        public static async Task<KingdomInfo> GetKingdomInfo(uint index)
        {
            KingdomInfo kingdomInfo = new KingdomInfo((SAO_Kingdoms)index)
            {
                Index = index,
            };
            var Existing = 
                await ThereIsServer.Actions.GetAllContentsByRef(ThereIsServer.ServersInfo.MyServers[index],
                KingdomInfoFileName);
            await Task.Delay(300);
            if (Existing.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return null; // don't set ServerSettings.IsWaitingForServerChecking = false;
            }
            kingdomInfo.SetParams(Existing.Decode());
            return kingdomInfo;
        }
        public static async Task<KingdomInfo> GetKingdomInfo(SAO_Kingdoms index)
        {
            return await GetKingdomInfo((uint)index);
        }
        //-----------------------------------------
    }
}
