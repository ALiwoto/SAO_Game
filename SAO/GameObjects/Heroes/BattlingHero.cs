using SAO.Security;
using SAO.GameObjects.Math;

namespace SAO.GameObjects.Heroes
{
    public sealed class BattlingHero : Hero
    {
        public string Position { get; private set; }



        public BattlingHero(string heroID, 
            string customName, 
            uint level, 
            Unit power, 
            Unit skillPoint,
            uint stars,
            string skillString) : 
            base(customName,
                heroID,  
                level,
                power,
                skillPoint,
                stars,
                skillString)
        {

        }


        public static BattlingHero ParseToBattlingHero(string stringValue)
        {
            if (stringValue is null)
            {
                // TODO...
            }

            return null;
        }
        public override StrongString GetForServer()
        {
            return null;
        }
    }
}
