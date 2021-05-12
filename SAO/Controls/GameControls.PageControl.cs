// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.ComponentModel;
using System.Windows.Forms;
using SAO.Controls.Animation;

namespace SAO.Controls
{
    partial class GameControls
    {
        [DefaultEvent("Load")]
        [Designer("")]
        [DesignerCategory("")]
        [DesignTimeVisible(false)]
        [InitializationEvent("")]
        [ToolboxItem(false)]
        [ToolboxItemFilter("")]
        public partial class PageControl : Form
        {
            public virtual AnimationCompany[] AnimationCompanies { get; set; }

        }
    }
}
