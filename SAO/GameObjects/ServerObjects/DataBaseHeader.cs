using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;
using SAO.Security;

namespace SAO.GameObjects.ServerObjects
{
    public sealed class DataBaseHeader : ProductHeaderValue, ISecurity
    {
        //-------------------------------------------------
        #region Constants Region
        public const string ToStringValue = "Data Base Header -- " +
            "wotoTeam Cor. (C) 2020";
        #endregion
        //-------------------------------------------------
        #region Constructors Region
        public DataBaseHeader(QString name) :
            base(name.GetValue())
        {
            // do nothing here (for now)...
        }
        #endregion
        //-------------------------------------------------
        #region Ordinary Methods Region
        public StrongString ToString(bool value)
        {
            return ToStringValue;
        }
        #endregion
        //-------------------------------------------------

    }
}
