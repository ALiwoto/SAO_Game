using System.Threading.Tasks;
using SAO.GameObjects.ServerObjects;
using SAO.GameObjects.Math;

namespace SAO.GameObjects.Heroes
{
    public sealed class HeroManager
    {
        //-------------------------------------------------
        #region constatnts Region
        public const string FirstNameString = "Hero Manager - ver 1.1.5.0000";
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public Hero[] Heroes { get; private set; }
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        private HeroManager(Hero[] heroes)
        {
            Heroes = heroes;
        }
        #endregion
        //-------------------------------------------------
        #region Ordinary Offline Methods
        public Unit GetTotalHeroesPower()
        {
            Unit myUnit = Unit.GetBasicUnit();
            for(int i = 0; i < Heroes.Length; i++)
            {
                myUnit += Heroes[i].Power;
            }
            return myUnit;
        }
        #endregion
        //-------------------------------------------------
        #region Online Methods

        /// <summary>
        /// Add a new hero to the hero list of this 
        /// hero manager and immediately update the
        /// Heroes in the Server DataBase.
        /// </summary>
        /// <param name="myHero"></param>
        public async Task<DataBaseDataChangedInfo> AddHero(Hero myHero)
        {
            for(int i = 0; i < Heroes.Length; i++)
            {
                if(Heroes[i].Name == myHero.Name)
                {
                    // This Player already has the hero
                    // so you should not add this hero to the
                    // array.
                    return null;
                }
            }
            Hero[] myHeroes = new Hero[Heroes.Length + 1];
            myHeroes[myHeroes.Length - 1] = myHero;
            Heroes = myHeroes;
            return await UpdateHeroes();
        }
        public async Task<DataBaseDataChangedInfo> UpdateHeroes()
        {
            return await Hero.SavePlayerHeroes(Heroes);
        }
        public async Task<bool> ReloadHeroes()
        {
            Heroes = await Hero.LoadPlayerHeroes();
            return true;
        }
        #endregion
        //-------------------------------------------------
        #region Overrided Region
        public override string ToString()
        {
            return FirstNameString;
        }
        #endregion
        //-------------------------------------------------
        #region Static Methods Region
        public static async Task<HeroManager> GetHeroManager()
        {
            Hero[] heroes;
            heroes = await Hero.LoadPlayerHeroes();
            return new HeroManager(heroes);
        }
        #endregion
        //-------------------------------------------------
    }
}
