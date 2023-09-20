using Core;
using UnityEngine;
using UnityEngine.UI;

namespace Presenters.MenuPresenters
{
    public class MenuPresenters : Singleton<MenuPresenters>
    {
        [SerializeField] private Button _playButton;

        public Button PlayButton => _playButton;
    }
}