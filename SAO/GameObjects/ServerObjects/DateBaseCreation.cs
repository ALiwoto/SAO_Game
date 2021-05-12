using Octokit;
using SAO.Security;
using SAO.Constants;

namespace SAO.GameObjects.ServerObjects
{
    public class DataBaseCreation : CreateFileRequest
    {
        //-------------------------------------------------
        #region Constants Region

        #endregion
        //-------------------------------------------------
        #region Contructors Region
        public DataBaseCreation(StrongString theMessage, 
            QString theContext) :
            base(theMessage.GetValue(), theContext.GetString())
        {
            // do nothing here...
        }
        public DataBaseCreation(StrongString theMessage,
            string theContext) : this(theMessage, QString.Parse(theContext.ToStrong()))
        {

        }
        #endregion
        //-------------------------------------------------
    }
}
