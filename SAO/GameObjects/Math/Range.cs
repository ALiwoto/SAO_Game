// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

namespace SAO.GameObjects.Math
{
    public struct Range
    {
        public int Minimum { get; }
        public int Maximum { get; }


        public Range(int minimum, int maximum)
        {
            if (minimum > maximum)
            {
                Maximum = minimum;
                Minimum = maximum;
            }
            else
            {

                Minimum = minimum;
                Maximum = maximum;
            }
        }
        public Range(float minimum, float maximum) : this((int)minimum, (int)maximum)
        {
            // ;
        }


    }
}
