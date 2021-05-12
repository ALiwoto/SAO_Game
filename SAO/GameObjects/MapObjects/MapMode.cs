// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.


namespace SAO.GameObjects.MapObjects
{
    /// <summary>
    /// Map Mode.
    /// use it to generate a new map.
    /// </summary>
    public enum MapMode
    {
        /// <summary>
        /// you can use this map mode for creating Animation Company.
        /// these map are NOT REAL map.
        /// yes, that's right, these are the fake maps.
        /// Some Custom map.
        /// <!--NisemonoMap-->
        /// </summary>
        CustomMap       = 0,
        /// <summary>
        /// The Koji Kingdoms map.
        /// </summary>
        KojiKingdoms    = 1,
        /// <summary>
        /// The Player's Home, jungle Map.
        /// </summary>
        HomejunglenMap  = 2,
    }
}
