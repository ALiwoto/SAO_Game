// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.


namespace SAO.Controls
{
    partial class GameControls
    {
        public interface IParamControls
        {
            uint CurrentStatus { get; set; }

            /// <summary>
            /// Setting the this.BackColor Parameter to Color.Transparent.
            /// </summary>
            void SetColorTransparent();

            //void InitializeComponent();

        }
    }
}
