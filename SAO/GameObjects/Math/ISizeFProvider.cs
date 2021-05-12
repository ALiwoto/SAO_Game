// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Drawing;

namespace SAO.GameObjects.Math
{
    public interface ISizeFProvider
    {
        //-------------------------------------------------
        #region Properties Region
        float Width { get; }
        float Height { get; }
        #endregion
        //-------------------------------------------------
        #region Methods Region
        void ChangeSize(float width, float height);
        SizeF GetSize();
        #endregion
        //-------------------------------------------------
    }
}
