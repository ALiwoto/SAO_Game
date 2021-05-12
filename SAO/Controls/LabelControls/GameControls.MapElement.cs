// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Windows.Forms;
using SAO.GameObjects.Characters;
using SAO.GameObjects.MapObjects;

namespace SAO.Controls
{
    partial class GameControls
    {
        /// <summary>
        /// Create new instance of this Element.
        /// </summary>
        public partial class MapElement : PictureBoxControl
        {
            //----------------------------------------------------
            //----------------------------------------------------
            public ElementMovements ElementMovements { get; set; }
            public ElementsInMap ElementInMapType { get; set; }
            //----------------------------------------------------
            //----------------------------------------------------
            private MapElement(IRes myRes) : base(myRes, false)
            {
                InitializeComponent();
            }


            //----------------------------------------------------
            //----------------------------------------------------
            //----------------------------------------------------

            /// <summary>
            /// Get (Generate) the a new Map Elemenet
            /// which is a character.
            /// </summary>
            /// <param name="res">
            /// this res should be <see cref="Map.MyRes"/>.
            /// </param>
            /// <param name="character"></param>
            /// <returns></returns>
            public static MapElement GetMapElement(IRes res, Character character)
            {
                MapElement element = new MapElement(res)
                {
                    ElementMovements = ElementMovements.NoMovements,
                    ElementInMapType = ElementsInMap.Character,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                };
                element.SetPicture(character.GetCharacterImage());
                return element;
            }
            /// <summary>
            /// Get the MapElement by setting the element type,
            /// this type should not be <see cref="ElementsInMap.Character"/>
            /// </summary>
            /// <param name="res"></param>
            /// <param name="element"></param>
            /// <returns></returns>
            public static MapElement GetMapElement(IRes res, ElementsInMap elementT)
            {
                MapElement element = new MapElement(res)
                {
                    ElementMovements = ElementMovements.NoMovements,
                    ElementInMapType = elementT,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                };
                element.SetPictureName(element.ElementInMapType.ToString());
                element.SetPicture();
                return element;
            }
            //----------------------------------------------------

        }
    }
}
