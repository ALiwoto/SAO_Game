using System;
using SAO.Security;
using SAO.GameObjects.Math;

namespace SAO.GameObjects.Troops
{
    partial class Troop
    {
        public class Saber : Troop
        {
            //-----------------------------------

            //-----------------------------------
            private Saber(Unit countValue, uint levelValue, Unit powerValue)
            {
                Count = countValue;
                Level = levelValue;
                Power = powerValue;
            }
            //-----------------------------------
            //-----------------------------------
            //-----------------------------------
            //-----------------------------------
            public static Saber ParseToSaber(StrongString theString)
            {
                StrongString[] myStrings = theString.Split(InCharSeparator);
                Saber mySaber = new Saber(Unit.ConvertToUnit(myStrings[0]),
                    myStrings[1].ToUInt16(), Unit.ConvertToUnit(myStrings[2]));
                return mySaber;
            }
            public static Saber GetBasicSaber()
            {
                return new Saber(Unit.GetBasicUnit(), BasicLevel,
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
