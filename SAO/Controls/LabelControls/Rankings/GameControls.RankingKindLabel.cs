// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using SAO.SandBox;
using SAO.GameObjects.Kingdoms;

namespace SAO.Controls
{
    partial class GameControls
    {
        public partial class RankingKindLabel : LabelControl
        {
            //---------------------------------------------------------
            //---------------------------------------------------------
            //---------------------------------------------------------
            //---------------------------------------------------------
            //---------------------------------------------------------
            /// <summary>
            /// Use for RankingKind only.
            /// </summary>
            public RankingsMode RankingsMode { get; }
            /// <summary>
            /// Determine whether this ranking label has selected 
            /// by player or not.
            /// </summary>
            public bool IsSelected { get; set; }
            //---------------------------------------------------------

            /// <summary>
            /// this is for: <see cref="LabelControlSpecies.RankingKindLabel"/>
            /// </summary>
            /// <param name="myRes"></param>
            /// <param name="father"></param>
            public RankingKindLabel(IRes myRes, SandBoxBase father, RankingsMode rankingsMode) :
                base(myRes, LabelControlSpecies.RankingKindLabel, father)
            {
                RankingsMode = rankingsMode;
                Initialize_ForRankingKind_Component();
            }
        }
    }
    
}
