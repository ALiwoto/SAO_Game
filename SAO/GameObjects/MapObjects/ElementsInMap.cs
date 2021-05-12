using SAO.GameObjects.Characters;

namespace SAO.GameObjects.MapObjects
{
    public enum ElementsInMap
    {
        //-------------------------------------------------
        #region Ordinary Map Elements
        /// <summary>
        /// That means this is not an Element, but
        /// a character which is in the map,
        /// so you should load it with <see cref="CharacterInfo"/>
        /// and <seealso cref="Character.GetCharacterImage()"/>.
        /// </summary>
        Character = 0,
        /// <summary>
        /// Fire.
        /// </summary>
        Fire1                   = 1,
        /// <summary>
        /// Village House 1.
        /// </summary>
        Village_House1          = 2,
        CastleInKojiEmpire1     = 3,
        CastleInKojiEmpire2     = 4,
        CastleInKojiEmpire3     = 5,
        CastleInKojiEmpire4     = 6,
        Ruined_House1           = 7,
        #endregion
        //-------------------------------------------------
        #region TheJungleHome Map ELements Region
        HomeJungleBack          = 8,
        MineInHomeJungle        = 9,
        FarmInHomeJungle        = 10,
        HouseInHomeJungle       = 11,
        GardenInHomeJungle      = 12,
        BoatInHomeJungle        = 13,
        #endregion
        //-------------------------------------------------
        #region Custom MapElements
        Cloud1                  = 14,
        Cloud2                  = 15,
        #endregion
        //-------------------------------------------------





    }
}
