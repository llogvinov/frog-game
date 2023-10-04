using TMPro;
using UnityEngine;

namespace UI.Views
{
    public class ComboView : BaseView
    {
        [SerializeField] private TMP_Text _comboText;

        public TMP_Text ComboText => _comboText;
    }
}