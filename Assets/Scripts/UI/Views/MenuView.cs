using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class MenuView : BaseView
    {
        [SerializeField] private Button _playButton;

        public Button PlayButton => _playButton;
    }
}