// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using SAO.Security;
using SAO.Constants;

namespace SAO.Controls
{
    partial class GameControls
    {
        partial class LabelBase
        {
            //---------------------------------------------
            #region Empty Region :|
            private void InitializeComponent()
            {
                
                //----------------------------------
                //News:
                //----------------------------------
                //Names:
                //TabIndexes
                //FontAndTextAligns:
                //Sizes:
                //Locations:
                //Colors:
                //ComboBoxes:
                //Enableds:
                //Texts:
                //AddRanges:
                //ToolTipSettings:
                //----------------------------------
                //Events:
                //----------------------------------
            }
            public virtual void ReloadUPW()
            {
                ;
            }
            public virtual void SetLabelText()
            {
                ;
            }
            public virtual void SetLabelName(string constParam)
            {

            }
            public virtual void SetLabelText(string customValue)
            {

            }
            public virtual void SetLabelText(StrongString customValue)
            {

            }
            public virtual void SetColorTransparent()
            {

            }
            public virtual void SetTextColor(Color color)
            {

            }
            public virtual void SetLabelSoundEffects(Noises theValue)
            {

            }
            public virtual void AddClickEventToAllChild(EventHandler myEvent, bool setForMyself = false)
            {

            }
            public virtual void AddEnterEventToAllChild(EventHandler myEvent, bool setForMyself = true)
            {

            }
            public virtual void AddLeaveEventToAllChild(EventHandler myEvent, bool setForMyself = true)
            {

            }
            public virtual void RefreshPaintWorks()
            {
                // nothing is here
            }
            public virtual void SetPaintColor(Color color, int index)
            {
                
            }
            public virtual void SetPaintBrush(Brush brush, int index)
            {
                
            }
            public virtual void SetPaintPen(Pen pen, int index)
            {
                
            }
            #endregion
            //---------------------------------------------
            #region Overrided Methods Region
            public override void Refresh()
            {
                if (!DrawNothing)
                {
                    base.Refresh();
                }
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                if (!DrawNothing)
                {
                    base.OnPaint(e);

                }
            }
            protected override void OnInvalidated(InvalidateEventArgs e)
            {
                if (!DrawNothing)
                {
                    base.OnInvalidated(e);

                }
            }
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == ThereIsConstants.Actions.WM_SETREDRAW)
                {
                    if (DrawNothing)
                    {
                        m.Msg = 0;
                        m.Result = (IntPtr)0;
                    }
                }
                base.WndProc(ref m);
            }
            protected override void OnPaintBackground(PaintEventArgs pevent)
            {
                if (!DrawNothing)
                {
                    base.OnPaintBackground(pevent);
                }
                else
                {
                    pevent.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    base.OnPaintBackground(pevent);
                }
            }
            #endregion
            //---------------------------------------------
        }
    }
}
