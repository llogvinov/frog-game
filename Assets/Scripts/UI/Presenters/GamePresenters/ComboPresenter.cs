using System.Collections;
using Tongue;
using UI.Views;
using UnityEngine;

namespace UI.Presenters.GamePresenters
{
    [RequireComponent(typeof(ComboView))]
    public class ComboPresenter : BasePresenter
    {
        private ComboView _comboView;

        public ComboView View => _comboView;

        protected override void Awake()
        {
            base.Awake();
            _comboView = GetComponent<ComboView>();
        }

        private void Start() => 
            HitTargetHandler.ComboDone += ShowComboUI;

        private void OnDestroy() => 
            HitTargetHandler.ComboDone -= ShowComboUI;
        
        public void Init()
        {
            _comboView.UICanvas.worldCamera = Camera.main;
            Switch(false);
        }

        private void ShowComboUI(int comboValue)
        {
            _comboView.ComboText.text = $"X{comboValue.ToString()} COMBO";
            Switch(true);
            StartCoroutine(ShowComboUICoroutine());
        }

        private IEnumerator ShowComboUICoroutine()
        {
            yield return new WaitForSeconds(1f);
            Switch(false);
        }
    }
}