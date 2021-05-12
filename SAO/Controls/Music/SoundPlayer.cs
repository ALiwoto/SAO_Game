#define SAO_SOUND_PLAYER

using System;
using System.ComponentModel;
using System.Threading.Tasks;
using WotoProvider.EventHandlers;
using SAO.Constants;
using SAO.GameObjects.Resources;

namespace SAO.Controls.Music
{
#pragma warning disable IDE0044
    /// <summary>
    ///  Controls playback of a sound from a file.
    /// </summary>
    [ToolboxItem(false)]
    public sealed partial class SoundPlayer : IDisposable, IRes
    {
        //-------------------------------------------------
        #region Constant's Region
        public const string FaultString = "SharpDX.MediaFoundation";
        #endregion
        //-------------------------------------------------
        #region Properties Region
        /// <summary>
        /// Father of this <see cref="SoundPlayer"/>
        /// </summary>
        public GameControls.PageControl Father { get; set; }
        public WotoRes MyRes { get; set; }
        public Album TheAlbum { get; private set; }
        public uint IndexOfAlbum { get; private set; }
        #endregion
        //-------------------------------------------------
        #region field's Region
        private WotoAudioPlayer _player;
        #endregion
        //-------------------------------------------------
        #region Event Handler's Region
        //public event SoundPlayerDisposedEventHandler SoundPlayerDisposed;
        public event LoopModeChangedEventHandler LoopModeChanged;
        public event VolumeChangedEventHandler VolumeChanged;
        /// <summary>
        /// Occurs when a new audio source path for this 
        /// <see cref="SoundPlayer"/> has been set.
        /// </summary>
        public event SoundLocationChangedEventHandler SoundLocationChanged;
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public EventArgs SoundPlayerEventArgs { get; }
        public TimeSpan Position { get => _player.Position; }
        public string SoundLocation { get => FileName; private set => FileName = value; }
        public string FileName { get; private set; }
        public float Volume { get; private set; }
        /// <summary>
        /// Gets a value indicating whether the control has been disposed of.
        /// </summary>
        /// <value>true if the control has been disposed of; otherwise, false.</value>
        /// [Browsable(false)]
        public bool IsDisposed { get; private set; }
        public bool IsLoopMode { get; private set; }
        public bool IsPlaying { get; private set; }
        public bool IsPaused { get; private set; }
        public bool IsStopped { get; private set; }
        public LoopMode TheMode { get; private set; }
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="SoundPlayer"/> class.
        /// Use <seealso cref="Play"/> method for playing,
        /// or <seealso cref="PlayLooping"/> for PlayLoop.
        /// But Before that, you should set <see cref="SoundLocation"/>
        /// or <see cref="AudioPlayer.FileName"/>.
        /// </summary>
        public SoundPlayer(IRes myRes, GameControls.PageControl father)
        {
            MyRes = myRes.MyRes;
            Father = father;
            _player = WotoAudioPlayer.GeneratePlayer();
            InitializeComponent();
        }
        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="SoundPlayer"/> class, and attaches
        /// the specified file.
        /// </summary>
        /// <param name="soundLocation">
        /// The location of a file to load.
        /// </param>
        public SoundPlayer(string soundLocation, IRes myRes, GameControls.PageControl father)
        {
            SoundLocation = soundLocation;
            MyRes = myRes.MyRes;
            Father = father;
            _player = WotoAudioPlayer.GeneratePlayer();
            InitializeComponent();
        }
        public SoundPlayer(Album myAlbum, IRes myRes, GameControls.PageControl father)
        {
            TheAlbum = myAlbum;
            MyRes = myRes.MyRes;
            Father = father;
            _player = WotoAudioPlayer.GeneratePlayer();
            InitializeComponent();
        }
        private SoundPlayer(string location)
        {
            SoundLocation = location;
            _player = WotoAudioPlayer.GeneratePlayer();
        }
        #endregion
        //-------------------------------------------------
        #region static Method's Region
        public static async void MakeNoise(Noises noise)
        {
            SoundPlayer myPlayer;
            switch (noise)
            {
                case Noises.ClickNoise:
                    myPlayer = new SoundPlayer(ThereIsConstants.Path.Datas_Path +
                        ThereIsConstants.Path.DoubleSlash +
                        Properties.Resources.ClickNoiseFileName);
                    myPlayer.Play();
                    await Task.Delay(6000);
                    myPlayer.Dispose();
                    GC.Collect();
                    break;
                default:
                    break;
            }
        }
        public static bool IsOurFault(Exception ex)
        {
            switch (ex)
            {
                case NullReferenceException exception:
                    if (exception.Source == FaultString)
                    {
                        return true;
                    }
                    break;
                default:
                    break;
            }
            return false;
        }
        #endregion
        //-------------------------------------------------
    }
#pragma warning restore IDE0044
}
