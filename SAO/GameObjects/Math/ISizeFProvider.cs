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
