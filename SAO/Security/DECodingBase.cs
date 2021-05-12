using System.Text;
using WotoProvider.Interfaces;
using WotoProvider.Interfaces.Security;

namespace SAO.Security
{
    public abstract class DECodingBase : IDECoderProvider<StrongString, QString>, ICryptoTransform
    {
        //-------------------------------------------------
        #region Properties Region
        public Encoding TheEncoderValue { get; }
        #endregion
        //-------------------------------------------------
        #region Constructors Region
        protected DECodingBase()
        {
            TheEncoderValue = Encoding.Unicode;
        }
        #endregion
        //-------------------------------------------------
        #region Ordinary Method's Region
        public abstract StrongString GetDecodedValue(QString value);
        #endregion
        //-------------------------------------------------
    }
}
