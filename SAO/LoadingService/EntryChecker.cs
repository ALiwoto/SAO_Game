// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using Microsoft.VisualBasic.ApplicationServices;
using System.IO;
using SAO.Constants;

namespace SAO.LoadingService
{
    /// <summary>
    /// sao EntryChecker
    /// </summary>
    partial class EntryChecker : WindowsFormsApplicationBase
    {
        /// <summary>
        /// EntryChecker of the SAO.
        /// </summary>
        public EntryChecker()
        {
            // check if the main directory exists in the player system or noy.
            if (!Directory.Exists(ThereIsConstants.Path.main_Path))
            {
                // create the main path of the game.
                Directory.CreateDirectory(ThereIsConstants.Path.main_Path);
            }
            // create a new instance of the main form for game
            // and set the Property in the ThereIsConstant's class.
            MainForm = new MainForm();
            ThereIsConstants.Forming.TheMainForm = (MainForm)MainForm;
            IsSingleInstance = true;
        }
        /// <summary>
        /// the next start up event.
        /// </summary>
        /// <param name="eventArgs"></param>
        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            eventArgs.BringToForeground = true;
            if (MainForm != null)
            {
                ((MainForm)MainForm).ComeOnUp();
            }
            else
            {
                ThereIsConstants.Forming.TheMainForm.ComeOnUp();
            }
            //Also, ThereIsConstants.Forming.TheMainForm property will define in ComeOnUp.
        }
    }
}
