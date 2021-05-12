// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using SAO.GameObjects.Resources;
using SAO.Controls;
using SAO.Controls.Elements.MapElements;

namespace SAO.GameObjects.MapObjects
{
    partial class Map
    {
        //-------------------------------------------------
        #region Ordinary Designing Region
        private void InitializeComponent()
        {
            //----------------------------------
            //News:
            this.MyRes = new WotoRes(typeof(Map));
            if (HasMoveableElement)
            {
                this.MoveManager = new Trigger()
                {
                    Interval = 125,
                    Running_Worker = false,
                    Enabled = false,
                    SingleLineWorker = false,
                };
            }
            //----------------------------------
            //Names:
            //TabIndexes
            //FontAndTextAligns:

            //Sizes:
            //Locations:
            //Colors:

            //ComboBoxes:
            //Enableds:
            //Texts:
            //AddRanges:
            //ToolTipSettings:
            //----------------------------------
            //Events:
            if (HasMoveableElement)
            {
                this.MoveManager.Tick += MoveManager_Tick;
            }
            //----------------------------------

        }


        private void MoveManager_Tick(object sender, System.EventArgs e)
        {
            if (!ElementsMoveAllowed)
            {
                this.ElementsMoveAllowed = true;
            }
            //this.Father.Refresh();
        }
        #endregion
        //-------------------------------------------------
        #region Ordinary Designing Methods Region
        public void ApplyAllElements()
        {
            for(int i = 0; i < MapElements.Length; i++)
            {
                MapElements[i].Apply();
            }
            if (HasMoveableElement && this.MoveManager != null)
            {
                this.MoveManager.Enabled = true;
            }
        }
        public void ApplyAllElements(bool applySurfaces)
        {
            for (int i = 0; i < MapElements.Length; i++)
            {
                MapElements[i].Apply(applySurfaces);
            }
            if (HasMoveableElement && this.MoveManager != null)
            {
                this.MoveManager.Enabled = true;
            }
        }
        public void DisposeAllElements()
        {
            for (int i = 0; i < MapElements.Length; i++)
            {
                MapElements[i].Dispose();
            }
            if (HasMoveableElement && this.MoveManager != null)
            {
                this.MoveManager.Enabled = false;
                this.MoveManager.Dispose();
            }
        }
        public void AddSurfaces()
        {
            foreach (var currentElement in MapElements)
            {
                if (currentElement.SurfaceControl != null)
                {
                    this.Father.Controls.Add(currentElement.SurfaceControl);
                }
            }
        }
        public void RemoveSurfaces()
        {
            foreach (var currentElement in MapElements)
            {
                if (currentElement.SurfaceControl != null)
                {
                    this.Father.Controls.Remove(currentElement.SurfaceControl);
                }
            }
        }
        #endregion
        //-------------------------------------------------
        #region Settings Methods Region
        public void SetActiveMapElement(MapElement mapElement, bool setAnyway = false)
        {
            if(this.ActiveMapElement == mapElement && !setAnyway)
            {
                return;
            }
            this.ActiveMapElement = mapElement;
        }
        public void DisableMoving()
        {
            this.ElementsMoveAllowed = false;
            if (HasMoveableElement && MoveManager != null)
            {
                MoveManager.Enabled = false;
            }
        }
        #endregion
        //-------------------------------------------------
        //-------------------------------------------------
    }
}
