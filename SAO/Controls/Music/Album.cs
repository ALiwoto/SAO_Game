// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Linq;

namespace SAO.Controls.Music
{
    public sealed class Album : IDisposable
    {
        //-------------------------------------------------
        #region Constants Region
        public const string AlbumToStringString =
            "Woto Album - Music Count: ";
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public wotoMusic[] Musics { get; private set; }
        #endregion
        //-------------------------------------------------
        #region Constructors Region
        private Album(wotoMusic[] theMusics)
        {
            Musics = theMusics;
        }
        #endregion
        //-------------------------------------------------
        #region this[] Region
        public wotoMusic this[uint index]
        {
            get
            {
                return Musics[index];
            }
        }
        #endregion
        //-------------------------------------------------
        #region Ordinary Offline Methods
        public void ReplaceMusic(uint index, wotoMusic theNewPath)
        {
            Musics[index] = theNewPath;
        }
        /// <summary>
        /// Adding a new music to the end of 
        /// the music list of this Album.
        /// </summary>
        /// <param name="theNewPath">
        /// the new path of the specified music.
        /// NOTICE: if the music already exists in the
        /// music list, the music won't be added unles you set the
        /// second param to true.
        /// </param>
        /// <param name="addAnyway">
        /// use this to specialize to whether add the music
        /// to the music list of this album even if it already exists
        /// in the music list.
        /// the default value of this parameter is false.
        /// </param>
        public void AddMusic(wotoMusic theNewPath, bool addAnyway = false)
        {
            if (addAnyway || !Exists(theNewPath))
            {
                wotoMusic[] myStrings = new wotoMusic[Musics.Length + 1];
                for(int i = 0; i < Musics.Length; i++)
                {
                    myStrings[i] = Musics[i];
                }
                myStrings[myStrings.Length - 1] = theNewPath;
                Musics = myStrings;
            }
        }
        /// <summary>
        /// Add a music to the specified index 
        /// in the music list of this Album.
        /// </summary>
        /// <param name="index">
        /// the index of the new music.
        /// please calculate the index of the musics from zero,
        /// which means if you enter the 0 for this parameter,
        /// the music will be added to the first of the music list
        /// of this Album.
        /// </param>
        /// <param name="theNewPath">
        /// the new path of the specified music.
        /// NOTICE: if the music already exists in the
        /// music list, the music won't be added unles you set the
        /// second param to true.
        /// </param>
        /// <param name="addAnyway">
        /// use this to specialize to whether add the music
        /// to the music list of this album even if it already exists
        /// in the music list.
        /// the default value of this parameter is false.
        /// </param>
        public void AddMusic(uint index, wotoMusic theNewPath, bool addAnyway = false)
        {
            if (addAnyway || !Exists(theNewPath))
            {
                wotoMusic[] myStrings = new wotoMusic[Musics.Length + 1];
                for (int i = 0; i < index; i++)
                {
                    myStrings[i] = Musics[i];
                }
                myStrings[index] = theNewPath;
                for(uint i = index + 1, j = index; i < myStrings.Length; i++, j++)
                {
                    myStrings[i] = Musics[j];
                }
                Musics = myStrings;
            }
        }
        /// <summary>
        /// Determine whether a specified music path exists in the
        /// list of this Album or not.
        /// </summary>
        /// <param name="musicPath">
        /// the specified music path.
        /// </param>
        /// <returns></returns>
        public bool Exists(wotoMusic musicPath)
        {
            for(int i = 0; i < Musics.Length; i++)
            {
                if(Musics[i] == musicPath)
                {
                    return true;
                }
            }
            return false;
        }
        public void Dispose()
        {
            for(int i = 0; i < Musics.Length; i++)
            {
                Musics[i].Dispose();
            }
            Musics = null;

        }
        #endregion
        //-------------------------------------------------
        #region Overrided Methods Region
        public override string ToString()
        {
            return AlbumToStringString + Musics.Length;
        }
        #endregion
        //-------------------------------------------------
        #region static Methods Region
        public static Album GenerateAlbum(params wotoMusic[] theMusics)
        {
            return new Album(theMusics);
        }
        #endregion
        //-------------------------------------------------
    }
}
