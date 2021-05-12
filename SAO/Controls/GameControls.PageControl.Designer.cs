// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.


using System.Windows.Forms;
using System.ComponentModel;
using WotoProvider.WotoTools;
using SAO.Client;

namespace SAO.Controls
{
    partial class GameControls
    {
        partial class PageControl
        {
            private void InitializeComponent()
            {
                //-----------------------------------------
                //-----------------------------------------
                this.KeyPreview = true;
                //-----------------------------------------

            }
            protected override void OnKeyDown(KeyEventArgs e)
            {
                if (e.KeyCode == Keys.F11)
                {
                    if (Taskbar.IsShowing)
                    {
                        Taskbar.Hide();
                    }
                    else
                    {
                        Taskbar.Show();
                    }
                    this.Focus();
                }
                else if (e.KeyCode == Keys.LWin || e.KeyCode == Keys.RWin)
                {
                    if (!Taskbar.IsShowing)
                    {
                        Taskbar.Show();
                    }
                }
                base.OnKeyDown(e);
            }
            protected override void OnClosing(CancelEventArgs e)
            {
                if (!Taskbar.IsShowing)
                {
                    if (this is MainForm || this is GameClient)
                    {
                        Taskbar.Show();
                    }
                }
                base.OnClosing(e);
            }
        }
    }
}