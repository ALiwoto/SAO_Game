using SAO.Security;
using SAO.GameObjects.ServerObjects;
using WotoProvider.Interfaces;

namespace SAO.LoadingService
{
#pragma warning disable IDE0044
#pragma warning disable IDE0051
    /// <summary>
    /// ServerInfo
    /// </summary>
    public sealed class ServerInfo : IServerProvider<QString, DataBaseClient>, ISecurity
    {
        //-------------------------------------------------
        #region Constants Region
        public const string ToStringValue = "Server Info -- wotoTeam Cor. |" +
            "BY Ali.w && mrwoto";
        public const string SecureToString = ToStringValue + " ++ Licensed BY Ali.w ++";
        #endregion
        //-------------------------------------------------
        #region fields Region
        private DataBaseClient serverClient;
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public QString ProductHeaderValue { get; }
        public QString Token { get; }
        public QString Owner { get; }
        public QString Repo { get; }
        public QString Branch { get; }
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        /// <summary>
        /// Create a new instance of the <see cref="ServerInfo"/>.
        /// </summary>
        /// <param name="productHeaderValue">
        /// the header of the product.
        /// </param>
        /// <param name="tokenValue">
        /// the token needed to login to the database.
        /// </param>
        /// <param name="ownerValue">
        /// the name of the owner of the database.
        /// </param>
        /// <param name="repoValue">
        /// the name of the repo.
        /// </param>
        /// <param name="branchValue">
        /// the name of the branch which you want to save the data into it.
        /// </param>
        public ServerInfo(StrongString productHeaderValue, StrongString tokenValue,
            StrongString ownerValue, StrongString repoValue, StrongString branchValue)
        {
            ProductHeaderValue  = QString.Parse(productHeaderValue);
            Token               = QString.Parse(tokenValue);
            Owner               = QString.Parse(ownerValue);
            Repo                = QString.Parse(repoValue);
            Branch              = QString.Parse(branchValue);
            serverClient        = 
                new DataBaseClient(new DataBaseHeader(ProductHeaderValue), Token);
        }
        #endregion
        //-------------------------------------------------
        #region Ordinary Methods Region
        /// <summary>
        /// Get the Client of the database.
        /// </summary>
        /// <returns></returns>
        public DataBaseClient GetClient()
        {
            return serverClient;
        }
        /// <summary>
        /// return the string which contains the information
        /// about this class.
        /// </summary>
        /// <param name="value">
        /// if true,in addition to get the general informations, 
        /// you will get the informations about license.
        /// </param>
        /// <returns>information</returns>
        public StrongString ToString(bool value)
        {
            if (value)
            {
                return SecureToString;
            }
            return ToStringValue;
        }
        #endregion
        //-------------------------------------------------
    }
#pragma warning restore IDE0044
#pragma warning restore IDE0051
}
