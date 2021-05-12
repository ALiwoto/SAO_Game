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
