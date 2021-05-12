
namespace WotoProvider.EventHandlers
{
    public class TickHandlerEventArgs<T> : WotoEventArgs
        where T : class
    {
        /// <summary>
        /// my Father.
        /// </summary>
        public T Father { get; }
        //-------------------------------------------------
        public TickHandlerEventArgs(WotoCreation creation, T fatherSender) :
            base(creation)
        {
            Father = fatherSender;
        }
        //-------------------------------------------------
    }
}
