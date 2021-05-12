// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Drawing;

namespace SAO.GameObjects.Math
{
    public interface ISizeProvider
    {
        //-------------------------------------------------
        #region Properties Region
        int Width { get; }
        int Height { get; }
        #endregion
        //-------------------------------------------------
        #region Methods Region
        void ChangeSize(int width, int height);
        Size GetSize();
        #endregion
        //-------------------------------------------------
    }
}
