// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Drawing;
using SAO.SandBox;
using SAO.GameObjects.Chatting;
using SAO.GameObjects.ServerObjects;

namespace SAO.Controls.Elements.ChatElements
{
    /// <summary>
    /// this Element does not support <see cref="GraphicElements.SurfaceControl"/>.
    /// </summary>
    public sealed partial class ChatElement : GraphicElements
    {
        //-------------------------------------------------
        #region Constants Region
        public const float AVATAR_SIZE = 72.0f;
        public const float SrcstartPoint = 0.0f;
        /// <summary>
        /// distance between avatar and element, when 
        /// this element is not this player's chat.
        /// </summary>
        public const float AVATAR_ELEMENT = 3 * (SandBoxBase.from_the_edge / 2);
        /// <summary>
        /// distance between avatar and element, when 
        /// this element is this player's chat.
        /// </summary>
        public const float ELEMENT_AVATAR = SandBoxBase.from_the_edge / 2;
        public const float ELEMENT_AVATAR_VERTICAL = 2 * SandBoxBase.from_the_edge;
        public const string YOU_STRING_NAME = "The_You";
        public const string DEFAULT_FONT = "Segoe UI";
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public GameControls.ChatBackgroundLabel ChatBackgroundLabel { get; }
        public ChatMessage Message { get; }
        public SizeF ElementSizeF { get; private set; }
        public SizeF AvatarSizeF { get; private set; }
        public SizeF AvatarFrameSizeF { get; private set; }
        public SizeF NameSizeF { get; private set; }
        public SizeF PositionSizeF { get; private set; }
        public PointF ElementLocationF { get; private set; }
        public PointF AvatarLocationF { get; private set; }
        public PointF AvatarFrameLocationF { get; private set; }
        public PointF NameLocationF { get; private set; }
        public PointF PosiotionLocationF { get; private set; }
        public PointF StartPointF { get; private set; }
        /// <summary>
        /// Unlimited Element PointF Works.
        /// <!--
        /// By ALi.w 
        /// Date: 2021 / 01 / 17
        /// Time: 19:24.
        /// -->
        /// </summary>
        public PointF[] UnlimitedEPointFWorks { get; private set; }
        public RectangleF ElementRectangleF { get; private set; }
        public RectangleF AvatarRectangleF { get; private set; }
        public RectangleF AvatarFrameRectangleF { get; private set; }
        public RectangleF NameRectangleF { get; private set; }
        public RectangleF PositionRectangleF { get; private set; }
        public RectangleF SrcAvatarRectangleF { get; private set; }
        public RectangleF SrcAvatarFrameRectangleF { get; private set; }
        public Color[] PaintColors { get; private set; }
        public Brush[] PaintBrushes { get; private set; }
        public Pen[] PaintPens { get; private set; }
        public float MaxWidth { get; private set; }
        public float MinWidth { get; private set; }
        public int Lines { get; private set; }
        public Image AvatarImage { get; private set; }
        public Image AvatarFrameImage { get; private set; }
        public StringFormat StringFormat { get; private set; }
        public Font MessageFont { get; private set; }
        public Font NameFont { get; private set; }
        public Font PositionFont { get; private set; }
        public bool IsMe { get; }
        #endregion
        //-------------------------------------------------
        #region overrided Properties Region
        /// <summary>
        /// This Element doesn't support SurfaceControl.
        /// please do NOT use it.
        /// if you use it, it will return you null.
        /// </summary>
        /// <value>null</value>
        public override GameControls.LabelControl SurfaceControl { get => null; }
        #endregion
        //-------------------------------------------------
        #region Constructors Region
        /// <summary>
        /// Create a new instance of <see cref="ChatElement"/>.
        /// </summary>
        /// <param name="myRes">
        /// the woto resources component manager object.
        /// it will be from game client of the game.
        /// </param>
        private ChatElement(IRes myRes, 
            GameControls.ChatBackgroundLabel chatBackgroundLabel, 
            ChatMessage message) :
            base(myRes)
        {
            ChatBackgroundLabel = chatBackgroundLabel;
            Message             = message;
            IsMe = Message.SenderName == ThereIsServer.GameObjects.MyProfile.PlayerName;
            /* WARNING:
             * about StartPoint of the element:
             * the start point should be default, then you should set it 
             * in the background label, considering other elements'
             * start point.
            */
            StartPointF = default;
            InitializeComponent();
        }
        #endregion
        //-------------------------------------------------
        #region static methods Region
        public static ChatElement GenerateChatElement(IRes myRes,
            GameControls.ChatBackgroundLabel chatBackgroundLabel,
            ChatMessage message)
        {
            return new ChatElement(myRes, chatBackgroundLabel, message);
        }
        #endregion
        //-------------------------------------------------
    }
}
