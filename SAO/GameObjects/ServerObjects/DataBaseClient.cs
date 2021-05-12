using Octokit;
using SAO.Security;
using SAO.Constants;

namespace SAO.GameObjects.ServerObjects
{
    public class DataBaseClient : GitHubClient
    {
        //-------------------------------------------------
        #region Constructor's Region
        public DataBaseClient(DataBaseHeader header, QString cridental) :
            base(header)
        {
            Credentials = new DataBaseCredential(cridental);
            SetRequestTimeout(ThereIsConstants.AppSettings.DefaultDataBaseTimeOut);
        }
        #endregion
        //-------------------------------------------------
    }
}
