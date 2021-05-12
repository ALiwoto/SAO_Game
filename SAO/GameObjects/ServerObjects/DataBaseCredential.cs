using Octokit;
using SAO.Security;

namespace SAO.GameObjects.ServerObjects
{
    class DataBaseCredential : Credentials
    {
        //-------------------------------------------------
        #region Constructor's Region
        public DataBaseCredential(QString value) :
            base(value.GetValue())
        {
            // do nothing here, (for now) ...
        }
        #endregion
        //-------------------------------------------------
    }
}
