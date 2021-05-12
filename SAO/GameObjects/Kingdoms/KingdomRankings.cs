using System.Threading.Tasks;

namespace SAO.GameObjects.Kingdoms
{
    public class KingdomRankings
    {
        //-----------------------------------------
        public LevelRankings LevelRankings { get; set; }
        public PowerRankings PowerRankings { get; set; }
        //-------------------------
        public KingdomInfo Kingdom { get; set; }
        //-----------------------------------------
        private KingdomRankings()
        {

        }
        //-----------------------------------------
        //-----------------------------------------
        public static async Task<KingdomRankings> GetKingdomRankings(KingdomInfo kingdom)
        {
            return new KingdomRankings()
            {
                Kingdom = kingdom,
                LevelRankings = await LevelRankings.GetLevelRankings(kingdom),
                PowerRankings = await PowerRankings.GetPowerRankings(kingdom),
            };
        }
        public static async Task<bool> CreateKingdomRankings(KingdomInfo kingdom)
        {
            await PowerRankings.CreatePowerRankings(kingdom);
            await LevelRankings.CreateLevelRankings(kingdom);
            return true;
        }
        //-----------------------------------------
    }
}
