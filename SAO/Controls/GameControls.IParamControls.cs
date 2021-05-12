
namespace SAO.Controls
{
    partial class GameControls
    {
        public interface IParamControls
        {
            uint CurrentStatus { get; set; }

            /// <summary>
            /// Setting the this.BackColor Parameter to Color.Transparent.
            /// </summary>
            void SetColorTransparent();

            //void InitializeComponent();

        }
    }
}
