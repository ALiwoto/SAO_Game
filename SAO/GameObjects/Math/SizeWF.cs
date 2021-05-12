// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Drawing;

namespace SAO.GameObjects.Math
{
    public class SizeWF : ISizeFProvider
    {
        //-------------------------------------------------
        #region Constant's Region
        public const string ToStringValue = "SizeWF || BY: wotoTeam";
        #endregion
        //-------------------------------------------------
        #region field Region
        private SizeF mySize;
        private readonly ISizableF father;
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public float Width
        {
            get
            {
                return mySize.Width;
            }
        }
        public float Height
        {
            get
            {
                return mySize.Height;
            }
        }
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        public SizeWF(ISizableF theFather)
        {
            mySize = new SizeF(0, 0);
            father = theFather;
            ChangeSize();
        }
        public SizeWF(float width, float height, ISizableF theFather)
        {
            mySize = new SizeF(width, height);
            father = theFather;
            ChangeSize();
        }
        #endregion
        //-------------------------------------------------
        #region Get Method's Region
        public SizeF GetSize()
        {
            return mySize;
        }
        #endregion
        //-------------------------------------------------
        #region Set Method's Region
        public void ChangeSize(float width, float height)
        {
            mySize = new SizeF(width, height);
            father.SizeF = mySize;
        }
        private void ChangeSize()
        {
            father.SizeF = mySize;
        }
        #endregion
        //-------------------------------------------------
        #region overrided Method's Region
        public override string ToString()
        {
            return ToStringValue;
        }
        #endregion
        //-------------------------------------------------
    }
}
