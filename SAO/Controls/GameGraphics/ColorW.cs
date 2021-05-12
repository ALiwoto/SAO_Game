using System.Drawing;

namespace SAO.Controls.GameGraphics
{
    public class ColorW
    {
        //-------------------------------------------------
        #region Constant's Region

        #endregion
        //-------------------------------------------------
        #region field's Region
        private Color _color;
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        public ColorW(Color color)
        {
            _color = color;
        }
        #endregion
        //-------------------------------------------------
        #region Set Method's Region
        public void ChangeColor(Color color)
        {
            _color = color;
        }
        #endregion
        //-------------------------------------------------
        #region Get Method's Region
        public Color GetColor()
        {
            return _color;
        }
        #endregion
        //-------------------------------------------------
        #region static Method's Region
        public static ColorW ConvertToColorW(Color color)
        {
            return new ColorW(color);
        }
        #endregion
        //-------------------------------------------------
        #region static operator's Region
        public static implicit operator Color(ColorW v)
        {
            return v.GetColor();
        }
        #endregion
        //-------------------------------------------------
    }
}
