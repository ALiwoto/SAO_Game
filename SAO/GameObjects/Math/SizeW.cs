using System.Drawing;

namespace SAO.GameObjects.Math
{
    /// <summary>
    /// SizeW is a size provider created by wotoTeam.
    /// </summary>
    public class SizeW : ISizeProvider
    {
        //-------------------------------------------------
        #region Constant's Region
        public const string ToStringValue = "SizeW || BY: wotoTeam";
        #endregion
        //-------------------------------------------------
        #region field Region
        private Size mySize;
        private readonly ISizable father;
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public int Width
        {
            get
            {
                return mySize.Width;
            }
        }
        public int Height
        {
            get
            {
                return mySize.Height;
            }
        }
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        public SizeW(ISizable theFather)
        {
            mySize = new Size(0, 0);
            father = theFather;
            ChangeSize();
        }
        public SizeW(int width, int height, ISizable theFather)
        {
            mySize = new Size(width, height);
            father = theFather;
            ChangeSize();
        }
        #endregion
        //-------------------------------------------------
        #region Get Method's Region
        public Size GetSize()
        {
            return mySize;
        }
        #endregion
        //-------------------------------------------------
        #region Set Method's Region
        public void ChangeSize(int width, int height)
        {
            mySize = new Size(width, height);
            father.Size = mySize;
        }
        private void ChangeSize()
        {
            father.Size = mySize;
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
