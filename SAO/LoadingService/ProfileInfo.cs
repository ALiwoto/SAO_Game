// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using SAO.Constants;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SAO.LoadingService
{
    /// <summary>
    /// You should Serialize object of this class in 
    /// <see cref="ThereIsConstants.Path.ProfileInfo_File_Path"/> which is in
    /// <see cref="ThereIsConstants.Path.Profile_Folder_Path"/>.
    /// </summary>
    [Serializable]
    public class ProfileInfo
    {
        private string username;
        private string theToken;
        private string lastLogin;
        /// <summary>
        /// void ProfileInfo, use this for creating the default ProfileInfo,
        /// Last Login will be set with <see cref="DateTime.Now"/>
        /// </summary>
        public ProfileInfo() : this(ThereIsConstants.Path.NotSet, 
            ThereIsConstants.Path.NotSet, 
            ThereIsConstants.AppSettings.GlobalTiming.GetForServer().GetValue())
        {

        }
        /// <summary>
        /// use this for Generatinga new ProfileInfo.
        /// </summary>
        /// <param name="usernameValue">
        /// this value will set the <see cref="UserName"/> property.
        /// </param>
        /// <param name="theTokenValue">
        /// this value will set the <see cref="TheToken"/> property.
        /// </param>
        /// <param name="lastLoginValue">
        /// this value will set the <see cref="LastLogin"/> property.
        /// </param>
        public ProfileInfo(string usernameValue, string theTokenValue, string lastLoginValue)
        {
            UserName = usernameValue;
            TheToken = theTokenValue;
            LastLogin = lastLoginValue;
        }
        /// <summary>
        /// The Username value.
        /// </summary>
        public string UserName
        {
            get
            {
                return username;
            }
            set
            {
                if(value != null)
                {
                    username = value;
                }
                else
                {
                    username = ThereIsConstants.Path.NotSet;
                }
            }
        }
        /// <summary>
        /// The Token Value,
        /// Notice: this is the personal token that this client has Generated,
        /// this is not the Token for Entering.
        /// </summary>
        public string TheToken
        {
            get
            {
                return theToken;
            }
            set
            {
                if(value != null)
                {
                    theToken = value;
                }
                else
                {
                    theToken = ThereIsConstants.Path.NotSet;
                }
            }
        }
        /// <summary>
        /// The last login value.
        /// Notice: this is last login value of this client, not the profile itself,
        /// so look, this last login should be set when player clicked on:
        /// Link Start.
        /// </summary>
        public string LastLogin
        {
            get
            {
                return lastLogin;
            }
            set
            {
                if(value != null)
                {
                    lastLogin = value;
                }
                else
                {
                    lastLogin = 
                        ThereIsConstants.AppSettings.GlobalTiming.GetForServer().GetValue();
                }
            }
        }
        //----------------------------------------------------------------------
        public static ProfileInfo FromFile(string filePath)
        {
            FileStream myFile = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
            BinaryFormatter formatter = new BinaryFormatter();
            ProfileInfo myInfo = (ProfileInfo)formatter.Deserialize(myFile);
            myFile.Close();
            myFile.Dispose();
            return myInfo;
        }
        public static void UpdateInfo(ProfileInfo myInfo ,string filePath)
        {
            FileStream myFile = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(myFile, myInfo);
            myFile.Close();
            myFile.Dispose();
        }
        //----------------------------------------------------------------------
    }
}
