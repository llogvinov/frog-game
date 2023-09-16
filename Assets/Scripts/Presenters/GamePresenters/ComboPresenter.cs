using System.Collections;
using TMPro;
using Tongue;
using UnityEngine;

namespace Presenters.GamePresenters
{
    public class ComboPresenter : BasePresenter
    {
        [SerializeField] private TMP_Text _comboText;

        private void Start()
        {
            Switch(false);
            HitTargetHandler.ComboDone += ShowComboUI;
        }

        private void OnDestroy()
        {
            HitTargetHandler.ComboDone -= ShowComboUI;
        }

        private void ShowComboUI(int comboValue)
        {
            _comboText.text = $"X{comboValue.ToString()} COMBO";
            StartCoroutine(ShowComboUICoroutine());
        }

        private IEnumerator ShowComboUICoroutine()
        {
            Switch(true);
            yield return new WaitForSeconds(1f);
            Switch(false);
        }
    }
}