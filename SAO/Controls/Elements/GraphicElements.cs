// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Drawing;
using SAO.GameObjects.Resources;

namespace SAO.Controls.Elements
{
    /// <summary>
    /// Graphics Element.
    /// this class is abstract.
    /// just inherit your element from this class.
    /// such as <see cref="MapElements.MapElement"/>.
    /// </summary>
    public abstract partial class GraphicElements : IRes, IDisposable, IMoveable
    {
        //-------------------------------------------------
        #region Properties Region
        public WotoRes MyRes { get; set; }
        public virtual GameControls.LabelControl SurfaceControl { get; protected set; }
        //-------------------------------------------------
        public Point LastPoint { get; set; }
        //-------------------------------------------------
        public virtual ElementMovements Movements { get; }
        //-------------------------------------------------
        public virtual uint CurrentStatus { get; protected set; }
        public virtual bool IsApplied { get; protected set; }
        public virtual bool IsDisposed { get; protected set; }
        #endregion
        //-------------------------------------------------
        #region Constructor Region
        protected GraphicElements(IRes myRes)
        {
            MyRes = myRes.MyRes;
            CurrentStatus = 1;
            InitializeComponent();
        }
        #endregion
        //-------------------------------------------------
    }
}
