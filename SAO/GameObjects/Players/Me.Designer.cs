// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;
using SAO.SandBox;
using SAO.Security;
using SAO.Constants;
using SAO.LoadingService;
using SAO.GameObjects.ServerObjects;

namespace SAO.GameObjects.Players
{
    partial class Me
    {
        [ComVisible(false)]
        //[SecuritySafeCritical]
        [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        [SuppressMessage("Code Quality", "IDE0051:Remove unused private members", Justification = "<Pending>")]
        private class SecuredMe
        {

            private readonly StrongString _username;

            private readonly StrongString _password;

            private readonly StrongString _token;
            //--------------------------------------------
            //--------------------------------------------
            private const string endFileName = "_これからもうーさとにまとを";

            private const string charSeparater = "ろろろ";
            /// <summary>
            /// use these character in the Token,
            /// not for separating them from each other...
            /// In other word, use it in <see cref="GenerateTokne()"/>
            /// </summary>
            private const string charSeparaterInToken = "と験する";
            //--------------------------------------------
            private Me Father { get; set; }
            /// <summary>
            /// Use this to Create the Security Datas.
            /// </summary>
            /// <param name="wantMeToCreate"></param>
            /// <param name="usernameValue"></param>
            /// <param name="passwordValue"></param>
            /// <param name="father"></param>
            public SecuredMe(bool wantMeToCreate, StrongString usernameValue, StrongString passwordValue, Me father)
            {
                if (wantMeToCreate)
                {
                    Father = father;
                    _username = usernameValue;
                    _password = passwordValue;
                    _token = GenerateToken();
                    Timer myTimer = new Timer();
                    myTimer.Interval = 10;
                    myTimer.Tick += CreatingTheProfileSecurityWorker;
                    myTimer.Enabled = true;
                }
            }
            /// <summary>
            /// Use this before Link Start to the Profile.
            /// Notice: use this constructor just when the player already loged in to the
            /// profile and want to link start,
            /// if the player wants to login now, use <see cref="SecuredMe(string, string, bool, Me)"/>
            /// </summary>
            /// <param name="usernameValue"></param>
            /// <param name="tokenValue"></param>
            /// <param name=""></param>
            public SecuredMe(string usernameValue, string tokenValue, Me father)
            {
                _token = tokenValue;
                _username = usernameValue;
                Father = father;
                //-------------------------
                Timer myTimer = new Timer();
                myTimer.Interval = 10;
                myTimer.Tick += PriLinkStartWorker;
                myTimer.Enabled = true;

            }
            /// <summary>
            /// Use this to login to the Profile which already exists ( = username_LogedIn should exists)
            /// </summary>
            /// <param name="usernameValue"></param>
            /// <param name="passwordValue"></param>
            /// <param name="WantMeToLogInNow"></param>
            /// <param name="father"></param>
            public SecuredMe(StrongString usernameValue, StrongString passwordValue, bool WantMeToLogInNow,
                Me father)
            {
                Father      = father;
                _username    = usernameValue;
                _password    = passwordValue;
                //----------------------------------
                Timer myTimer = new Timer();
                myTimer.Interval = 10;
                myTimer.Tick += LoginToTheProfileWorker;
                myTimer.Enabled = true;
            }
            /// <summary>
            /// Use this one to generate the TokenObj
            /// </summary>
            /// <param name="GiveMeNewToken"></param>
            public SecuredMe(ref StrongString GiveMeNewToken)
            {
                GiveMeNewToken = GenerateToken();
            }
            /// <summary>
            /// Use this one to simply log out from the account.
            /// </summary>
            /// <param name="usernameValue"></param>
            public SecuredMe(string usernameValue, Me father, string tokenValue)
            {
                _token = tokenValue;
                _username = usernameValue;
                Father = father;
                //-------------------------
                Timer myTimer = new Timer();
                myTimer.Interval = 10;
                myTimer.Tick += LogOuttWorker;
                myTimer.Enabled = true;
            }
            //------------------------------------------------
            //---------------------------------------

            /// <summary>
            /// This function will create the Security data in 
            /// location <see cref="endFileName"/>
            /// at the server.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private async void CreatingTheProfileSecurityWorker(object sender, EventArgs e)
            {
                ((Timer)sender).Enabled = false;
                ((Timer)sender).Dispose();
                //MessageBox.Show("I am");
                var targetFile = _username + endFileName;
                StrongString myString = 
                    _username + charSeparater + 
                    _password + charSeparater +
                    _token + charSeparater;
                await ThereIsServer.Actions.CreateFile(ThereIsServer.ServersInfo.MyServers[0], 
                    targetFile,
                        new DataBaseCreation("Testing for Creating", QString.Parse(myString)));

                Father.IsSecuredMeWorkingOver = true;
                if (!Directory.Exists(ThereIsConstants.Path.Profile_Folder_Path))
                {
                    Directory.CreateDirectory(ThereIsConstants.Path.Profile_Folder_Path);
                }
                ProfileInfo myInfo = new ProfileInfo(_username.GetValue(), _token.GetValue(),
                    ThereIsConstants.AppSettings.GlobalTiming.GetForServer().GetValue());
                ProfileInfo.UpdateInfo(myInfo, ThereIsConstants.Path.ProfileInfo_File_Path);
                AccountInfo myAccInfo = new AccountInfo(1,
                    ThereIsConstants.AppSettings.GlobalTiming.GetForServer().GetValue());
                AccountInfo.UpdateInfo(myAccInfo, ThereIsConstants.Path.AccountInfo_File_Path);
                GC.Collect();

            }
            //---------------------------------------

            [SuppressMessage("Style", "IDE0047:Remove unnecessary parentheses", Justification = "<Pending>")]
            private async void LoginToTheProfileWorker(object sender, EventArgs e)
            {
                ((Timer)sender).Enabled = false;
                ((Timer)sender).Dispose();
                //MessageBox.Show("I am");
                var targetFile = _username + endFileName;
                var ExistingFile =
                    await ThereIsServer.Actions.GetAllContentsByRef(ThereIsServer.ServersInfo.MyServers[0], 
                targetFile);
                if (ExistingFile.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
                {
                    NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                    return;
                }
                StrongString myString = ExistingFile.Decode();
                Father.HasLogin = (_password == myString.Split(charSeparater)[1]);
                if (!Father.HasLogin)
                {
                    Father.IsSecuredMeWorkingOver = true;
                    return;
                }
                StrongString[] myStrings = myString.Split(charSeparater);
                StrongString myToken = GenerateToken();
                if (myStrings.Length >= 7)
                {
                    StrongString myAnotherString;
                    bool ThisTokenAlreadyExists = false;
                    for (int i = 3; i < myStrings.Length; i++)
                    {
                        myAnotherString = myStrings[i];
                        myStrings[i - 1] = myAnotherString;
                        if (myToken == myAnotherString)
                        {
                            ThisTokenAlreadyExists = true;
                        }
                    }
                    if (!ThisTokenAlreadyExists)
                    {
                        myStrings[6] = myToken;
                        myString = charSeparater;
                        for (int i = 0; i < myStrings.Length; i++)
                        {
                            myString += charSeparater + myStrings[i];
                        }
                        await ThereIsServer.Actions.UpdateFile(ThereIsServer.ServersInfo.MyServers[0],
                            targetFile,
                            new DataBaseUpdateRequest("By SAO", QString.Parse(myString), ExistingFile.Sha));
                    }
                    else
                    {
                        // impossible to reach this branch of the code...
                    }
                }
                else
                {
                    myString = charSeparater;
                    for (int i = 0; i < myStrings.Length; i++)
                    {
                        myString += myStrings[i] + charSeparater;
                    }
                    myString += myToken;
                    await ThereIsServer.Actions.UpdateFile(ThereIsServer.ServersInfo.MyServers[0], 
                        targetFile,
                        new DataBaseUpdateRequest("By SAO", QString.Parse(myString), ExistingFile.Sha));
                }
                Father.IsSecuredMeWorkingOver = true;

                if (!Directory.Exists(ThereIsConstants.Path.Profile_Folder_Path))
                {
                    Directory.CreateDirectory(ThereIsConstants.Path.Profile_Folder_Path);
                }
                ProfileInfo myInfo = new ProfileInfo(_username.GetValue(), myToken.GetValue(),
                    ThereIsConstants.AppSettings.GlobalTiming.GetForServer().GetValue());
                ProfileInfo.UpdateInfo(myInfo, ThereIsConstants.Path.ProfileInfo_File_Path);
                AccountInfo myAccInfo = new AccountInfo(1,
                    ThereIsConstants.AppSettings.GlobalTiming.GetForServer().GetValue());
                AccountInfo.UpdateInfo(myAccInfo, ThereIsConstants.Path.AccountInfo_File_Path);
                GC.Collect();
            }
            //---------------------------------------
            private async void PriLinkStartWorker(object sender, EventArgs e)
            {
                ((Timer)sender).Enabled = false;
                ((Timer)sender).Dispose();
                //MessageBox.Show("I am");
                var targetFile = _username + endFileName;
                var ExistingFile =
                    await ThereIsServer.Actions.GetAllContentsByRef(ThereIsServer.ServersInfo.MyServers[0], 
                        targetFile);
                if(ExistingFile.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
                {
                    NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                    return;
                }
                StrongString[] myStrings = ExistingFile.Decode().Split(charSeparater);
                for (int i = 2; i < myStrings.Length; i++)
                {
                    if (_token == myStrings[i])
                    {
                        Father.HasLogin = true;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (Father.IsOnSecondStepOfLinkStart)
                {
                    ProfileInfo myInfo =
                        ProfileInfo.FromFile(ThereIsConstants.Path.ProfileInfo_File_Path);
                    myInfo.LastLogin =
                        ThereIsConstants.AppSettings.GlobalTiming.GetForServer().GetValue();
                    ProfileInfo.UpdateInfo(myInfo, ThereIsConstants.Path.ProfileInfo_File_Path);
                }
                Father.IsSecuredMeWorkingOver = true;
            }
            //------------------------------------------------
            private async void LogOuttWorker(object sender, EventArgs e)
            {
                ((Timer)sender).Enabled = false;
                ((Timer)sender).Dispose();
                //MessageBox.Show("I am");
                var targetFile = _username + endFileName;
                var ExistingFile =
                    await ThereIsServer.Actions.GetAllContentsByRef(ThereIsServer.ServersInfo.MyServers[0],
                        targetFile);
                if (ExistingFile.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
                {
                    NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                    return;
                }
                StrongString[] myStrings = ExistingFile.Decode().Split(charSeparater);
                StrongString myString = string.Empty;
                for (int i = 0; i < myStrings.Length; i++)
                {
                    if (_token == myStrings[i])
                    {
                        Father.HasLogin = true;
                        continue;
                    }
                    else
                    {
                        myString += charSeparater + myStrings[i];
                        continue;
                    }
                }
                await ThereIsServer.Actions.UpdateFile(ThereIsServer.ServersInfo.MyServers[0], 
                        targetFile,
                        new DataBaseUpdateRequest("By SAO123", QString.Parse(myString), ExistingFile.Sha));
                ThereIsConstants.Actions.ClearingPlayerProfile();

                Father.IsSecuredMeWorkingOver = true;
            }

            //------------------------------------------------
            /// <summary>
            /// consider this function will Generate a Token, based of this
            /// Client and System information.
            /// </summary>
            /// <returns></returns>
            private StrongString GenerateToken()
            {
                StrongString myString;
                myString = 
                    ThereIsConstants.AppSettings.GlobalTiming.GetForServer() + charSeparaterInToken +
                    ThereIsConstants.Actions.OSの伊にファーエー所運()         + charSeparaterInToken +
                    SystemInformation.ComputerName                           + charSeparaterInToken +
                    SystemInformation.UserName                               + charSeparaterInToken +
                    Dns.GetHostAddresses(Dns.GetHostName())[0].ToString()    + charSeparaterInToken;
                return myString;
            }
            //------------------------------------------------
        }
    }
}
