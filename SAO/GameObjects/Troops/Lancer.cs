using System;
using SAO.Security;
using SAO.GameObjects.Math;

namespace SAO.GameObjects.Troops
{
    partial class Troop
    {
        public class Lancer : Troop
        {
            //-----------------------------------
            private Lancer(Unit countValue, uint levelValue, Unit powerValue)
            {
                Count = countValue;
                Level = levelValue;
                Power = powerValue;
            }
            //-----------------------------------
            //-----------------------------------
            //-----------------------------------
            //-----------------------------------
            //-----------------------------------
            public static Lancer ParseToLancer(StrongString theString)
            {
                StrongString[] myStrings = theString.Split(InCharSeparator);
                Lancer myLancer = new Lancer(Unit.ConvertToUnit(myStrings[0]),
                    myStrings[1].ToUInt16(), Unit.ConvertToUnit(myStrings[2]));
                return myLancer;
            }
            public static Lancer GetBasicLancer()
            {
                return new Lancer(Unit.GetBasicUnit(), BasicLevel,
                    BasicPower);
            }
            //-----------------------------------
            protected override StrongString GetForServer()
            {
                return base.GetForServer();
            }
            //-----------------------------------

        }
    }
    
}
