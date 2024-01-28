using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIMenu : UIBase
    {
        [SerializeField] private Button _playButton;

        public Button PlayButton => _playButton;
    }
}