// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using SAO.Controls;
using SAO.Client;
using SAO.SandBox;
using SAO.Controls.Elements.MapElements;
using SAO.GameObjects.Resources;

namespace SAO.GameObjects.MapObjects
{
    public partial class Map : IRes
    {
        //-------------------------------------------------
        #region Properties Region
        public WotoRes MyRes { get; set; }
        //-----------------------------
        /// <summary>
        /// Father may be the <see cref="GameClient"/>,
        /// or another <see cref="SandBoxBase"/> ...
        /// </summary>
        public GameControls.PageControl Father { get; set; }
        /// <summary>
        /// Map Singers can be more than one,
        /// but Map displayer should be one,
        /// please remove the last one from father, then add a new MapDisplayer.
        /// </summary>
        public GameControls.MapSigner[] MapSigners { get; set; }
        /// <summary>
        /// Map displayer should be one,
        /// please remove the last one from father, then add a new MapDisplayer.
        /// </summary>
        public GameControls.MapSigner MapDisplayer { get; set; }
        /// <summary>
        /// Map Elements, for example a character or a exanimate element,
        /// such as Fire, se your data files.
        /// </summary>
        public MapElement[] MapElements { get; set; }
        public MapElement ActiveMapElement { get; private set; }
        public GameControls.MapElement[] AdvancedMapElements { get; set; }
        public Trigger MoveManager { get; private set; }
        
        //-----------------------------
        public MapMode Mode { get; }
        public uint MaxI { get; set; }
        public float AllowManNum { get; set; }
        public uint MaxJ { get; set; }
        public bool ElementsMoveAllowed { get; private set; } = false;
        public bool HasMoveableElement { get; }
        
        #endregion
        //-------------------------------------------------
        #region Constructors and this[] Region
        private Map(GameControls.PageControl father, MapMode myMode, 
            bool hasMoveableElement)
        {
            HasMoveableElement  = hasMoveableElement;
            Mode                = myMode;
            Father              = father;
            if (HasMoveableElement)
            {
                AllowManNum     = 10;
            }
            InitializeComponent();
        }
        //-----------------------------
        public MapElement this[uint i, uint j]
        {
            get
            {
                for(int m = 0; m < MapElements.Length; m++)
                {
                    if(MapElements[m].MyI == i && MapElements[m].MyJ == j)
                    {
                        return MapElements[m];
                    }
                    else
                    {
                        continue;
                    }
                }
                return null;
            }
            
        }
        #endregion
        //-------------------------------------------------
        #region static Methods Region
        public static Map GenerateMap(GameControls.PageControl father, MapMode myMode,
            bool hasMoveableElement)
        {
            return new Map(father, myMode, hasMoveableElement);
        }
        #endregion
        //-------------------------------------------------
    }
}
