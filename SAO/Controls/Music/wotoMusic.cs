// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.IO;
using SAO.Constants;
using SAO.GameObjects.Resources;

namespace SAO.Controls.Music
{
#pragma warning disable IDE1006
    public sealed partial class wotoMusic : IRes, IDisposable
    {
        //-------------------------------------------------
        #region Constants Region
        public const string MusicToStringString =
            "Woto Music - Music Name: ";
        #endregion
        //-------------------------------------------------
        //-------------------------------------------------
        #region Properties Region
        public WotoRes MyRes { get; set; }
        public string Path { get; private set; }
        public bool IsDisposed { get; private set; }
        public Musics Music { get; }
        #endregion
        //-------------------------------------------------
        #region Constructors Region
        private wotoMusic(Musics music)
        {
            InitializeComponent();
            Music = music;
            Path = 
                ThereIsConstants.Path.Datas_Path + 
                ThereIsConstants.Path.DoubleSlash +
                MyRes.GetString(Music.ToString());
        }
        #endregion
        //-------------------------------------------------
        #region Ordinary Methods Region
        public void Dispose()
        {
            IsDisposed = true;
            Path = null;
        }
        public FileStream GetStream()
        {
            return File.OpenRead(Path);
        }
        #endregion
        //-------------------------------------------------
        #region static Methods Region
        public static wotoMusic GenerateWotoMusic(Musics music)
        {
            return new wotoMusic(music);
        }
        #endregion
        //-------------------------------------------------
        #region Overrided Methods Region
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return MusicToStringString + Music.ToString();
        }
        #endregion
        //-------------------------------------------------
        #region Operators Region
        public static bool operator ==(wotoMusic left, wotoMusic right)
        {
            if(left is null)
            {
                return right is null;
            }
            else if(right is null)
            {
                return false;
            }
            return left.Path == right.Path;
        }

        public static bool operator !=(wotoMusic left, wotoMusic right)
        {
            if (left is null)
            {
                return !(right is null);
            }
            else if (right is null)
            {
                return true;
            }
            return left.Path != right.Path;
        }
        #endregion
        //-------------------------------------------------
    }
#pragma warning restore IDE1006
}
