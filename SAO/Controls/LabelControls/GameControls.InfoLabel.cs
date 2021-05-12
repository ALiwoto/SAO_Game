// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using WotoProvider.Enums;
using SAO.SandBox;

namespace SAO.Controls
{
    partial class GameControls
    {
        public partial class InfoLabel : LabelControl
        {
            //---------------------------------------------
            #region Properties Region
            public InfoLabels InfoLabelMode { get; protected set; }
            #endregion
            //---------------------------------------------
            #region Constructor Region
            public InfoLabel(IRes myRes,
                SandBoxBase father, InfoLabels iLMode) :
                base(myRes, LabelControlSpecies.InfoLabel, father, true)
            {
                InfoLabelMode = iLMode;
                switch (InfoLabelMode)
                {
                    case InfoLabels.MDKSIL:
                        DesigningForInfoLabelMDKSIL();
                        break;
                    case InfoLabels.KSKISBIL:
                        DesigningForInfoLabelKSKISBIL();
                        break;
                    default:
                        // None :||
                        break;
                }
                
            }
            #endregion
            //---------------------------------------------
        }
    }
}
