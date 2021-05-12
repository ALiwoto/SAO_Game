// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using SAO.Security;
using SAO.GameObjects.Math;

namespace SAO.GameObjects.Troops
{
    partial class Troop
    {
        public class Archer : Troop
        {
            //-----------------------------------
            private Archer(Unit countValue, uint levelValue, Unit powerValue)
            {
                Count = countValue;
                Level = levelValue;
                Power = powerValue;
            }
            //-----------------------------------
            //-----------------------------------
            //-----------------------------------
            //-----------------------------------
            public static Archer ParseToArcher(StrongString theString)
            {
                StrongString[] myStrings = theString.Split(InCharSeparator);
                Archer myArcher = new Archer(Unit.ConvertToUnit(myStrings[0]),
                    myStrings[1].ToUInt16(), Unit.ConvertToUnit(myStrings[2]));
                return myArcher;
            }
            public static Archer GetBasicArcher()
            {
                return new Archer(Unit.GetBasicUnit(), BasicLevel,
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
