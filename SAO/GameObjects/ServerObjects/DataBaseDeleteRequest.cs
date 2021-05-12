using Octokit;
using SAO.Security;

namespace SAO.GameObjects.ServerObjects
{
    public class DataBaseDeleteRequest : DeleteFileRequest
    {
        //-------------------------------------------------
        #region Constructors Region
        public DataBaseDeleteRequest(StrongString theMessage, StrongString theSha) :
            base(theMessage.GetValue(), theSha.GetValue())
        {
            // do nothing here ... (for now)
        }
        #endregion
        //-------------------------------------------------
    }
}
