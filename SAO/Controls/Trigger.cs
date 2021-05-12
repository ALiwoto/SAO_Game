// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Windows.Forms;
using System.ComponentModel;
using WotoProvider.EventHandlers;
using SAO.Constants;

namespace SAO.Controls
{
    /// <summary>
    /// The Trigger for creating an AnimationFactory.
    /// </summary>
    [DesignerCategory("")]
    public class Trigger : Timer
    {
        //-------------------------------------------------
        #region Constant's Region
        /// <summary>
        /// ToString value used in ToString() method.
        /// </summary>
        public const string ToStringValue = "-- Trigger -- By wotoTeam Cor.";
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public string Name { get; set; }
        public uint Index { get; set; }
        /// <summary>
        /// When you want only one worker work on this Trigger,
        /// then set this to true in your Worker's method.
        /// </summary>
        public bool Running_Worker { get; set; }
        public bool SingleLineWorker { get; set; } = true;
        public bool IsOnceUsing { get; }
        #endregion
        //-------------------------------------------------
        #region Events Region
        public new event TickHandler<Trigger> Tick;
        public TickHandlerEventArgs<Trigger> EventArg { get; private set; }
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        public Trigger() : base()
        {
            EventArg =
                new TickHandlerEventArgs<Trigger>(ThereIsConstants.AppSettings.WotoCreation, this);
            IsOnceUsing = false;
        }
        /// <summary>
        /// crete a new once using trigger, if the once using value is true,
        /// and set the interval to 10 ms.
        /// </summary>
        /// <param name="isOnceUsing">
        /// if this trigger is once-using, you should pass true.
        /// </param>
        public Trigger(bool isOnceUsing)
        {
            EventArg =
                new TickHandlerEventArgs<Trigger>(ThereIsConstants.AppSettings.WotoCreation, this);
            IsOnceUsing = isOnceUsing;
            Interval = 10;
        }
        ~Trigger()
        {
            if (Name != null)
            {
                Name        = null;
                Tick        = null;
                EventArg    = null;
            }
        }
        #endregion
        //-------------------------------------------------
        #region overrided Method's Region
        protected override void OnTick(EventArgs e)
        {
            // check if Running_Worker is true or not,
            // then check the single line worker value,
            // if both of them are set to true, you are not allowed
            // to trigger the event handler.
            if (Running_Worker && SingleLineWorker)
            {
                // it means the previous handler is not still running,
                // and this trigger is single line worker.
                return;
            }
            else
            {
                // check if this trigger status enable or not
                if (!Enabled)
                {
                    // if this trigger is not enabled, return
                    return;
                }
                // WARNING: do not set the Running_Worker to true
                // in this method.
                // DO NOT do this here, but you should set it in the event
                // handler you defined...
                // Running_Worker = true;

                // invoke the event handler and rise the events
                Tick?.Invoke(this, EventArg);
                // do not set the Running_Worker to false in this method.
                // Running_Worker = false;

                //check if this trigger is once using.
                if (IsOnceUsing)
                {
                    // it means this trigger is once using, so you should
                    // stop ticking and dispose this trigger.
                    Stop();
                    Dispose();
                }
            }

        }
        public override string ToString()
        {
            return ToStringValue;
        }
        #endregion
        //-------------------------------------------------
    }
}
