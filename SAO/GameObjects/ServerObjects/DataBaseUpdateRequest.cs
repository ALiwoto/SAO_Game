using Octokit;
using SAO.Security;

namespace SAO.GameObjects.ServerObjects
{
    /// <summary>
    /// This class represents the parameters to update datas in DataBase.
    /// </summary>
    public class DataBaseUpdateRequest : UpdateFileRequest
    {
        //-------------------------------------------------
        #region Contructors Region
        public DataBaseUpdateRequest(StrongString theMessage, StrongString theContext, StrongString theSha) :
            base(theMessage.GetValue(), 
                QString.Parse(theContext).GetString(), 
                theSha.GetValue())
        {
            // do nothing here...
        }
        public DataBaseUpdateRequest(StrongString theMessage, 
            QString theContext, StrongString theSha) :
            base(theMessage.GetValue(),
                theContext.GetString(),
                theSha.GetValue())
        {
            // do nothing here...
        }
        public DataBaseUpdateRequest(StrongString theMessage,
            QString theContext, QString theSha) :
            base(theMessage.GetValue(),
                theContext.GetString(),
                theSha.GetValue())
        {
            // do nothing here...
        }
        #endregion
        //-------------------------------------------------
    }
}
