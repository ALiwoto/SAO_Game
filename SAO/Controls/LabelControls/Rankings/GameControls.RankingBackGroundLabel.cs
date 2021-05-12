using SAO.SandBox;
using SAO.GameObjects.Kingdoms;

namespace SAO.Controls
{
    partial class GameControls
    {
        public sealed partial class RankingBackGroundLabel : LabelControl
        {
            //---------------------------------------------------------
            /// <summary>
            /// Use for Kind
            /// </summary>
            public RankingKindLabel ActiveKindRankingLabel { get; private set; }
            /// <summary>
            /// Use for clickedLabel.
            /// </summary>
            public RankingPlayerLabel ActivePlayerRankingLabel { get; private set; }
            public RankingPlayerLabel TitleRanking { get; private set; }
            public RankingPlayerLabel[] PlayersInRanking { get; private set; }
            //---------------------------------------------------------
            public LabelControl MessageLabel2 { get; set; }
            public LabelControl MessageLabel3 { get; set; }
            public LabelControl MessageLabel4 { get; set; }
            //---------------------------------------------------------
            public KingdomInfo KingdomInfo { get; set; }
            //---------------------------------------------------------
            //---------------------------------------------------------
            public bool IsWorking { get; private set; }
            //---------------------------------------------------------

            /// <summary>
            /// this is for: <see cref="LabelControlSpecies.RankingBackGroundLabel"/>
            /// </summary>
            /// <param name="myRes"></param>
            /// <param name="father"></param>
            /// <param name="activeRankingLabel"></param>
            /// <param name="kingdomInfo"></param>
            public RankingBackGroundLabel(IRes myRes, SandBoxBase father,
                RankingKindLabel activeRankingLabel, KingdomInfo kingdomInfo) :
                base(myRes, LabelControlSpecies.RankingBackGroundLabel, father)
            {
                ActiveKindRankingLabel = activeRankingLabel;
                KingdomInfo = kingdomInfo;
                Initialize_ForRankingBackGround_Component();
            }
        }
    }
    
}
