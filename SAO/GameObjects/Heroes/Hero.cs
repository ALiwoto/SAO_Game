using System;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using WotoProvider.Enums;
using SAO.SandBox;
using SAO.Controls;
using SAO.Security;
using SAO.Constants;
using SAO.GameObjects.Math;
using SAO.GameObjects.Players;
using SAO.GameObjects.Resources;
using SAO.GameObjects.ServerObjects;

namespace SAO.GameObjects.Heroes
{
    public partial class Hero : IRes
    {
        //-------------------------------------------------
        #region Constants Region
        /// <summary>
        /// Use this to separate the heroes type from each other.
        /// </summary>
        public const string OutCharSeparator = "よ";
        /// <summary>
        /// But use this in each type, for separate their parameters.
        /// </summary>
        public const string InCharSeparator = "つ";
        /// <summary>
        /// The End of The File which you should
        /// save it in the server and get the data from it.
        /// </summary>
        public const string EndFileName = "_日ロー";
        public const string RangeStringInRes = "_Range";
        //-------------------------------------------------
        public const uint BasicLevel = 1;
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public WotoRes MyRes { get; set; }
        //-------------------------------------------------
        /// <summary>
        /// The RealName of this Hero(for player).
        /// </summary>
        public StrongString Name { get; private set; }
        /// <summary>
        /// The Hero's name that setted by player.
        /// </summary>
        public StrongString CustomName { get; private set; }
        /// <summary>
        /// Use this for Programming.
        /// </summary>
        public StrongString HeroID { get; private set; }
        public HeroType HeroType { get; private set; }
        public PlayerElement HeroElement { get; private set; }
        /// <summary>
        /// The level of Hero.
        /// </summary>
        public uint Level { get; protected set; }
        public uint Stars { get; private set; }
        /// <summary>
        /// The Total Power of The Hero.
        /// this parameter is not that usefull
        /// in the live battles (pvp).
        /// </summary>
        public Unit Power { get; protected set; }
        //-------------------------------------------------
        #region Hero's particularities Battling
        /// <summary>
        /// 
        /// </summary>
        public virtual Unit HP { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Unit ATK { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Unit INT { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Unit DEF { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Unit RES { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Unit SPD { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Unit PEN { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Unit Block { get; protected set; }
        public virtual HeroSkill HeroSkill { get; protected set; }
        public virtual HeroSerialize HeroSerialize { get; protected set; }
        #endregion
        //-------------------------------------------------
        #region Hero's particularities Not Battling
        public Unit HeroCurrentExp { get; protected set; }
        public Unit SkillPoint { get; protected set; }
        #endregion
        //-------------------------------------------------


        #endregion Properties Region
        //-------------------------------------------------
        #region Constructor Region
        /// <summary>
        /// 
        /// </summary>
        /// <param name="heroIDValue"></param>
        /// <param name="customNameValue"></param>
        /// <param name="levelValue"></param>
        /// <param name="powerValue"></param>
        /// <param name="skillStringValue"></param>
        protected Hero(
            StrongString customNameValue,
            StrongString heroIDValue,
            uint levelValue,
            Unit powerValue,
            Unit skillPoint,
            uint stars,
            StrongString skillStringValue
            )
        {
            CustomName = customNameValue;
            HeroID = heroIDValue;
            Level = levelValue;
            Power = powerValue;
            SkillPoint = skillPoint;
            Stars = stars;
            LoadMe(heroIDValue); // Load values which should be loaded locally.
            HeroSkill.LoadInfo(skillStringValue.GetValue()); // Load from the server string.

        }
        /// <summary>
        /// using to create a Blank Hero obj.
        /// </summary>
        /// <param name="heroID"></param>
        private Hero()
        {
            LoadMe();
        }
        #endregion
        //-------------------------------------------------
        #region static Methods Region
        /// <summary>
        /// ...
        /// </summary>
        /// <param name="theString"></param>
        /// <returns></returns>
        public static Hero[] ParseToHeroes(StrongString theString)
        {
            Hero[] heroes;
            StrongString[] myStrings = theString.Split(OutCharSeparator);
            heroes = new Hero[myStrings.Length];
            for (int i = 0; i < heroes.Length; i++)
            {
                heroes[i] = GetSpecificHeroByString(myStrings[i]);
            }
            return heroes;
        }
        /// <summary>
        /// Get the string value of these Troops for the Server DataBase.
        /// </summary>
        /// <param name="myTroops"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        /// <returns></returns>
        public static StrongString GetForServer(Hero[] heroes)
        {
            if (heroes == null)
            {
                throw new ArgumentNullException();
            }
            StrongString myString = "";
            for (int i = 0; i < heroes.Length; i++)
            {
                myString += heroes[i].GetForServer() + OutCharSeparator;
            }
            return myString;
        }
        /// <summary>
        /// Create player's troops for the first time.
        /// Notice: you shoul use this function when player has already selected his 
        /// Element, so he should has at least one hero to load after it.
        /// </summary>
        /// <param name="troops"></param>
        public static async Task<DataBaseDataChangedInfo> CreatePlayerHeroes()
        {
            string myString = "";
            string targetFile = ThereIsServer.GameObjects.MyProfile.Username +
                EndFileName;
            return await ThereIsServer.Actions.CreateFile(ThereIsServer.ServersInfo.MyServers[0],
                targetFile,
                new DataBaseCreation("CreatingThePlayerHeroes", myString));
        }
        /// <summary>
        /// Save Player's troops(Update them to the server.)
        /// </summary>
        /// <param name="troops"></param>
        public static async Task<DataBaseDataChangedInfo> SavePlayerHeroes(Hero[] heroes)
        {
            StrongString myString = GetForServer(heroes);
            string targetFile = ThereIsServer.GameObjects.MyProfile.Username +
                EndFileName;
            var ExistingFile =
                    await ThereIsServer.Actions.GetAllContentsByRef(ThereIsServer.ServersInfo.MyServers[0],
                targetFile);
            if (ExistingFile.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return null; // don't set ServerSettings.IsWaitingForServerChecking = false;
            }
            return await ThereIsServer.Actions.UpdateFile(ThereIsServer.ServersInfo.MyServers[0],
                        targetFile,
                        new DataBaseUpdateRequest("By SAO", 
                        QString.Parse(myString, false), ExistingFile.Sha));
        }
        /// <summary>
        /// Loading the Heroes of the user with 
        /// <see cref="Me.Username"/> which is in
        /// <see cref="ThereIsServer.GameObjects.MyProfile"/>.
        /// </summary>
        /// <returns></returns>
        public static async Task<Hero[]> LoadPlayerHeroes()
        {
            string targetFile = ThereIsServer.GameObjects.MyProfile.Username +
                EndFileName;
            var existingFile =
                    await ThereIsServer.Actions.GetAllContentsByRef(ThereIsServer.ServersInfo.MyServers[0],
                targetFile);
            if (existingFile.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return null; // don't set ServerSettings.IsWaitingForServerChecking = false;
            }
            return ParseToHeroes(existingFile.Decode());
        }
        public static Hero GetSpecificHeroByString(StrongString theString)
        {
            StrongString[] myStrings = theString.Split(InCharSeparator);
            Hero myHero =
                new Hero(
                    myStrings[0],                       // custom name
                    myStrings[1],                       // hero ID
                    myStrings[2].ToUInt16(),            // level
                    Unit.ConvertToUnit(myStrings[3]),   // Power
                    Unit.ConvertToUnit(myStrings[4]),   // Skill Point
                    myStrings[5].ToUInt16(),            // Stars
                    myStrings[6]                        // This is HeroSkill String value, 
                                                        // do NOT convert it here.
                    )
                {
                    HP = Unit.ConvertToUnit(myStrings[7]),             // HP
                    ATK = Unit.ConvertToUnit(myStrings[8]),             // ATK
                    INT = Unit.ConvertToUnit(myStrings[9]),             // INT
                    DEF = Unit.ConvertToUnit(myStrings[10]),            // DEF
                    RES = Unit.ConvertToUnit(myStrings[11]),            // RES
                    SPD = Unit.ConvertToUnit(myStrings[12]),            // SPD
                    PEN = Unit.ConvertToUnit(myStrings[13]),            // PEN
                    Block = Unit.ConvertToUnit(myStrings[14]),          // Block
                    HeroCurrentExp = Unit.ConvertToUnit(myStrings[15])  // Exp
                };

            return myHero;
        }
        /// <summary>
        /// Generate a new random Hero with
        /// the Element.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static Hero GenerateHero(PlayerElement element)
        {
            Hero myHero = new Hero();
            int Range1 =
                Convert.ToInt32(
                    myHero.MyRes.GetString(element.ToString() + RangeStringInRes + 1));
            int Range2 =
                Convert.ToInt32(
                    myHero.MyRes.GetString(element.ToString() + RangeStringInRes + 2));
            Random ran = new Random();
            int nowInt = ran.Next(Range1, Range2 == Range1 ? Range2 : (Range2 + 1));
            myHero.SetHeroFromBlank(nowInt.ToString());
            return myHero; // not completed yet.
        }
        
        /// <summary>
        /// Create a new hero in the Game.
        /// This method will create a new hero just in the 
        /// game data.
        /// </summary>
        public static void CreateHero(HeroSerialize heroSerialize)
        {
            heroSerialize.Serialize();
        }
        #endregion
        //-------------------------------------------------
        #region Ordinary Offline Methods
        /// <summary>
        /// Get the total Unit that this Hero needs 
        /// to upgrade its level.
        /// </summary>
        /// <returns></returns>
        public Unit GetTotalExp()
        {
            return new Unit(); // Not Compeleted yet.
        }
        public Image GetHeroImage(HeroImageTypes type)
        {
            switch (type)
            {
                case HeroImageTypes.Type_580_500:
                    {
                        return Image.FromFile(ThereIsConstants.Path.Datas_Path +
                            ThereIsConstants.Path.DoubleSlash +
                            HeroSerialize.FirstNameOfImage_580_500_File +
                            HeroID.GetValue() + HeroSerialize.EndNameOfFile);
                    }
                default:
                    {
                        return null;
                    }
            }
            
        }
        public BattlingHero ConvertToBattlingHero()
        {
            return null;
        }

        /// <summary>
        /// Get The Hero by it's ID and load it from the file.
        /// use this when you want to generate a new hero.
        /// </summary>
        /// <param name="heroID"></param>
        /// <returns></returns>
        private void SetHeroFromBlank(string heroID)
        {
            LoadMe(heroID);
            HeroSkill.SetUpSkills();
            CustomName = Name;
            HeroID = heroID;
            // The Basic level of the hero should be 1
            Level = 1;

            // Look, the Skills should be summed with the following,
            // But the level of the skills are zero, so they will be zero.
            HP      = (Level * HeroSerialize.HP_Rate)    + HeroSkill.GetTotalHPOfSkills();
            ATK     = (Level * HeroSerialize.ATK_Rate)   + HeroSkill.GetTotalATKOfSkills();
            INT     = (Level * HeroSerialize.INT_Rate)   + HeroSkill.GetTotalINTOfSkills();
            DEF     = (Level * HeroSerialize.DEF_Rate)   + HeroSkill.GetTotalDEFOfSkills();
            RES     = (Level * HeroSerialize.RES_Rate)   + HeroSkill.GetTotalRESOfSkills();
            SPD     = (Level * HeroSerialize.SPD_Rate)   + HeroSkill.GetTotalSPDOfSkills();
            PEN     = (Level * HeroSerialize.PEN_Rate)   + HeroSkill.GetTotalPENOfSkills();
            Block   = (Level * HeroSerialize.Block_Rate) + HeroSkill.GetTotalBlockOfSkills();
            ReloadPower();


            HeroCurrentExp = Unit.GetBasicUnit();
            SkillPoint = Unit.GetBasicUnit();
            Stars = 0;



            return;
        }
        /// <summary>
        /// Reload the Power (Offiline),
        /// with this formula:
        /// <see cref="Power"/> =  <see cref="HP"/> + <see cref="ATK"/> +
        /// <see cref="INT"/> + <see cref="DEF"/> + <see cref="RES"/> +
        /// <see cref="SPD"/> + <see cref="PEN"/> + <see cref="Block"/>
        /// </summary>
        public void ReloadPower()
        {
            Power = HP + ATK + INT + DEF + RES + SPD +
                PEN + Block;
        }
        #endregion
        //-------------------------------------------------
        #region overrided Methods Region
        public override string ToString()
        {
            return (Name + " - " + CustomName + " - " + HeroID).GetValue();
        }
        #endregion
        //-------------------------------------------------
        #region Virtual Methods Region
        public virtual StrongString GetForServer()
        {
            StrongString myString = 
                CustomName                      + InCharSeparator + // index : 0
                HeroID                          + InCharSeparator + // index : 1
                Level.ToString()                + InCharSeparator + // index : 2
                Power.GetForServer()            + InCharSeparator + // index : 3
                SkillPoint.GetForServer()       + InCharSeparator + // index : 4
                Stars.ToString()                + InCharSeparator + // index : 5
                HeroSkill.GetForServer()        + InCharSeparator + // index : 6
                HP.GetForServer()               + InCharSeparator + // index : 7
                ATK.GetForServer()              + InCharSeparator + // index : 8
                INT.GetForServer()              + InCharSeparator + // index : 9
                DEF.GetForServer()              + InCharSeparator + // index : 10
                RES.GetForServer()              + InCharSeparator + // index : 11
                SPD.GetForServer()              + InCharSeparator + // index : 12
                PEN.GetForServer()              + InCharSeparator + // index : 13
                Block.GetForServer()            + InCharSeparator + // index : 14
                HeroCurrentExp.GetForServer()   + InCharSeparator;  // index : 15

            return myString;
        }

        #endregion
        //-------------------------------------------------
    }
}
