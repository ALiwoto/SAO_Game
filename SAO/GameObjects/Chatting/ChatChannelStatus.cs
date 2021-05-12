
namespace SAO.GameObjects.Chatting
{
    /// <summary>
    /// the channel status.
    /// used in the <see cref="ChatConfiguration"/>. <code></code>
    /// --> check <seealso cref="ChatConfiguration.Status"/>
    /// </summary>
    public enum ChatChannelStatus
    {
        FreeForAll = 0,
        HasItemPrice = 1,
        HasItemPricaAndLvl = 2,
        HasLevelLimit = 3,
        MuteAllUtilTime = 4,
        MuteAll = 5,
    }
}
