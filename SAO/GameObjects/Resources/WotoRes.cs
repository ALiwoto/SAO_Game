// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.ComponentModel;

namespace SAO.GameObjects.Resources
{
    public sealed class WotoRes : ComponentResourceManager
    {
        //-------------------------------------------------
        #region Constants Region
        public const string WotoResStringName = "WotoRes from :";
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public string Name { get; private set; }
        #endregion
        //-------------------------------------------------
        #region Costructor Region
        public WotoRes(Type t) : base(t)
        {
            ;
        }
        #endregion
        //-------------------------------------------------
        #region Ordinary Methods Region
        public bool StringExists(string name)
        {
            return !(GetString(name) is null);
        }
        public bool ObjectExists(string name)
        {
            return !(GetObject(name) is null);
        }
        #endregion
        //-------------------------------------------------
        #region Overrided Methods Region
        public override string ToString()
        {
            return WotoResStringName + BaseName;
        }
        #endregion
    }
}
