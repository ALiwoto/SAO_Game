// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAO.Controls.Music
{
    partial class SoundPlayer
    {
        //---------------------------------------------
        #region Initialize Region
        private void InitializeComponent(bool notTheFirstTime = false)
        {
            //-------------------------------------
            this._player.PlayDone -= SoundPlayerLoopMode_PlayDone;
            this._player.PlayStopped -= SoundPlayer_PlayStopped;
            this._player.PlayPaused -= SoundPlayer_PlayPaused;


            this._player.PlayDone += SoundPlayerLoopMode_PlayDone;
            this._player.PlayStopped += SoundPlayer_PlayStopped;
            this._player.PlayPaused += SoundPlayer_PlayPaused;
            if (!notTheFirstTime)
            {
                this.Father.FormClosing -= Father_Closing;
                this.Father.FormClosing += Father_Closing;
            }
            //-------------------------------------
            //-------------------------------------
        }

        private void ReverseInitializeComponent()
        {
            //-------------------------------------
            this._player.PlayDone -= SoundPlayerLoopMode_PlayDone;
            this._player.PlayStopped -= SoundPlayer_PlayStopped;
            this._player.PlayPaused -= SoundPlayer_PlayPaused;
            //-------------------------------------
            //-------------------------------------
        }
        #endregion
        //---------------------------------------------
        #region Events Region
        private void Father_Closing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this._player.Stop(true);
            }
            catch
            {
                return;
            }
        }

        private void SoundPlayer_PlayPaused(object sender, EventArgs e)
        {
            this.StopInner();
            this.IsPaused = true;
        }

        private void SoundPlayer_PlayStopped(object sender, EventArgs e)
        {
            try
            {
                this.StopInner();
                this.IsStopped = true;
                this.Dispose();
            }
            catch
            {
                return;
            }
        }

        private async void SoundPlayerLoopMode_PlayDone(object sender, EventArgs e)
        {
            try
            {
                this.IsPlaying = false;

                if (!Father.IsDisposed)
                {
                    switch (TheMode)
                    {
                        case LoopMode.TrackNoLoop:
                            if (IsPlaying)
                            {
                                //this.StopInner();
                                this.IsStopped = true;
                            }
                            break;
                        case LoopMode.SingleTrackLoop:
                            ReverseInitializeComponent();
                            await Task.Delay(1500);
                            this.StopInner();
                            this.Play();
                            InitializeComponent(true);
                            break;
                        case LoopMode.AlbumNoLoop:
                        case LoopMode.AlbumLoop:
                            this.Next();
                            InitializeComponent(true);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    if (IsPlaying)
                    {
                        IsPlaying = false;
                    }
                    this.Dispose();
                }
            }
            catch
            {
                ; // do nothing here
            }
        }
        #endregion
        //---------------------------------------------
        #region Set Method's Region
        public void ChangeVolume(float value)
        {
            this.Volume = value;
            this._player.ChangeVolume(Volume);
            this.VolumeChanged?.Invoke(this, null);
        }
        public void ChangePosition(TimeSpan _span)
        {
            this._player.ChangePosition(_span);
            this.SoundLocationChanged?.Invoke(this, null);
        }
        #endregion
        //---------------------------------------------
        #region Get Method's Region

        #endregion
        //---------------------------------------------
        #region Ordinary Methods Region
        /// <summary>
        /// Plays and loops the file using a new thread, and loads the file first
        /// if it has not been loaded.
        /// </summary>
        public void PlayLooping(bool noCheck = false)
        {
            if (TheAlbum is null)
            {
                TheMode = LoopMode.SingleTrackLoop;
            }
            else
            {
                if (!noCheck)
                {
                    TheMode = LoopMode.AlbumLoop;
                }
            }
            if (this.IsPlaying)
            {
                if (!this._player.IsRepeating)
                {
                    if (TheMode != LoopMode.AlbumLoop)
                    {
                        this._player.MakeMeRepeat();
                    }
                }
            }
            else
            {
                if (!this._player.IsRepeating)
                {
                    if (TheMode != LoopMode.AlbumLoop)
                    {
                        this._player.MakeMeRepeat();
                    }
                }
                this.IsPlaying = true;
                this._player.ChangeStream(this.SoundLocation);
                this._player.Play();
            }
        }
        public void Next()
        {
            if (TheAlbum is null)
            {
                return;
            }
            switch (TheMode)
            {
                case LoopMode.AlbumNoLoop:
                    if (IsEndOfAlbum())
                    {
                        Stop();
                    }
                    else
                    {
                        this.NextAlbumIndex();
                        this.Play();
                    }
                    break;
                case LoopMode.AlbumLoop:
                    this.NextAlbumIndex();
                    this.Play();
                    break;
                default:
                    break;
            }
        }
        public async void Next(Album myAlbum, bool loop = false)
        {
            this.StopInner();
            await Task.Delay(300); // waiting for workers...
            TheAlbum = myAlbum;
            if (IsLoopMode != loop)
            {
                LoopModeChanged?.Invoke(this, null);
            }
            IsLoopMode = loop;
            this.ResetAlbumIndex();
            this.Relive();
            SoundLocation = TheAlbum[IndexOfAlbum].Path;
            if (IsLoopMode)
            {
                TheMode = LoopMode.AlbumLoop;
                this.PlayLooping(true);
            }
            else
            {
                TheMode = LoopMode.AlbumNoLoop;
                this.Play();
            }
        }
        /// <summary>
        /// Play Next Music (I mean index) in the current Album.
        /// </summary>
        /// <param name="index"></param>
        public void Next(uint index)
        {
            IndexOfAlbum = index;
            Next();
        }
        //---------------------------------------------
        /// <summary>
        /// Dispose the Player and release all resources used by this player.
        /// </summary>
        public void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }
            ReverseInitializeComponent();
            this.IsDisposed = true;
            if (IsPlaying)
            {
                this.Stop();
            }
        }
        //---------------------------------------------
        /// <summary>
        /// Play the music,
        /// the <see cref="SoundLocation"/> and
        /// <seealso cref="FileName"/> should be setted
        /// before you using this method.
        /// </summary>
        public void Play()
        {
            if (IsPlaying)
            {
                return;
            }
            switch (TheMode)
            {
                case LoopMode.TrackNoLoop:
                case LoopMode.SingleTrackLoop:
                    if (SoundLocation is null)
                    {
                        return;
                    }
                    break;
                case LoopMode.AlbumNoLoop:
                case LoopMode.AlbumLoop:
                    SoundLocation = TheAlbum[IndexOfAlbum].Path;
                    break;
                default:
                    break;
            }
            this.StopInner();
            this.IsPlaying = true;
            this._player.ChangeStream(SoundLocation);
            this._player.Play();
        }
        public void Play(uint index)
        {
            switch (TheMode)
            {
                case LoopMode.TrackNoLoop:
                case LoopMode.SingleTrackLoop:
                    return;
                case LoopMode.AlbumNoLoop:
                case LoopMode.AlbumLoop:
                    this.SetAlbumIndex(index);
                    this.Play();
                    return;
                default:
                    break;
            }
        }
        public void Play(Album myAlbum, uint index = 0, bool loop = false)
        {
            TheAlbum = myAlbum;
            IndexOfAlbum = index;
            IsLoopMode = loop;
            if (TheAlbum is null)
            {
                return;
            }
            if (IsLoopMode)
            {
                TheMode = LoopMode.AlbumLoop;
            }
            else
            {
                TheMode = LoopMode.AlbumNoLoop;
            }
            this.Relive();
            this.Play();
        }
        /// <summary>
        /// Stop the Player and
        /// Dispose it.
        /// </summary>
        public void Stop()
        {
            if (this.IsStopped)
            {
                return;
            }
            this.IsPlaying = false;
            this.IsPaused = false;
            this.IsStopped = true;
            if (!this.IsDisposed)
            {
                this.Dispose();
            }
            this._player.Stop();
        }
        public void StopInner()
        {
            this.IsPlaying = false;
            this.IsPaused = false;
            this.IsStopped = false;
            this.IsDisposed = false;
        }
        
        /// <summary>
        /// Resume the player, please notice that you can't use 
        /// this method after using neither <see cref="Stop()"/> nor
        /// <see cref="Dispose()"/>; thus you can't resume the music.
        /// --> You can only use it after using <see cref="Pause()"/>.
        /// </summary>
        public void Resume()
        {
            if (this.IsPlaying || this.IsStopped)
            {
                return;
            }
            this.StopInner();
            this.IsPlaying = true;
            this._player.Play();
        }
        /// <summary>
        /// Pause this music, also you can use <see cref="Resume()"/>
        /// after this method to resume the music;
        /// Please notice that this method won't dispose the 
        /// resources using by this player.
        /// </summary>
        public void Pause()
        {
            try
            {
                if (!this.IsPlaying || this.IsStopped)
                {
                    return;
                }
                this.IsPlaying = false;
                this.IsStopped = false;
                this.IsPaused = true;
                this._player.Pause();
            }
            catch
            {
                ; // nothing
            }
            
        }

        private bool IsEndOfAlbum()
        {
            if (TheAlbum is null)
            {
                return true;
            }
            else
            {
                return IndexOfAlbum == TheAlbum.Musics.Length - 1;
            }
        }

        private void ResetAlbumIndex()
        {
            if (TheAlbum is null)
            {
                return;
            }
            else
            {
                IndexOfAlbum = 0;
            }
        }

        private void NextAlbumIndex()
        {
            if (IsEndOfAlbum())
            {
                ResetAlbumIndex();
            }
            else
            {
                IndexOfAlbum++;
            }
        }

        private void SetAlbumIndex(uint index)
        {
            if (index > TheAlbum.Musics.Length - 1)
            {
                IndexOfAlbum = 0;
            }
            else
            {
                IndexOfAlbum = index;
            }
        }

        private void Relive()
        {
            if (this._player != null)
            {
                this._player.Stop();
            }
            this._player = null;
            this._player = WotoAudioPlayer.GeneratePlayer();
            this.InitializeComponent(true);
        }
        #endregion
        //---------------------------------------------
    }
}
