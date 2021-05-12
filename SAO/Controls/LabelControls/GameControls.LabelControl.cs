// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Drawing;
using SAO.SandBox;
using SAO.GameObjects.Resources;
namespace SAO.Controls
{
    partial class GameControls
    {
        public partial class LabelControl : LabelBase, IParamControls, IRes, IAnimationFactory
        {
            //------------------------------------------------
            /// <summary>
            /// Some of Labels, has different Status,
            /// for example FirstLabel in the MainForm, in the Status = 1,
            /// has the text = "Connecting" **it is in the Resources,
            /// but in the Status = 2, it will change to : Checking Updates.
            /// This Status number, will appear in the end of name of Labels for
            /// obtaining the string from Resources Manager.
            /// </summary>
            public WotoRes MyRes { get; set; }
            public LabelControlSpecies DesigningMode { get; }
            public Point[] UnlimitedPointWorks { get; set; }
            public virtual SandBoxBase Father { get; set; }
            public Trigger AnimationFactory { get; set; }
            /// <summary>
            /// This is my First Child, use it in these methods:
            /// <see cref="DesigningForDialogBoxBackGround()"/> for: 
            /// <see cref="LabelControlSpecies.DialogLabelBackGround"/>,
            /// <see cref="DesigningForCharacterNameInDialog()"/> for:
            /// <see cref="LabelControlSpecies.CharacterNameInDialog"/>,
            /// <see cref="DesigningForLinkStart()"/> for:
            /// <see cref="LabelControlSpecies.LinkStart"/>,
            /// <see cref="DesigningForInfoLabel()"/> for:
            /// <see cref="LabelControlSpecies.InfoLabel"/>
            /// </summary>
            public LabelControl MessageLabel1 { get; set; }
            public virtual LabelControl[] SurfaceLabels { get; protected set; }
            public PictureBoxControl PictureBoxControl1 { get; set; }
            //------------------------------------------------
            /// <summary>
            /// Get the real name of this LabelControl.
            /// </summary>
            public string RealName { get; protected set; }
            /// <summary>
            /// Mouse Entering SoundEffects.
            /// </summary>
            public Noises MESoundEffects { get; set; }
            public bool HasMouseDowned { get; set; }
            /// <summary>
            /// Use Animation after the MouseEnter event.
            /// </summary>
            public bool UseAnimation { get; set; }
            /// <summary>
            /// in the <see cref="LabelControlSpecies.LinkStart"/>,
            /// set this true if the animationFactory effect should go up
            /// or down.
            /// </summary>
            public bool From_The_Edge_Of_Darkness { get; set; }
            /// <summary>
            /// if this is true, that means we are going to the right,
            /// so the +x shoud be (+), otherwise, it should be (-).
            /// </summary>
            public bool Going_Sunny { get; set; }
            public bool SingleClick { get; set; } = false;
            public bool HasMouseClickedOnce { get; set; }
            //------------------------------------------------
            public const string labelForTextName = "labelForText";
            //------------------------------------------------
            public float Rate_of_incline { get; set; }
            public uint CurrentStatus { get; set; }
            public uint CurrentAnimationStatus { get; set; }
            /// <summary>
            /// Going Sunny for Link Start Mode.
            /// </summary>
            //------------------------------------------------
            public LabelControl(IRes myRes)
            {
                MyRes = myRes.MyRes;
                CurrentStatus = 1;
            }
            public LabelControl(IRes myRes, LabelControlSpecies myDesignMode,
                SandBoxBase myFather = null, bool useAnimation = true)
            {
                MyRes = myRes.MyRes;
                CurrentStatus = 1;
                DesigningMode = myDesignMode;
                UseAnimation = useAnimation;
                if(myFather!= null)
                {
                    Father = myFather;
                }
                switch (DesigningMode)
                {
                    case LabelControlSpecies.CharacterNameInDialog:
                        DesigningForCharacterNameInDialog();
                        break;
                    case LabelControlSpecies.LinkStart:
                        DesigningForLinkStart();
                        break;
                    case LabelControlSpecies.ElementBackGround:
                        DesigningForElementBackGround();
                        break;
                    default: //None

                        break;
                }
            }
        }
    }
}
