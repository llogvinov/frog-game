using System.Collections;
using Main.Player.Tongue;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UICombo : UIBase
    {
        [SerializeField] private TMP_Text _comboText;
        
        private void Start() => 
            HitTargetHandler.ComboDone += ShowComboUI;

        private void OnDestroy() => 
            HitTargetHandler.ComboDone -= ShowComboUI;
        
        public void Init() => 
            Hide();

        private void ShowComboUI(int comboValue)
        {
            _comboText.text = $"X{comboValue.ToString()} COMBO";
            Show();
            StartCoroutine(ShowComboUICoroutine());
        }

        private IEnumerator ShowComboUICoroutine()
        {
            yield return new WaitForSeconds(1f);
            Hide();
        }
    }
}