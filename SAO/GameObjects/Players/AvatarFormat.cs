// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using SAO.Controls;
using SAO.SandBox;

namespace SAO.GameObjects.Players
{
    public enum AvatarFormat
    {
        /// <summary>
        /// Used in <see cref="GameControls.ThroneLabel"/>, 
        /// for displaying the Avatar of Throne members.
        /// See: <seealso cref="KingdomInfoSandBox"/>.
        /// </summary>
        Format01 = 1,
        /// <summary>
        /// Used in the Profile Icon, which is for cutting the 
        /// image to the profile icon size
        /// </summary>
        Format02 = 2,

        Format03 = 3,
    }
}
