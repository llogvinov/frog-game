using System.Collections;
using Core;
using TMPro;
using Tongue;
using UnityEngine;

namespace Presenters
{
    public class ComboPresenter : MonoBehaviour
    {
        [SerializeField] private Canvas _comboCanvas;
        [SerializeField] private TMP_Text _comboText;

        private void Start()
        {
            GameManager.Instance.GameOver += OnGameOver;
            HitTargetHandler.ComboDone += ShowComboUI;
            _comboCanvas.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            GameManager.Instance.GameOver -= OnGameOver;
            HitTargetHandler.ComboDone -= ShowComboUI;
        }

        private void OnGameOver()
        {
            _comboCanvas.gameObject.SetActive(false);
        }

        private void ShowComboUI(int comboValue)
        {
            _comboText.text = $"X{comboValue.ToString()} COMBO";
            StartCoroutine(ShowUI());
        }

        private IEnumerator ShowUI()
        {
            _comboCanvas.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
            _comboCanvas.gameObject.SetActive(false);
        }
    }
}