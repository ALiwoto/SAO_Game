using SAO.GameObjects.Kingdoms;

namespace SAO.Controls
{
    partial class GameControls
    {
#pragma warning disable IDE0055
        public enum LabelControlSpecies
        {
            /// <summary>
            /// None :|
            /// </summary>
            None                    = 0,
            /// <summary>
            /// In: <see cref="LabelControl"/>
            /// </summary>
            DialogLabelBackGround   = 1,
            /// <summary>
            /// In: <see cref="LabelControl"/>
            /// </summary>
            CharacterNameInDialog   = 2,
            /// <summary>
            /// In: <see cref="LabelControl"/>
            /// </summary>
            LinkStart               = 3,
            /// <summary>
            /// In <see cref="LabelControl"/>
            /// </summary>
            CloseLabel              = 4,
            /// <summary>
            /// In: <see cref="LabelControl"/>
            /// </summary>
            ElementBackGround       = 5,
            /// <summary>
            /// In: <see cref="MapSigner.MapSigner(IRes, LabelControlSpecies)"/>
            /// </summary>
            MapSigner               = 6,
            /// <summary>
            /// In: <see cref="MapSigner.MapSigner(IRes, LabelControlSpecies)"/>
            /// </summary>
            MapDisplayer            = 7,
            /// <summary>
            /// In: <see cref="LabelControl"/>
            /// </summary>
            InfoLabel               = 8,
            /// <summary>
            /// ItemBarLabe, used in <see cref="ItemBarLabelControl"/>
            /// </summary>
            ItemBarLabel            = 9,
            /// <summary>
            /// Used in <see cref="GameControls.RankingKindLabel"/> only when you want
            /// to display the kind of ranking.
            /// for more information check out: <see cref="KingdomRankings.LevelRankings"/>
            /// which is <see cref="LevelRankings"/>
            /// and <see cref="KingdomRankings.PowerRankings"/> which is
            /// <see cref="PowerRankings"/>.
            /// </summary>
            RankingKindLabel        = 10,
            /// <summary>
            /// Background for showing the <see cref="GameControls.RankingPlayerLabel"/>,
            /// please watch here for more: <see cref="GameControls.RankingBackGroundLabel"/>
            /// </summary>
            RankingBackGroundLabel  = 11,
            /// <summary>
            /// A RankingLabel for showing the Details of Player,
            /// Please watch here for more details: 
            /// <see cref="GameControls.RankingPlayerLabel"/>.
            /// </summary>
            RankingPlayerLabel      = 12,
            /// <summary>
            /// Used in the <see cref="GameControls.ThroneLabel"/>.
            /// </summary>
            ThroneLabel             = 13,
            /// <summary>
            /// Used in the <see cref="GameControls.ThroneNameLabel"/>.
            /// </summary>
            ThroneNameLabel         = 14,
            /// <summary>
            /// Used in the <see cref="GameControls.ThronePositionLabel"/>.
            /// </summary>
            ThronePositionLabel     = 15,
            /// <summary>
            /// Home Bar Label, Used in 
            /// <see cref="HomeBarLabelControl"/>
            /// </summary>
            HomeBarLabel            = 16,
            /// <summary>
            /// Used in <see cref="ChatLabelControl"/>
            /// </summary>
            ChatLabel               = 17,
            /// <summary>
            /// Used in <see cref="ChatBackgroundLabel"/>
            /// </summary>
            ChatBackGroundLabel     = 18,
            /// <summary>
            /// Chat Iput Label, contains the tools
            /// which player should use to send chat messeages.
            /// Used in <see cref="ChatInputControl"/>.
            /// </summary>
            ChatInputLabel          = 19,
            /// <summary>
            /// the chat bar label, which is used in <see cref="ChatBarLabel"/>
            /// class.
            /// </summary>
            ChatBarLabelControl     = 20,
        }
#pragma warning restore IDE0055
    }
    
}
