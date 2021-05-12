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
        public class Assassin : Troop
        {
            //-----------------------------------
            private Assassin(Unit countValue, uint levelValue, Unit powerValue)
            {
                Count = countValue;
                Level = levelValue;
                Power = powerValue;
            }
            //-----------------------------------
            //-----------------------------------
            //-----------------------------------
            public static Assassin ParseToAssassin(StrongString theString)
            {
                StrongString[] myStrings = theString.Split(InCharSeparator);
                Assassin myAssassin = new Assassin(Unit.ConvertToUnit(myStrings[0]),
                    myStrings[1].ToUInt16(), Unit.ConvertToUnit(myStrings[2]));
                return myAssassin;
            }
            public static Assassin GetBasicAssassin()
            {
                return new Assassin(Unit.GetBasicUnit(), BasicLevel,
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
