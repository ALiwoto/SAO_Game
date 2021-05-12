// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using Octokit;
using WotoProvider.EventHandlers;
using SAO.Client;
using SAO.SandBox;
using SAO.Security;
using SAO.Controls;
using SAO.Constants;
using SAO.LoadingService;
using SAO.GameObjects.Players;
using SAO.GameObjects.Kingdoms;

namespace SAO.GameObjects.ServerObjects
{
    public static class ThereIsServer
    {
        public struct Actions
        {
            //-------------------------------------------------
            /// <summary>
            /// Creating the Prifle for the Player.
            /// check here:
            /// <see cref="Me.CreateMeTimer_Tick(object, EventArgs)"/>
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public async static void TimeWorkerWorksForCreating(object sender, EventArgs e)
            {
                if (ThereIsConstants.Forming.TheMainForm.IsShowingSandBox)
                {
                    if (ThereIsConstants.Forming.TheMainForm.ShowingSandBox is CreateProfileSandBox mySandBox)
                    {
                        if (mySandBox.Enabled)
                        {
                            mySandBox.Enabled = false;
                        }
                        if (!mySandBox.LoadingSandBox.YuiWaitingPictureBox.IsDisposed)
                        {
                            if (!mySandBox.LoadingSandBox.YuiWaitingPictureBox.Focused)
                            {
                                mySandBox.LoadingSandBox.YuiWaitingPictureBox.Focus();
                            }
                        }
                        if (mySandBox.IsCheckingForExisting &&
                            !mySandBox.IsCheckingForExistingEnded)
                        {
                            //MessageBox.Show("CheckingForExisting");
                            return;
                        }
                        else if (mySandBox.IsCheckingForExistingEnded)
                        {
                            mySandBox.IsCheckingForExisting = false;
                            mySandBox.IsCheckingForExistingEnded = false;
                            if (mySandBox.DoesPlayerExists)
                            {
                                ((Timer)sender).Enabled = false;
                                mySandBox.LoadingSandBox.YuiWaitingPictureBox.Image.Dispose();
                                mySandBox.LoadingSandBox.Close(true);
                                mySandBox.Enabled = false;
                                mySandBox.IsShowingAnotherSandBox = true;
                                NoInternetConnectionSandBox errSandBox =
                                    new NoInternetConnectionSandBox(SandBoxMode.UserAlreadyExistMode,
                                    mySandBox.UnderForm);
                                ServerSettings.TimeWorker.Dispose();
                                ServerSettings.TimeWorker = null;
                                mySandBox.ShowingAnotherSandBox = errSandBox;
                                errSandBox.FormClosed += mySandBox.ErrorSandBox_FormClosed;
                                errSandBox.Show();
                                mySandBox.DoesPlayerExists = false;
                            }
                            else
                            {
                                ServerSettings.MyProfile.CreatePlayerProfile();
                                mySandBox.IsWaitingForCreating = true;
                                mySandBox.DoesPlayerExists = false;
                            }
                            /*
                            ThereIsConstants.Forming.TheMainForm.Focus();
                            mySandBox.Focus(); */
                        }
                        else if (mySandBox.IsWaitingForCreating && !mySandBox.IsCreatingEnded)
                        {
                            //nothing
                            return;
                        }
                        else if (mySandBox.IsCreatingEnded)
                        {
                            //MessageBox.Show("Here");
                            if (ServerSettings.MyProfile.IsWaitingForSecuredWorking &&
                                    !ServerSettings.MyProfile.IsSecuredMeWorkingOver)
                            {
                                //
                                return;
                            }
                            else if (ServerSettings.MyProfile.IsSecuredMeWorkingOver)
                            {
                                ((Timer)sender).Enabled                             = false;
                                mySandBox.IsCreatingEnded                           = false;
                                ServerSettings.MyProfile.IsWaitingForSecuredWorking = false;
                                ServerSettings.MyProfile.IsSecuredMeWorkingOver     = false;
                                //mySandBox.LoadingSandBox.YuiWaitingPictureBox.Hide();
                                mySandBox.LoadingSandBox.YuiWaitingPictureBox.Image.Dispose();
                                mySandBox.LoadingSandBox.Close(true);
                                mySandBox.Close(true);
                                ThereIsConstants.AppSettings.GameClient = new GameClient(true);
                                ThereIsConstants.AppSettings.GameClient.Show();
                                ThereIsConstants.AppSettings.GameClient.FirstTimeDesigning();
                                await Task.Run(() =>
                                {
                                    System.Threading.Thread.Sleep(3000);
                                });
                                ThereIsConstants.Forming.TheMainForm.ShowInTaskbar = false;
                                ThereIsConstants.Forming.TheMainForm.Hide();
                                //GlobalTimingWorker should stop displaying that bullshit Date and Time on Label of MainMenu.
                                ThereIsConstants.Forming.TheMainForm.MainMenuLoaded = false;
                                ThereIsConstants.Forming.TheMainForm.ReleaseAllResources();
                                //MessageBox.Show("Ended");

                            }
                        }
                    }


                }
            }
            /// <summary>
            /// SigingIn, values: <see cref="CreateProfileSandBox.IsSignInEnded"/>
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public async static void TimeWorkerWorksForSigningIn(object sender, EventArgs e)
            {
                if (ThereIsConstants.Forming.TheMainForm.IsShowingSandBox)
                {
                    if (ThereIsConstants.Forming.TheMainForm.ShowingSandBox is CreateProfileSandBox mySandBox)
                    {
                        if (mySandBox.Enabled)
                        {
                            mySandBox.Enabled = false;
                        }
                        if (!mySandBox.LoadingSandBox.YuiWaitingPictureBox.IsDisposed)
                        {
                            if (!mySandBox.LoadingSandBox.YuiWaitingPictureBox.Focused)
                            {
                                mySandBox.LoadingSandBox.YuiWaitingPictureBox.Focus();
                            }
                        }
                        if (mySandBox.IsCheckingForExisting &&
                            !mySandBox.IsCheckingForExistingEnded)
                        {
                            //MessageBox.Show("CheckingForExisting");
                            return;
                        }
                        else if (mySandBox.IsCheckingForExistingEnded)
                        {
                            mySandBox.IsCheckingForExisting = false;
                            mySandBox.IsCheckingForExistingEnded = false;
                            if (mySandBox.DoesPlayerExists)
                            {
                                ServerSettings.MyProfile.Login();
                                mySandBox.IsWaitingForSignIn = true;
                                mySandBox.DoesPlayerExists = false;
                            }
                            else
                            {
                                ((Timer)sender).Enabled = false;
                                mySandBox.LoadingSandBox.YuiWaitingPictureBox.Image.Dispose();
                                mySandBox.LoadingSandBox.Close(true);
                                mySandBox.Enabled = false;
                                mySandBox.IsShowingAnotherSandBox = true;
                                NoInternetConnectionSandBox errSandBox =
                                    new NoInternetConnectionSandBox(SandBoxMode.UserNameOrPasswordWrongMode,
                                    mySandBox.UnderForm);
                                ServerSettings.TimeWorker.Dispose();
                                ServerSettings.TimeWorker = null;
                                mySandBox.ShowingAnotherSandBox = errSandBox;
                                errSandBox.FormClosed += mySandBox.ErrorSandBox_FormClosed;
                                errSandBox.Show();
                                mySandBox.DoesPlayerExists = false;
                            }
                            /*
                            ThereIsConstants.Forming.TheMainForm.Focus();
                            mySandBox.Focus(); */
                        }
                        else if (mySandBox.IsWaitingForSignIn && !mySandBox.IsSignInEnded)
                        {
                            if (ServerSettings.MyProfile.IsWaitingForSecuredWorking &&
                                    !ServerSettings.MyProfile.IsSecuredMeWorkingOver)
                            {
                                //
                                return;
                            }
                            else if (ServerSettings.MyProfile.IsSecuredMeWorkingOver)
                            {
                                if (ServerSettings.MyProfile.HasLogin)
                                {
                                    ServerSettings.MyProfile.IsWaitingForSecuredWorking =
                                        ServerSettings.MyProfile.IsSecuredMeWorkingOver =
                                        false;
                                    //MessageBox.Show("Has");
                                    ServerSettings.MyProfile.Login(ServerSettings.MyProfile.HasLogin);
                                }
                                else
                                {
                                    ((Timer)sender).Enabled = false;
                                    mySandBox.LoadingSandBox.YuiWaitingPictureBox.Image.Dispose();
                                    mySandBox.LoadingSandBox.Close(true);
                                    mySandBox.Enabled = false;
                                    mySandBox.IsShowingAnotherSandBox = true;
                                    NoInternetConnectionSandBox errSandBox =
                                        new NoInternetConnectionSandBox(SandBoxMode.UserNameOrPasswordWrongMode,
                                        mySandBox.UnderForm);
                                    ServerSettings.TimeWorker.Dispose();
                                    ServerSettings.TimeWorker = null;
                                    //MessageBox.Show("WRONG");
                                    mySandBox.ShowingAnotherSandBox = errSandBox;
                                    errSandBox.FormClosed += mySandBox.ErrorSandBox_FormClosed;
                                    errSandBox.Show();
                                    mySandBox.DoesPlayerExists = false;
                                }
                            }

                            return;
                        }
                        else if (mySandBox.IsSignInEnded)
                        {

                            ((Timer)sender).Enabled                             = false;
                            mySandBox.IsSignInEnded                             = false;
                            ServerSettings.MyProfile.IsWaitingForSecuredWorking = false;
                            ServerSettings.MyProfile.IsSecuredMeWorkingOver     = false;
                            //mySandBox.LoadingSandBox.YuiWaitingPictureBox.Hide();
                            mySandBox.LoadingSandBox.YuiWaitingPictureBox.Image.Dispose();
                            mySandBox.LoadingSandBox.Close(true);
                            mySandBox.Close(true);
                            ThereIsConstants.AppSettings.GameClient = new GameClient(false);
                            ThereIsConstants.AppSettings.GameClient.Show();
                            //ThereIsConstants.AppSettings.GameClient.FirstTimeDesigning();
                            await Task.Run(() =>
                            {
                                System.Threading.Thread.Sleep(300);
                            });
                            ThereIsConstants.Forming.TheMainForm.ShowInTaskbar = false;
                            ThereIsConstants.Forming.TheMainForm.Hide();
                            //GlobalTimingWorker should stop displaying that bullshit Date and Time on Label of MainMenu.
                            ThereIsConstants.Forming.TheMainForm.MainMenuLoaded = false;
                            ThereIsConstants.Forming.TheMainForm.ReleaseAllResources();
                            //MessageBox.Show("Ended");
                        }
                    }
                }
            }
            /// <summary>
            /// LinkStart, check here: <see cref="Me.Link_Start(bool)"/>
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public async static void TimeWorkerWorksForPriLinkStart(object sender, EventArgs e)
            {
                if (ThereIsConstants.Forming.TheMainForm.IsShowingSandBox)
                {
                    if (ThereIsConstants.Forming.TheMainForm.ShowingSandBox is CreateProfileSandBox mySandBox)
                    {

                        if (ServerSettings.MyProfile.IsOnSecondStepOfLinkStart)
                        {
                            if (mySandBox.IsCheckingForExisting &&
                                !mySandBox.IsCheckingForExistingEnded)
                            {
                                //MessageBox.Show("CheckingForExisting");
                                return;
                            }
                            else if (mySandBox.IsCheckingForExistingEnded)
                            {
                                mySandBox.IsCheckingForExisting = false;
                                mySandBox.IsCheckingForExistingEnded = false;
                                if (mySandBox.DoesPlayerExists)
                                {
                                    ServerSettings.MyProfile.Link_Start();
                                    mySandBox.DoesPlayerExists = false;
                                }
                                else
                                {
                                    ((Timer)sender).Enabled = false;
                                    ServerSettings.TimeWorker.Dispose();
                                    ServerSettings.TimeWorker = null;
                                    mySandBox.LoadingSandBox.YuiWaitingPictureBox.Image.Dispose();
                                    //mySandBox.LoadingSandBox.Hide();
                                    mySandBox.LoadingSandBox.Close(true);
                                    mySandBox.Enabled = false;
                                    mySandBox.IsShowingAnotherSandBox = true;
                                    NoInternetConnectionSandBox errSandBox =
                                        new NoInternetConnectionSandBox(SandBoxMode.Cant_LoadYourProfileMode,
                                        mySandBox.UnderForm);
                                    ServerSettings.TimeWorker.Dispose();
                                    ServerSettings.TimeWorker = null;
                                    mySandBox.ShowingAnotherSandBox = errSandBox;
                                    errSandBox.FormClosed += mySandBox.ErrorSandBox_FormClosed;
                                    errSandBox.Show();
                                    mySandBox.DoesPlayerExists = false;
                                }
                                /*
                                ThereIsConstants.Forming.TheMainForm.Focus();
                                mySandBox.Focus(); */
                            }
                            else if (ServerSettings.MyProfile.IsWaitingForSecuredWorking &&
                                    !ServerSettings.MyProfile.IsSecuredMeWorkingOver)
                            {
                                ; //nothing.
                                return;
                            }
                            else if (ServerSettings.MyProfile.IsSecuredMeWorkingOver)
                            {
                                if (ServerSettings.MyProfile.HasLogin)
                                {
                                    ServerSettings.MyProfile.IsSecuredMeWorkingOver     = false;
                                    ServerSettings.MyProfile.IsWaitingForSecuredWorking = false;
                                    mySandBox.IsWaitingForSignIn                        = true;
                                    mySandBox.IsSignInEnded                             = false;
                                    ServerSettings.MyProfile.Login(ServerSettings.MyProfile.HasLogin);
                                }
                                else
                                {
                                    ((Timer)sender).Enabled = false;
                                    ServerSettings.TimeWorker.Dispose();
                                    ServerSettings.TimeWorker = null;
                                    mySandBox.LoadingSandBox.YuiWaitingPictureBox.Image.Dispose();
                                    ServerSettings.MyProfile.IsWaitingForSecuredWorking = false;
                                    ServerSettings.MyProfile.IsSecuredMeWorkingOver = false;
                                    //mySandBox.LoadingSandBox.Hide();
                                    mySandBox.LoadingSandBox.Close(true);
                                    mySandBox.Enabled = false;
                                    mySandBox.IsShowingAnotherSandBox = true;
                                    NoInternetConnectionSandBox errSandBox =
                                        new NoInternetConnectionSandBox(SandBoxMode.Cant_LoadYourProfileMode,
                                        mySandBox.UnderForm);
                                    ServerSettings.TimeWorker.Dispose();
                                    ServerSettings.TimeWorker = null;
                                    mySandBox.ShowingAnotherSandBox = errSandBox;
                                    mySandBox.IsShowingAnotherSandBox = true;
                                    errSandBox.FormClosed += mySandBox.ErrorSandBox_FormClosed;
                                    errSandBox.Show();
                                    mySandBox.DoesPlayerExists = false;
                                    ServerSettings.MyProfile = null;
                                }
                                /*
                                ((Timer)sender).Enabled = false;
                                mySandBox.LoadingSandBox.YuiWaitingPictureBox.Image.Dispose();
                                //mySandBox.LoadingSandBox.Hide();
                                mySandBox.LoadingSandBox.Close();
                                ServerSettings.TimeWorker.Dispose();
                                ServerSettings.TimeWorker = null;
                                mySandBox.DoesPlayerExists = false;
                                mySandBox.CallMe(true);
                                */
                            }
                            else if(mySandBox.IsWaitingForSignIn && !mySandBox.IsSignInEnded)
                            {
                                return;
                            }
                            else if (mySandBox.IsSignInEnded)
                            {
                                ((Timer)sender).Enabled = false;
                                ServerSettings.TimeWorker.Dispose();
                                ServerSettings.TimeWorker = null;
                                mySandBox.IsSignInEnded = false;
                                ServerSettings.MyProfile.IsWaitingForSecuredWorking = false;
                                ServerSettings.MyProfile.IsSecuredMeWorkingOver = false;
                                //mySandBox.LoadingSandBox.YuiWaitingPictureBox.Hide();
                                mySandBox.LoadingSandBox.YuiWaitingPictureBox.Image.Dispose();
                                //mySandBox.LoadingSandBox.Hide();
                                mySandBox.LoadingSandBox.AnimationFactory.Dispose();
                                mySandBox.LoadingSandBox.Close(true);
                                mySandBox.Close(true);
                                ThereIsConstants.AppSettings.GameClient = new GameClient(false);
                                ThereIsConstants.AppSettings.GameClient.Show();
                                //ThereIsConstants.AppSettings.GameClient.FirstTimeDesigning();
                                await Task.Delay(300);
                                ThereIsConstants.Forming.TheMainForm.ShowInTaskbar = false;
                                ThereIsConstants.Forming.TheMainForm.Hide();
                                //GlobalTimingWorker should stop displaying that bullshit Date and Time on Label of MainMenu.
                                ThereIsConstants.Forming.TheMainForm.MainMenuLoaded = false;
                                ThereIsConstants.Forming.TheMainForm.ReleaseAllResources();
                                //MessageBox.Show("Ended");
                            }
                        }
                        else
                        {
                            if (mySandBox.IsCheckingForExisting &&
                            !mySandBox.IsCheckingForExistingEnded)
                            {
                                //MessageBox.Show("CheckingForExisting");
                                return;
                            }
                            else if (mySandBox.IsCheckingForExistingEnded)
                            {
                                mySandBox.IsCheckingForExisting = false;
                                mySandBox.IsCheckingForExistingEnded = false;
                                if (mySandBox.DoesPlayerExists)
                                {
                                    ServerSettings.MyProfile.Link_Start();
                                    mySandBox.DoesPlayerExists = false;
                                }
                                else
                                {
                                    ((Timer)sender).Enabled = false;
                                    mySandBox.LoadingSandBox.YuiWaitingPictureBox.Image.Dispose();
                                    //mySandBox.LoadingSandBox.Hide();
                                    mySandBox.LoadingSandBox.Close(true);
                                    mySandBox.Enabled = false;
                                    mySandBox.IsShowingAnotherSandBox = true;
                                    NoInternetConnectionSandBox errSandBox =
                                        new NoInternetConnectionSandBox(SandBoxMode.Cant_LoadYourProfileMode,
                                        mySandBox.UnderForm);
                                    ServerSettings.TimeWorker.Dispose();
                                    ServerSettings.TimeWorker = null;
                                    mySandBox.ShowingAnotherSandBox = errSandBox;
                                    errSandBox.FormClosed += mySandBox.ErrorSandBox_FormClosed;
                                    errSandBox.Show();
                                    mySandBox.DoesPlayerExists = false;
                                }
                                /*
                                ThereIsConstants.Forming.TheMainForm.Focus();
                                mySandBox.Focus(); */
                            }
                            else if (ServerSettings.MyProfile.IsWaitingForSecuredWorking &&
                                    !ServerSettings.MyProfile.IsSecuredMeWorkingOver)
                            {
                                ; //nothing.
                                return;
                            }
                            else if (ServerSettings.MyProfile.IsSecuredMeWorkingOver)
                            {
                                if (ServerSettings.MyProfile.HasLogin)
                                {
                                    ((Timer)sender).Enabled = false;
                                    ServerSettings.TimeWorker.Dispose();
                                    ServerSettings.TimeWorker = null;
                                    ServerSettings.MyProfile.IsWaitingForSecuredWorking = false;
                                    ServerSettings.MyProfile.IsSecuredMeWorkingOver = false;
                                    ServerSettings.MyProfile.HasLogin = false;
                                    mySandBox.LoadingSandBox.YuiWaitingPictureBox.Image.Dispose();
                                    //mySandBox.LoadingSandBox.Hide();
                                    mySandBox.LoadingSandBox.AnimationFactory.Dispose();
                                    mySandBox.LoadingSandBox.Close(true);
                                    mySandBox.LoadingSandBox = null;
                                    mySandBox.IsShowingAnotherSandBox = false;
                                    mySandBox.ShowingAnotherSandBox = null;
                                    mySandBox.DoesPlayerExists = false;
                                    mySandBox.CallMe(true);
                                }
                                else
                                {
                                    ((Timer)sender).Enabled = false;
                                    ServerSettings.TimeWorker.Dispose();
                                    ServerSettings.TimeWorker = null;
                                    ServerSettings.MyProfile.IsWaitingForSecuredWorking = false;
                                    ServerSettings.MyProfile.IsSecuredMeWorkingOver = false;
                                    ServerSettings.MyProfile = null;
                                    mySandBox.LoadingSandBox.YuiWaitingPictureBox.Image.Dispose();
                                    mySandBox.LoadingSandBox.Close(true);
                                    mySandBox.Enabled = false;
                                    mySandBox.IsShowingAnotherSandBox = true;
                                    NoInternetConnectionSandBox errSandBox =
                                        new NoInternetConnectionSandBox(SandBoxMode.Cant_LoadYourProfileMode,
                                        mySandBox.UnderForm);
                                    mySandBox.ShowingAnotherSandBox = errSandBox;
                                    errSandBox.FormClosed += mySandBox.ErrorSandBox_FormClosed;
                                    errSandBox.Show();
                                    mySandBox.DoesPlayerExists = false;
                                    GC.Collect();
                                }
                            }
                        }
                        
                    }
                }
            }
            /// <summary>
            /// Loging out Timer Worker, setted in <see cref="Me.LogOut(bool, bool)"/>
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public static void TimeWorkerWorksForLogingOut(object sender, EventArgs e)
            {
                if (ThereIsConstants.Forming.TheMainForm.IsShowingSandBox)
                {
                    if (ThereIsConstants.Forming.TheMainForm.ShowingSandBox is CreateProfileSandBox mySandBox)
                    {

                        if (mySandBox.IsCheckingForExisting &&
                            !mySandBox.IsCheckingForExistingEnded)
                        {
                            //MessageBox.Show("CheckingForExisting");
                            return;
                        }
                        else if (mySandBox.IsCheckingForExistingEnded)
                        {
                            mySandBox.IsCheckingForExisting = false;
                            mySandBox.IsCheckingForExistingEnded = false;
                            if (mySandBox.DoesPlayerExists)
                            {
                                ServerSettings.MyProfile.LogOut(true);
                                mySandBox.DoesPlayerExists = false;
                            }
                            else
                            {
                                ((Timer)sender).Enabled = false;
                                mySandBox.LoadingSandBox.YuiWaitingPictureBox.Image.Dispose();
                                mySandBox.LoadingSandBox.Close(true);
                                mySandBox.Enabled = false;
                                mySandBox.IsShowingAnotherSandBox = true;
                                NoInternetConnectionSandBox errSandBox =
                                    new NoInternetConnectionSandBox(SandBoxMode.Cant_LoadYourProfileMode,
                                    mySandBox.UnderForm);
                                ServerSettings.TimeWorker.Dispose();
                                ServerSettings.TimeWorker = null;
                                mySandBox.ShowingAnotherSandBox = errSandBox;
                                errSandBox.FormClosed += mySandBox.ErrorSandBox_FormClosed;
                                errSandBox.Show();
                                mySandBox.DoesPlayerExists = false;
                            }
                            /*
                            ThereIsConstants.Forming.TheMainForm.Focus();
                            mySandBox.Focus(); */
                        }
                        else if (ServerSettings.MyProfile.IsWaitingForSecuredWorking &&
                                !ServerSettings.MyProfile.IsSecuredMeWorkingOver)
                        {
                            ; //nothing.
                            return;
                        }
                        else if (ServerSettings.MyProfile.IsSecuredMeWorkingOver)
                        {
                            if (ServerSettings.MyProfile.HasLogin)
                            {
                                ((Timer)sender).Enabled = false;
                                ServerSettings.TimeWorker.Dispose();
                                ServerSettings.TimeWorker = null;
                                ServerSettings.MyProfile.IsSecuredMeWorkingOver     = false;
                                ServerSettings.MyProfile.IsWaitingForSecuredWorking = false;
                                mySandBox.LoadingSandBox.YuiWaitingPictureBox.Image.Dispose();
                                //mySandBox.LoadingSandBox.Hide();
                                mySandBox.LoadingSandBox.Close(true);
                                mySandBox.Enabled                   = false;
                                mySandBox.IsShowingAnotherSandBox   = true;
                                mySandBox.HasLoggedOut              = true;
                                NoInternetConnectionSandBox errSandBox =
                                    new NoInternetConnectionSandBox(SandBoxMode.LoggedOutSuccessfullyMode,
                                    mySandBox.UnderForm);
                                mySandBox.ShowingAnotherSandBox = errSandBox;

                                errSandBox.FormClosed += mySandBox.ErrorSandBox_FormClosed;

                                errSandBox.Show();
                                mySandBox.DoesPlayerExists = false;
                            }
                            else
                            {
                                ((Timer)sender).Enabled = false;
                                mySandBox.LoadingSandBox.YuiWaitingPictureBox.Image.Dispose();
                                mySandBox.LoadingSandBox.Close(true);
                                mySandBox.Enabled = false;
                                mySandBox.IsShowingAnotherSandBox = true;
                                NoInternetConnectionSandBox errSandBox =
                                    new NoInternetConnectionSandBox(SandBoxMode.Cant_LoadYourProfileMode,
                                    mySandBox.UnderForm);
                                ServerSettings.TimeWorker.Dispose();
                                ServerSettings.TimeWorker = null;
                                mySandBox.ShowingAnotherSandBox = errSandBox;
                                errSandBox.FormClosed += mySandBox.ErrorSandBox_FormClosed;
                                errSandBox.Show();
                                mySandBox.DoesPlayerExists = false;
                            }
                            /*
                             * 
                            */
                        }

                    }
                }
            }
            /// <summary>
            /// Worker for <see cref="GameClient.AnimationFactory"/>.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public static async void TimeWorkerWorksForGameClientLoading(object sender, EventArgs e)
            {
                if (ThereIsConstants.Forming.GameClient.IsLoading && 
                    !ThereIsConstants.Forming.GameClient.IsLoadingEnded)
                {
                    if(ThereIsConstants.Forming.GameClient.MessageLabel1.Text.IndexOf("...") != -1)
                    {
                        ThereIsConstants.Forming.GameClient.MessageLabel1.SetLabelText();
                    }
                    else
                    {
                        ThereIsConstants.Forming.GameClient.MessageLabel1.Text += ".";
                    }
                }
                else if (ThereIsConstants.Forming.GameClient.IsLoadingEnded)
                {
                    ((Timer)sender).Enabled = false;
                    ((Timer)sender).Dispose();
                    if(GameObjects.MyProfile.PlayerKingdom != SAO_Kingdoms.NotSet)
                    {
                        GameObjects.MyProfile.KingdomInfo =
                        await KingdomInfo.GetKingdomInfo((uint)GameObjects.MyProfile.PlayerKingdom);
                    }
                    ThereIsConstants.Forming.GameClient.AnimationFactory = null;
                    ThereIsConstants.Forming.GameClient.GameClientHandler();
                    GC.Collect();
                }
            }
            //-------------------------------------------------
            /// <summary>
            /// Checking the server status.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public static async void CheckingServerWorker(Trigger sender, TickHandlerEventArgs<Trigger> handler)
            {
                if (ServerSettings.IsWaitingForServerChecking || handler == null)
                {
                    return;
                }
                else
                {
                    ServerSettings.IsWaitingForServerChecking = true;
                }
                var existingFile =
                await GetAllContentsByRef(ServersInfo.MyServers[0], 
                        ServerSettings.ServerChecking_File_Name);
                await Task.Delay(300);
                if (ServerSettings.HasConnectionClosed)
                {
                    sender.Enabled = false;
                    ServerSettings.ServerChecker.Dispose();
                    ServerSettings.ServerChecker = null;
                    NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                    return; // don't set ServerSettings.IsWaitingForServerChecking = false;
                }
                if (existingFile == null)
                {
                    sender.Enabled              = false;
                    ServerSettings.ServerChecker.Dispose();
                    ServerSettings.ServerChecker = null;
                    NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                    return; // don't set ServerSettings.IsWaitingForServerChecking = false;
                }
                var minNow = existingFile[0];
                StrongString CurrentText;
                if (minNow.EncodedContent != null)
                {
                    CurrentText = 
                        Encoding.UTF8.GetString(Convert.FromBase64String(minNow.EncodedContent.GetValue()));
                }
                else
                {
                    CurrentText = minNow.Content.GetStrong();
                }
                if(CurrentText.IndexOf(ServerSettings.Y_S) == -1)
                {
                    sender.Enabled = false;
                    ServerSettings.ServerChecker.Dispose();
                    ServerSettings.ServerChecker = null;
                    NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                    return;
                }
                ServerSettings.IsWaitingForServerChecking = false;
            }
            //-------------------------------------------------
            /// <summary>
            /// create a new space for data in the database, using an specified 
            /// path in the database.
            /// </summary>
            /// <param name="serverInfo">
            /// the server info which is for accessing the database.
            /// </param>
            /// <param name="path">
            /// the path of the specific space in the database.
            /// </param>
            /// <param name="request">
            /// the request.
            /// </param>
            /// <returns></returns>
            public static async Task<DataBaseDataChangedInfo> CreateFile(ServerInfo serverInfo, 
                StrongString path, DataBaseCreation request)
            {
                RepositoryContentChangeSet myChangeSet = null;
                uint trys = 0;
                for (; ; )
                {
                    try
                    {
                        myChangeSet = await serverInfo.GetClient().
                            Repository.Content.CreateFile(serverInfo.Owner.GetValue(),
                            serverInfo.Repo.GetValue(), path.GetValue(),
                            request);
                        break;
                    }
                    catch
                    {
                        if (trys >= ServerSettings.MAXIMUM_TRY)
                        {
                            ServerSettings.HasConnectionClosed = true;
                            break;
                        }
                        else
                        {
                            trys++;
                            continue;
                        }

                    }
                }
                return DataBaseDataChangedInfo.GetInfo(myChangeSet);
            }
            
            public static async Task<DataBaseContent> GetAllContentsByRef(ServerInfo serverInfo, StrongString path)
            {
                DataBaseContent Existings = DataBaseContent.GetDeadCallBack();
                uint trys = 0;
                for (; ; )
                {
                    try
                    {
                        string owner = serverInfo.Owner.GetValue();
                        string repo = serverInfo.Repo.GetValue();
                        string mypath = path.GetValue();
                        string thevranch = serverInfo.Branch.GetValue();
                        GitHubClient huhu = serverInfo.GetClient();
                        string haha = ThereIsConstants.AppSettings.WotoCreation.Procedural;
                        Existings = DataBaseContent.GetBaseContent(
                            await serverInfo.GetClient().
                         Repository.Content.GetAllContentsByRef(serverInfo.Owner.GetValue(),
                         serverInfo.Repo.GetValue(), path.GetValue(), serverInfo.Branch.GetValue()), 
                            ThereIsConstants.AppSettings.WotoCreation.Procedural);

                        break;
                    }
                    catch (Exception exp)
                    {
                        if (exp.Message.IndexOf(ServerSettings.CC_ERR_MSG) != 0)
                        {
                            if(trys >= ServerSettings.MAXIMUM_TRY)
                            {
                                ServerSettings.HasConnectionClosed = true;
                                break;
                            }
                            else
                            {
                                trys += 10;
                                continue;
                            }
                        }

                        if (trys >= ServerSettings.MAXIMUM_TRY)
                        {
                            ServerSettings.HasConnectionClosed = true;
                            break;
                        }
                        else
                        {
                            trys++;
                            continue;
                        }

                    }
                }
                return Existings;

            }
            
            public static async Task<DataBaseDataChangedInfo> UpdateFile(ServerInfo serverInfo,
                StrongString path, DataBaseUpdateRequest request)
            {

                RepositoryContentChangeSet myChangeSet = null;
                uint trys = 0;
                for (; ; )
                {
                    try
                    {
                        myChangeSet = await serverInfo.GetClient().Repository.Content.
                          UpdateFile(serverInfo.Owner.GetValue(),
                            serverInfo.Repo.GetValue(), path.GetValue(),
                            request);

                        break;
                    }
                    catch
                    {
                        if (trys >= ServerSettings.MAXIMUM_TRY)
                        {
                            ServerSettings.HasConnectionClosed = true;
                            break;
                        }
                        else
                        {
                            trys++;
                            continue;
                        }

                    }
                }
                return DataBaseDataChangedInfo.GetInfo(myChangeSet);
            }
            public static async Task<bool> DeleteFile(ServerInfo serverInfo, StrongString path,
                DataBaseDeleteRequest request)
            {
                uint trys = 0;
                bool mayushii = false;
                for (; ; )
                {
                    try
                    {
                         await serverInfo.GetClient().Repository.Content.
                          DeleteFile(serverInfo.Owner.GetValue(),
                            serverInfo.Repo.GetValue(), path.GetValue(),
                            request);
                        mayushii = true;
                        break;
                    }
                    catch(NotFoundException)
                    {
                        //mayushii = false;
                        break;
                    }
                    catch(ApiException myErr)
                    {
                        if(myErr.Message.IndexOf(request.Sha) != -1)
                        {
                            mayushii = true;
                            //MessageBox.Show(myErr.Message);
                            break;
                        }
                        else
                        {
                            if (trys >= ServerSettings.MAXIMUM_TRY)
                            {
                                ServerSettings.HasConnectionClosed = true;
                                break;
                            }
                            else
                            {
                                trys++;
                                continue;
                            }
                        }
                    }
                    catch(Exception err)
                    {
                        if (err.Message.IndexOf(request.Sha) != -1)
                        {
                            mayushii = true;
                            //MessageBox.Show(myErr.Message);
                            break;
                        }
                        else
                        {
                            if (trys >= ServerSettings.MAXIMUM_TRY)
                            {
                                ServerSettings.HasConnectionClosed = true;
                                break;
                            }
                            else
                            {
                                trys++;
                                continue;
                            }
                        }
                    }
                }
                return mayushii;
            }
        }
        public struct ServerSettings
        {
            //---------------------------------------------
            public static Timer TimeWorker { get; set; }
            public static Trigger ServerChecker { get; set; }
            public static Me MyProfile { get; set; }
            //---------------------------------------------
            public static StrongString TokenObj { get; set; }
            //---------------------------------------------
            public const string Y_S = "Y";
            public const string N_S = "N";
            public const string ServerChecking_File_Name = "Status.Sao";
            public const string CC_ERR_MSG = "An error occurred while sending the request.";
            public const uint MAXIMUM_TRY = 50;
            //---------------------------------------------
            public static bool HasConnectionClosed { get; internal set; }
            public static bool IsWaitingForServerChecking { get; set; }
            //---------------------------------------------
        }
        public struct GameObjects
        {
            //--------------------------------------
            //--------------------------------------
            public static Me MyProfile
            {
                get
                {
                    return ServerSettings.MyProfile;
                }
                set
                {
                    ServerSettings.MyProfile = value;
                }
            }
            public static StrongString TokenObj
            {
                get
                {
                    return ServerSettings.TokenObj;
                }
                set
                {
                    ServerSettings.TokenObj = value;
                }
            }
            //--------------------------------------
        }
        public struct ServersInfo
        {
            public static ServerInfo[] MyServers =
            {
                // for SAO_Game
                new ServerInfo("<(REPO_NAME)>", "<(TOKEN)>",
                    "<(USER_NAME)>", "<(REPO_NAME)>", "<(BRANCH)>"), // Index: 0
                // for North Kingdom
                new ServerInfo("<(REPO_NAME)>", "<(TOKEN)>",
                    "<(USER_NAME)>", "<(REPO_NAME)>", "<(BRANCH)>"), // Index: 1
                // for South Kingdom
                new ServerInfo("<(REPO_NAME)>", "<(TOKEN)>",
                    "<(USER_NAME)>", "<(REPO_NAME)>", "<(BRANCH)>"), // Index: 2
                // for West Kingdom
                new ServerInfo("<(REPO_NAME)>", "<(TOKEN)>",
                    "<(USER_NAME)>", "<(REPO_NAME)>", "<(BRANCH)>"), // Index: 3
                // for East Kingdom
                new ServerInfo("<(REPO_NAME)>", "<(TOKEN)>",
                    "<(USER_NAME)>", "<(REPO_NAME)>", "<(BRANCH)>"), // Index: 4
                // for Private Chats
                new ServerInfo("<(REPO_NAME)>", "<(TOKEN)>",
                    "<(USER_NAME)>", "<(REPO_NAME)>", "<(BRANCH)>"), // Index: 5
                // for kingdom1 Chats
                new ServerInfo("<(REPO_NAME)>", "<(TOKEN)>",
                    "<(USER_NAME)>", "<(REPO_NAME)>", "<(BRANCH)>"), // Index: 6
                // for kingdom2 Chats
                new ServerInfo("<(REPO_NAME)>", "<(TOKEN)>",
                    "<(USER_NAME)>", "<(REPO_NAME)>", "<(BRANCH)>"), // Index: 7
                // for kingdom3 Chats
                new ServerInfo("<(REPO_NAME)>", "<(TOKEN)>",
                    "<(USER_NAME)>", "<(REPO_NAME)>", "<(BRANCH)>"), // Index: 8
                // for kingdom4 Chats
                new ServerInfo("<(REPO_NAME)>", "<(TOKEN)>",
                    "<(USER_NAME)>", "<(REPO_NAME)>", "<(BRANCH)>"), // Index: 9
                // for Guild Chats
                new ServerInfo("<(REPO_NAME)>", "<(TOKEN)>",
                    "<(USER_NAME)>", "<(REPO_NAME)>", "<(BRANCH)>"), // Index: 10
                // for Cross Chats
                new ServerInfo("<(REPO_NAME)>", "<(TOKEN)>",
                    "<(USER_NAME)>", "<(REPO_NAME)>", "<(BRANCH)>"), // Index: 11
                // for System Chats
                new ServerInfo("<(REPO_NAME)>", "<(TOKEN)>",
                    "<(USER_NAME)>", "<(REPO_NAME)>", "<(BRANCH)>"), // Index: 12
            };
            /// <summary>
            /// username of user + _LogedIn
            /// </summary>
            public const string EndCheckingFileName = "_LogedIn";
            /*
            public struct Server1
            {
                public const string ProductHeaderValue  = "";
                public const string Token               = "";
                public const string Owner               = "";
                public const string Repo                = "";
                public const string Branch              = "";
                /// <summary>
                /// username of user + _LogedIn
                /// </summary>
                public const string EndCheckingFileName = "";
                //------------------------------------------
                public static GitHubClient ServerClient = new GitHubClient(new ProductHeaderValue(ProductHeaderValue))
                {
                    Credentials = new Credentials(Token)
                };
            }
            /// <summary>
            /// The Server for North Kingdom.
            /// </summary>
            public struct Server2
            {
                // 
                public const string ProductHeaderValue = "";
                public const string Token = "";
                public const string Owner = "";
                public const string Repo = "";
                public const string Branch = "master";
                //------------------------------------------
                public static GitHubClient ServerClient = new GitHubClient(new ProductHeaderValue(ProductHeaderValue))
                {
                    Credentials = new Credentials(Token)
                };
            }
            /// <summary>
            /// The Server For South.
            /// </summary>
            public struct Server3
            {
                //67830432c366276e835c90a26a5691eff7582857 
                public const string ProductHeaderValue = "South";
                public const string Token = "";
                public const string Owner = "";
                public const string Repo = "";
                public const string Branch = "";
                //------------------------------------------
                public static GitHubClient ServerClient = new GitHubClient(new ProductHeaderValue(ProductHeaderValue))
                {
                    Credentials = new Credentials(Token)
                };
            }
            */
        }
    }
}
