// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using Octokit;
using SAO.Security;

namespace SAO.GameObjects.ServerObjects
{
    public sealed class DataBaseDataChangedInfo : RepositoryContentChangeSet, ISecurity
    {
        //-------------------------------------------------
        #region Constant's Region
        public const string ToStringValue = "-- DataBaseDataChangedInfo -- || " +
            "BY wotoTeam (C)";
        public const string SecureToString = ToStringValue + " ++ Licensed BY Ali.w ++";
        #endregion
        //-------------------------------------------------
        #region Properties Region
        /// <summary>
        /// check if this database object is a dead call back or not.
        /// </summary>
        public bool IsDeadCallBack { get; }
        #endregion
        //-------------------------------------------------
        #region Constructors Region
        private DataBaseDataChangedInfo(RepositoryContentChangeSet changeSet)
        {
            Commit          = changeSet.Commit;
            Content         = changeSet.Content;
            IsDeadCallBack  = false;
        }
        /// <summary>
        /// create a new instance of a dead callback for database changed info.
        /// </summary>
        private DataBaseDataChangedInfo()
        {
            IsDeadCallBack = true;
        }
        #endregion
        //-------------------------------------------------
        #region Static Methods Region
        /// <summary>
        /// Get a new <see cref="DataBaseDataChangedInfo"/> object,
        /// if the value is null, it will give you a dead callback info.
        /// </summary>
        /// <param name="set">
        /// if <c>set</c> is null, it will give you a dead call back.
        /// </param>
        /// <returns></returns>
        public static DataBaseDataChangedInfo GetInfo(RepositoryContentChangeSet set)
        {
            if (set is null)
            {
                return new DataBaseDataChangedInfo();
            }
            return new DataBaseDataChangedInfo(set);
        }
        #endregion
        //-------------------------------------------------
        #region Ordinary Method's Region
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
}
