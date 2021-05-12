using System.Drawing;
using SAO.GameObjects.Kingdoms;

namespace SAO.Controls
{
    partial class GameControls
    {
        public partial class RankingPlayerLabel : LabelControl, IMoveable
        {
            //---------------------------------------------------------
            #region Properties Region
            public RankingBackGroundLabel BackgroundLabel { get; }
            //---------------------------------------------------------
            public LabelControl MessageLabel2 { get; set; }
            public LabelControl MessageLabel3 { get; set; }
            public LabelControl MessageLabel4 { get; set; }
            //---------------------------------------------------------
            public KingdomInfo KingdomInfo { get; set; }
            public Point LastPoint { get; set; }
            //---------------------------------------------------------
            /// <summary>
            /// Index in the BackgroundLabel.UnlimitedPointWorks;
            /// </summary>
            public uint Index { get; set; }
            //---------------------------------------------------------
            public ElementMovements Movements { get; }

            /// <summary>
            /// Determine whether this ranking label has selected 
            /// by player or not.
            /// </summary>
            public bool IsSelected { get; set; }
            /// <summary>
            /// Just for <see cref="LabelControlSpecies.RankingPlayerLabel"/>,
            /// when it is Title, set this value to true.
            /// </summary>
            public bool IsTitleRanking { get; set; }
            public bool IsWorking { get; private set; }
            public bool IsMoving { get; private set; }
            #endregion
            //---------------------------------------------------------
            #region Constructor Region
            /// <summary>
            /// this is for: <see cref="LabelControlSpecies.RankingPlayerLabel"/>
            /// </summary>
            /// <param name="myRes"></param>
            /// <param name="backLabel"></param>
            /// <param name="isTitle"></param>
            public RankingPlayerLabel(IRes myRes, RankingBackGroundLabel backLabel,
                bool isTitle = false) :
                base(myRes, LabelControlSpecies.RankingPlayerLabel)
            {
                IsTitleRanking = isTitle;
                BackgroundLabel = backLabel;
                if (!isTitle)
                {
                    Movements = ElementMovements.VerticalMovements;
                }
                else
                {
                    Movements = ElementMovements.NoMovements;
                }
                Initialize_ForRankingPlayer_Component();
            }
            #endregion
        }
    }
}
