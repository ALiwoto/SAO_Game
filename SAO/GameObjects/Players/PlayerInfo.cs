using System;
using System.Threading.Tasks;
using WotoProvider.Interfaces;
using SAO.SandBox;
using SAO.Security;
using SAO.Controls;
using SAO.Constants;
using SAO.GameObjects.Math;
using SAO.GameObjects.Guilds;
using SAO.GameObjects.Kingdoms;
using SAO.GameObjects.ServerObjects;

namespace SAO.GameObjects.Players
{
    public class PlayerInfo
    {
        //-------------------------------------------------
        #region constants Region
        public const string FileEndName = "_これはインフォです";
        public const string CharSeparater = "い";
        public const string NotSetString = "ナットセット";
        #endregion
        //-------------------------------------------------
        #region Server Properties Region
        //These properties has the Check number, that means they should 
        //be saved in the server.
        
        /// <summary>
        /// The Name of Player, it will be the same in the servers files.
        /// It is also the username that user entered at the first time.
        /// The check number is : 1.
        /// </summary>
        public virtual StrongString PlayerName { get; protected set; }
        /// <summary>
        /// the level of the player.
        /// The check number is : 2.
        /// </summary>
        public virtual ushort PlayerLevel { get; protected set; }
        /// <summary>
        /// this parameter should be between 1 and 50.
        /// if that is 0, that means player won't show in the lvl rankings.
        /// The check number is : 3.
        /// </summary>
        public virtual ushort PlayerLVLRanking { get; protected set; }
        /// <summary>
        /// this parameter should be between 1 and 50.
        /// if that is 0, that means player won't show in the lvl rankings.
        /// The check number is : 4.
        /// </summary>
        public virtual ushort PlayerPowerRanking { get; protected set; }
        /// <summary>
        /// 
        /// The check number is : 5.
        /// </summary>
        public virtual StrongString PlayerGuildName { get; protected set; }
        /// <summary>
        /// 
        /// The check number is : 6.
        /// </summary>
        public virtual GuildPosition GuildPosition { get; protected set; }
        /// <summary>
        /// 
        /// The check number is : 7.
        /// </summary>
        public virtual IDateProvider<DateTime, Trigger, StrongString> LastSeen { get; protected set; }
        /// <summary>
        /// 
        /// The check number is : 8.
        /// </summary>
        public virtual Unit PlayerPower { get; protected set; }
        /// <summary>
        /// 
        /// The check number is : 9.
        /// </summary>
        public virtual StrongString PlayerIntro { get; protected set; }
        /// <summary>
        /// 
        /// The check number is : 10.
        /// </summary>
        public virtual Avatar PlayerAvatar { get; protected set; }
        /// <summary>
        /// The Player's Avatar Frame.
        /// The check number is : 11.
        /// </summary>
        public virtual AvatarFrame PlayerAvatarFrame { get; protected set; }
        /// <summary>
        /// 
        /// The check number is : 12.
        /// </summary>
        public virtual ushort PlayerVIPlvl { get; protected set; }
        /// <summary>
        /// This is the current exp of this level.
        /// The check number is : 13.
        /// </summary>
        public virtual Unit PlayerCurrentExp { get; protected set; }
        /// <summary>
        /// The total Exp of the Player.
        /// The check number is : 14.
        /// </summary>
        public virtual Unit PlayerTotalExp { get; protected set; }
        /// <summary>
        /// 
        /// The check number is : 15.
        /// </summary>
        public virtual Unit PlayerCurrentVIPExp { get; protected set; }
        /// <summary>
        /// 
        /// The check number is : 16.
        /// </summary>
        public virtual PlayerElement ThePlayerElement { get; protected set; }
        /// <summary>
        /// Please Convert it to the int when you are tring 
        /// to updating or creating the playerKingdom
        /// in <see cref="UpdatePlayerInfo()"/> or
        /// <see cref="Me.CreatePlayerInfoTimer_Tick(object, EventArgs)"/>.
        /// The check number is : 17.
        /// </summary>
        public virtual SAO_Kingdoms PlayerKingdom { get; protected set; }
        /// <summary>
        /// The check number is : 18.
        /// </summary>
        public virtual SocialPosition SocialPosition { get; protected set; }
        
        #endregion
        //-------------------------------------------------
        #region Offline Properties Region
        /// <summary>
        /// Existence of the player in the Server.
        /// it is false by default, so you should run the function <see cref="CheckForExistence()"/>,
        /// after that, this parameter will be true.
        /// </summary>
        public virtual bool PlayerExists { get; protected set; }
        public virtual bool IsEmpty { get; protected set; }
        #endregion
        //-------------------------------------------------
        #region Ordinary Method's Region
        protected StrongString PlayerInfoGetForServer()
        {
            return
                    PlayerName                                      + CharSeparater + // 1
                    PlayerLevel.ToString()                          + CharSeparater + // 2
                    PlayerLVLRanking.ToString()                     + CharSeparater + // 3
                    PlayerPowerRanking.ToString()                   + CharSeparater + // 4
                    PlayerGuildName                                 + CharSeparater + // 5
                    ((uint)GuildPosition).ToString()                + CharSeparater + // 6
                    LastSeen.GetForServer()                         + CharSeparater + // 7
                    PlayerPower.GetForServer()                      + CharSeparater + // 8
                    PlayerIntro                                     + CharSeparater + // 9
                    PlayerAvatar.GetForServer()                     + CharSeparater + // 10
                    PlayerAvatarFrame.GetForServer()                + CharSeparater + // 11
                    PlayerVIPlvl.ToString()                         + CharSeparater + // 12
                    PlayerCurrentExp.GetForServer()                 + CharSeparater + // 13
                    PlayerTotalExp.GetForServer()                   + CharSeparater + // 14
                    PlayerCurrentVIPExp.GetForServer()              + CharSeparater + // 15
                    ((int)ThePlayerElement).ToString()              + CharSeparater + // 16
                    ((int)PlayerKingdom).ToString()                 + CharSeparater + // 17
                    SocialPosition.GetForServer()                   + CharSeparater;  // 18
        }
        private void SetParams(StrongString serverValue)
        {
            StrongString[] myStrings = serverValue.Split(CharSeparater);
            PlayerName          = myStrings[0];                                     // 1
            PlayerLevel         = myStrings[1].ToUInt16();                          // 2
            PlayerLVLRanking    = myStrings[2].ToUInt16();                          // 3
            PlayerPowerRanking  = myStrings[3].ToUInt16();                          // 4
            PlayerGuildName     = myStrings[4];                                     // 5
            GuildPosition       = (GuildPosition)myStrings[5].ToUInt16();           // 6
            LastSeen            = DateProvider.Parse(myStrings[6]);                 // 7
            PlayerPower         = Unit.ConvertToUnit(myStrings[7]);                 // 8
            PlayerIntro         = myStrings[8];                                     // 9
            PlayerAvatar        = Avatar.ConvertToAvatar(myStrings[9]);             // 10
            PlayerAvatarFrame   = AvatarFrame.ParseToAvatarFrame(myStrings[10]);    // 11
            PlayerVIPlvl        = myStrings[11].ToUInt16();                         // 12
            PlayerCurrentExp    = Unit.ConvertToUnit(myStrings[12]);                // 13
            PlayerTotalExp      = Unit.ConvertToUnit(myStrings[13]);                // 14          
            PlayerCurrentVIPExp = Unit.ConvertToUnit(myStrings[14]);                // 15
            ThePlayerElement    = (PlayerElement)myStrings[15].ToUInt16();          // 16
            PlayerKingdom       = (SAO_Kingdoms)myStrings[16].ToInt32();            // 17
            SocialPosition      = SocialPosition.GetSocialPosition(myStrings[17]);  // 18
        }
        protected void SetPlayerInfoParams(StrongString serverValue)
        {
            SetParams(serverValue);
        }
        #endregion
        //-------------------------------------------------
        #region Constructors Region
        /// <summary>
        /// Do not use this constructor please.
        /// this is only for <see cref="Me"/> and also
        /// <seealso cref="Player"/> classes.
        /// </summary>
        protected PlayerInfo()
        {
            PlayerExists = false;
        }
        /// <summary>
        /// You can't use this directly,
        /// please use <see cref="GetPlayerInfo(string, bool)"/>
        /// instead.
        /// </summary>
        /// <param name="playerName"></param>
        private PlayerInfo(StrongString playerName)
        {
            PlayerName = playerName;
            if (PlayerName == ThereIsConstants.Path.NotSet)
            {
                IsEmpty             = true;
                PlayerAvatar        = Avatar.GetDefaultAvatar();
                PlayerAvatarFrame   = AvatarFrame.GetDefaultAvatarFrame();
            }
            else
            {
                IsEmpty = false;
            }
        }
        #endregion
        //-------------------------------------------------
        #region Servering Methods Region
        public async Task<bool> ReloadPlayerInfo()
        {
            if (IsEmpty)
            {
                return true;
            }
            var targetFile = PlayerName + FileEndName;
            var existingFile =
                await ThereIsServer.Actions.GetAllContentsByRef(ThereIsServer.ServersInfo.MyServers[0],
                targetFile);
            await Task.Delay(50);
            if (existingFile.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return false;
            }
            SetParams(existingFile.Decode());
            return true;
        }
        public async Task<bool> CheckForExistence()
        {
            var targetFile = PlayerName + ThereIsServer.ServersInfo.EndCheckingFileName;
             return 
                await ThereIsServer.Actions.DeleteFile(ThereIsServer.ServersInfo.MyServers[0], 
                targetFile,
                new DataBaseDeleteRequest("DeletedForCheckingBySAO", "NoSHA"));
        }
        /// <summary>
        /// Updating the Player info to the Server.
        /// All of them will be updated.
        /// </summary>
        public async Task<DataBaseDataChangedInfo> UpdatePlayerInfo()
        {
            try
            {
                var targetFile = PlayerName + FileEndName;
                var Existing =
                    await
                    ThereIsServer.Actions.GetAllContentsByRef(ThereIsServer.ServersInfo.MyServers[0],
                    targetFile);
                if (Existing.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
                {
                    NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                    return null;
                }
                return await ThereIsServer.Actions.UpdateFile(ThereIsServer.ServersInfo.MyServers[0], 
                    targetFile,
                    new DataBaseUpdateRequest("By API", QString.Parse(PlayerInfoGetForServer()), Existing.Sha));
            }
            catch
            {
                throw new Exception();
            }
        }
        #endregion
        //-------------------------------------------------
        #region static Methods Region
        public static async Task<PlayerInfo> GetPlayerInfo(StrongString name, bool loadFromServer)
        {
            PlayerInfo player = new PlayerInfo(name);
            if (loadFromServer && player.PlayerName != ThereIsConstants.Path.NotSet)
            {
                player.PlayerExists = await player.CheckForExistence();
                if (player.PlayerExists)
                {
                    await player.ReloadPlayerInfo();
                }
                else
                {
                    return null;
                }
            }
            return player;
        }
        public static PlayerInfo GetPlayerInfo(StrongString name)
        {
            return new PlayerInfo(name);
        }
        #endregion
        //-------------------------------------------------
    }
}
