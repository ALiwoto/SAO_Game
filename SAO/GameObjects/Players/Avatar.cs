// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Drawing;
using System.ComponentModel;
using SAO.Controls;
using SAO.Security;
using SAO.Constants;
using SAO.GameObjects.Resources;
using SAO.Controls.Elements.ChatElements;

namespace SAO.GameObjects.Players
{
    /// <summary>
    /// The Avatar of the player.
    /// </summary>
    public sealed partial class Avatar : IRes
    {
        //-------------------------------------------------
        #region Constants Region
        public const string CharSeparater       = "_";
        public const char OrdinaryFirst         = 'A';
        public const char SpecialFirst          = 'S';
        public const int ORDINARY_AVATAR_COUNT  = 11;
        public const int SPECIAL_AVATAR_COUNT   = 1;
        public const int INDEX_COMPARER         = 1;
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public string AvatarFullName { get; }
        public WotoRes MyRes { get; set; }
        public Avatars AvatarType { get; } = Avatars.A_0; // default avatar.
        public Avatars_S AvatarType_S { get; }
        public bool IsSpecial { get; }
        #endregion
        //-------------------------------------------------
        #region Constructors Region
        [Browsable(false)]
        private Avatar(Avatars avatarType)
        {
            AvatarFullName  = avatarType.ToString();
            AvatarType      = avatarType;
            InitializeComponent();
        }
        private Avatar(Avatars_S avatarType)
        {
            AvatarFullName  = avatarType.ToString();
            AvatarType_S    = avatarType;
            IsSpecial       = true;
            InitializeComponent();
        }
        #endregion
        //-------------------------------------------------
        #region Ordinary Methods Region
        public StrongString GetForServer()
        {
            if (!IsSpecial)
            {
                return AvatarType.ToString();
            }
            else
            {
                return AvatarType_S.ToString();
            }
        }
        /// <summary>
        /// return the avatar Image of the player
        /// by the format.
        /// if the format was not described, this 
        /// method will return null,
        /// so be carefull.
        /// </summary>
        /// <param name="format">
        /// The format of the image of this avatar.
        /// <code>---------------------</code>
        /// NOTICE: by Avatar format, I don't mean
        /// Image format(Like png or jpg or ...),
        /// I mean the format of the avatar itself that you want to 
        /// get the image of it,
        /// for example <see cref="AvatarFormat.Format01"/>
        /// should be used in <see cref="GameControls.ThroneLabel"/>
        /// for getting the Avatar of the royal memebers.
        /// </param>
        /// <returns></returns>
        public Image GetImage(AvatarFormat format, AvatarFrame frame = null)
        {
            Image myImage = null;
            switch (format)
            {
                case AvatarFormat.Format01:
                case AvatarFormat.Format02:
                case AvatarFormat.Format03:
                    myImage = Image.FromFile(ThereIsConstants.Path.Datas_Path +
                        ThereIsConstants.Path.DoubleSlash +
                        MyRes.GetString(AvatarFullName));
                    break;
                default:
                    // ?:|
                    break;
            }
            return myImage;
        }
        #endregion
        //-------------------------------------------------
        #region overrided Methods Region
        public override string ToString()
        {
            return GetForServer().GetValue();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
        //-------------------------------------------------
        #region static Methods Region
        public static Avatar ConvertToAvatar(Avatars theAvatar)
        {
            return new Avatar(theAvatar);
        }
        public static Avatar ConvertToAvatar(Avatars_S theAvatar)
        {
            return new Avatar(theAvatar);
        }
        public static Avatar ConvertToAvatar(StrongString theString)
        {
            try
            {
                switch (theString[true].ToUpper()[0])
                {
                    case OrdinaryFirst:
                        return ConvertToAvatar(ConvertToAvatars(theString));
                    case SpecialFirst:
                        return ConvertToAvatar(ConvertToAvatars_S(theString));
                    default:
                        return GetDefaultAvatar();
                }
            }
            catch
            {
                return GetDefaultAvatar();
            }
            
        }
        public static Avatars ConvertToAvatars(StrongString theString)
        {
            try
            {
                StrongString[] myStrings = theString.Split(CharSeparater);
                var myInt = myStrings[myStrings.Length - INDEX_COMPARER].ToInt32();
                if (myInt > ORDINARY_AVATAR_COUNT)
                {
                    return Avatars.A_0;
                }
                return (Avatars)myInt;
            }
            catch
            {
                return Avatars.A_0;
            }
            
        }
        public static Avatars_S ConvertToAvatars_S(StrongString theString)
        {
            try
            {
                StrongString[] myStrings = theString.Split(CharSeparater);
                var myInt = myStrings[myStrings.Length - INDEX_COMPARER].ToInt32();
                if (myInt > SPECIAL_AVATAR_COUNT)
                {
                    return Avatars_S.S_0;
                }
                return (Avatars_S)myInt;
            }
            catch
            {
                return Avatars_S.S_0;
            }
            
        }
        public static Avatar GetDefaultAvatar()
        {
            return new Avatar(Avatars.A_0);
        }
        #endregion
        //-------------------------------------------------
        #region operators Region
        /// <summary>
        /// check if these two values are the same or not.
        /// </summary>
        /// <param name="left">
        /// left avatar value
        /// </param>
        /// <param name="right">
        /// right avatar value
        /// </param>
        /// <returns></returns>
        public static bool operator ==(in Avatar left, in Avatar right)
        {
            if (left is null)
            {
                if (right is null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (right is null)
                {
                    return false;
                }
            }
            if (left.IsSpecial != right.IsSpecial)
            {
                return false;
            }
            if (left.IsSpecial)
            {
                return left.AvatarType_S == right.AvatarType_S;
            }
            return left.AvatarType == right.AvatarType;
        }
        /// <summary>
        /// check if these two values are the same or not.
        /// </summary>
        /// <param name="avatar">
        /// avatar value
        /// </param>
        /// <param name="type">
        /// type value
        /// </param>
        /// <returns></returns>
        public static bool operator ==(in Avatar avatar, in Avatars type)
        {
            if (avatar is null || avatar.IsSpecial)
            {
                return false;
            }
            return avatar.AvatarType == type;
        }
        /// <summary>
        /// check if these two values are the same or not.
        /// </summary>
        /// <param name="type">
        /// type value
        /// </param>
        /// <param name="avatar">
        /// avatar value
        /// </param>
        /// <returns></returns>
        public static bool operator ==(in Avatars type, in Avatar avatar)
        {
            return avatar == type;
        }
        /// <summary>
        /// check if these two values are the same or not.
        /// </summary>
        /// <param name="type">
        /// type value
        /// </param>
        /// <param name="avatar">
        /// avatar value
        /// </param>
        /// <returns></returns>
        public static bool operator ==(in Avatars_S type, in Avatar avatar)
        {
            return avatar == type;
        }
        /// <summary>
        /// check if these two values are the same or not.
        /// </summary>
        /// <param name="avatar">
        /// avatar value
        /// </param>
        /// <param name="type">
        /// type value
        /// </param>
        /// <returns></returns>
        public static bool operator ==(in Avatar avatar, in Avatars_S type)
        {
            if (avatar is null || !avatar.IsSpecial)
            {
                return false;
            }
            return avatar.AvatarType_S == type;
        }
        /// <summary>
        /// check if these two values are the same or not.
        /// </summary>
        /// <param name="left">
        /// left avatar value
        /// </param>
        /// <param name="right">
        /// right avatar value
        /// </param>
        /// <returns></returns>
        public static bool operator !=(in Avatar left, in Avatar right)
        {
            if (left is null)
            {
                if (right is null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (right is null)
                {
                    return true;
                }
            }
            if (left.IsSpecial != right.IsSpecial)
            {
                return true;
            }
            if (left.IsSpecial)
            {
                return left.AvatarType_S != right.AvatarType_S;
            }
            return left.AvatarType != right.AvatarType;
        }
        /// <summary>
        /// check if these two values are the same or not.
        /// </summary>
        /// <param name="avatar">
        /// avatar value
        /// </param>
        /// <param name="type">
        /// type value
        /// </param>
        /// <returns></returns>
        public static bool operator !=(in Avatar avatar, in Avatars type)
        {
            if (avatar is null || avatar.IsSpecial)
            {
                return true;
            }
            return avatar.AvatarType != type;
        }
        /// <summary>
        /// check if these two values are the same or not.
        /// </summary>
        /// <param name="type">
        /// type value
        /// </param>
        /// <param name="avatar">
        /// avatar value
        /// </param>
        /// <returns></returns>
        public static bool operator !=(in Avatars type, in Avatar avatar)
        {
            return avatar != type;
        }
        /// <summary>
        /// check if these two values are the same or not.
        /// </summary>
        /// <param name="avatar">
        /// avatar value
        /// </param>
        /// <param name="type">
        /// type value
        /// </param>
        /// <returns></returns>
        public static bool operator !=(in Avatar avatar, in Avatars_S type)
        {
            if (avatar is null || !avatar.IsSpecial)
            {
                return true;
            }
            return avatar.AvatarType_S != type;
        }
        /// <summary>
        /// check if these two values are the same or not.
        /// </summary>
        /// <param name="type">
        /// type value
        /// </param>
        /// <param name="avatar">
        /// avatar value
        /// </param>
        /// <returns></returns>
        public static bool operator !=(in Avatars_S type, in Avatar avatar)
        {
            return avatar != type;
        }
        #endregion
        //-------------------------------------------------
    }
}
