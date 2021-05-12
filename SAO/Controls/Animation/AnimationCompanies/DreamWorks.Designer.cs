// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Windows.Forms;
using WotoProvider.Enums;
using SAO.GameObjects.Math;
using SAO.GameObjects.MapObjects;
using SAO.Controls.Elements.MapElements;

namespace SAO.Controls.Animation.AnimationCompanies
{
    partial class DreamWorks
    {
        //-------------------------------------------------
        #region Initialize Region
        private void InitializeComponent()
        {
            UnlimitedRandomicWorks = new Randomic[2];
            if (DreamWorksInNight)
            {
                UnlimitedRandomicWorks[0] =
                    new Randomic(
                    new Range[]
                    {
                        new Range(3, 8),
                    },
                    new float[]
                    {
                        1
                    },
                    Chance_Error.One_Percent); // Day Cloud's count
            }
            else
            {
                UnlimitedRandomicWorks[0] = 
                    new Randomic(
                        new Range[]
                        {
                            new Range(2, 5)
                        },
                        new float[]
                        {
                            1
                        },
                        Chance_Error.One_Percent); // Night Cloud' count
            }
            
                
            //---------------------------------------------
            //---------------------------------------------
            // News:
            this.AnimationFactories = new Trigger[]
            {
                new Trigger()
                {
                    Index               = 0,
                    Enabled             = false,
                    SingleLineWorker    = true,
                    Interval            = 600,
                    Name                = AnimationFactoriesFirstName + 1,
                },
            };
            this.TheMap = Map.GenerateMap(Father, MapMode.CustomMap, false);
            this.TheMap.MapElements = 
                new MapElement[UnlimitedRandomicWorks[0].GetNumber()]; // Count of clouds
            for (int i = 0; i < TheMap.MapElements.Length; i++)
            {
                this.TheMap.MapElements[i] =
                    MapElement.GetMapElement(TheMap, 
                    (ElementsInMap)(14 + UnlimitedRandomicWorks[0].Next(0, 2)), TheMap);

            }
            //---------------------------------------------
            //Names:
            this.Name = DefaultDreamWorksName;
            //TabIndexes
            //FontAndTextAligns:

            //Sizes:
            for (int i = 0; i < TheMap.MapElements.Length; i++)
            {
                TheMap.MapElements[i].SetElementSize();
            }
            // UnlimitedRandomicWorks:

            UnlimitedRandomicWorks[1] =
                new Randomic(
                        new Range[]
                        {
                            new Range(0 - (TheMap.MapElements[0].Height/ 2), 
                                Father.Height / 6),
                            new Range(2 * (Father.Height / 3), 
                                Father.Height - (TheMap.MapElements[0].Height/ 2))
                        },
                        new float[]
                        {
                            0.50f,
                            0.50f,
                        },
                        Chance_Error.One_Percent);


            //Locations:
            for (int i = 0; i < TheMap.MapElements.Length; i++)
            {
                TheMap.MapElements[i].SetElementLocation(
                    (float)UnlimitedRandomicWorks[1].Next((int)-TheMap.MapElements[i].Width, 
                        (int)(Father.Width - (TheMap.MapElements[i].Width / 2))),
                    (float)UnlimitedRandomicWorks[1].GetNumber());
                /*
                TheMap.MapElements[i].SetElementLocation(random.Next(0, Father.Width),
                (float)random.Next((int)(0 - TheMap.MapElements[i].Width),
                (int)(Father.Height -
                TheMap.MapElements[i].Height + (2 * NoInternetConnectionSandBox.from_the_edge))));
                */
            }

            //Colors:

            //ComboBoxes:
            //Enableds:
            //Texts:
            //AddRanges:
            //ToolTipSettings:
            //GraphicWorks:

            //---------------------------------------------
            //Events:
            this.AnimationFactories[0].Tick -= AnimationFactoryWorker;
            this.Father.EnabledChanged      -= Father_EnabledChanged;
            this.AnimationFactories[0].Tick += AnimationFactoryWorker;
            this.Father.EnabledChanged      += Father_EnabledChanged;
            //---------------------------------------------
            //---------------------------------------------
            //Final Blows:

        }
        private void Father_EnabledChanged(object sender, EventArgs e)
        {
            this.AnimationFactories[0].Enabled = Father.Enabled;
        }
        #endregion
        //-------------------------------------------------
        #region AllGraphicalWorks Region
        protected override void GraphicDrawing(object sender, PaintEventArgs e)
        {
            // nothing is here... :|
            // come back later :/
        }
        #endregion
        //-------------------------------------------------
        #region public Overrided Methods Region
        public override void AnimationFactoryWorker(object sender, EventArgs e)
        {
            MapElement mapElement = null;
            for (int i = 0; i < TheMap.MapElements.Length; i++)
            {
                mapElement = TheMap.MapElements[i];
                if (mapElement.ElementLocationF.X >= Father.Width)
                {
                    mapElement.SetElementLocation(0 - 
                        mapElement.Width, UnlimitedRandomicWorks[1].GetNumber());
                }
                else
                {
                    mapElement.SetElementLocation(
                    mapElement.ElementLocationF.X + CloudMovesRate,
                    mapElement.ElementLocationF.Y);
                }

            }
            Father.Refresh();
        }
        public override void SetTopMostFactory(uint index)
        {
            if (index < AnimationFactories.Length)
            {
                this.topMostAnimationFactory = AnimationFactories[index];
            }
        }
        public override void Apply()
        {
            this.TheMap.ApplyAllElements();
            for (int i = 0; i < AnimationFactories.Length; i++)
            {
                AnimationFactories[i].Start();
            }
        }
        public override void Apply(bool applySurfaces)
        {
            this.TheMap.ApplyAllElements(applySurfaces);
            for (int i = 0; i < AnimationFactories.Length; i++)
            {
                AnimationFactories[i].Start();
            }
        }
        public override void Dispose()
        {
            for (int i = 0; i < AnimationFactories.Length; i++)
            {
                AnimationFactories[i].Stop();
                AnimationFactories[i].Dispose();
            }
            this.MyRes.ReleaseAllResources();
            this.TheMap.DisposeAllElements();
            this.TheMap.DisableMoving(); // just in case, you don't actually need to call it.
        }
        public override string ToString()
        {
            return Name;
        }
        #endregion
        //-------------------------------------------------
    }
}