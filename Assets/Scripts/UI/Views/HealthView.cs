using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class HealthView : BaseView
    {
        [SerializeField] private LayoutGroup _layoutGroup;

        public LayoutGroup Group => _layoutGroup;
    }
}