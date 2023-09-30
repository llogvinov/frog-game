using System.Collections;
using Core;
using UnityEngine;
using UnityEngine.UI;

namespace Presenters.GamePresenters
{
    public class Timer : PooledObject
    {
        [SerializeField] private Text _remainingTime;

        private Coroutine _countdownCoroutine;

        private void Start()
        {
            Game.GameOver += StopCountdown;
        }

        private void OnDestroy()
        {
            Game.GameOver -= StopCountdown;
        }
        
        public void StartCountdown(float seconds) =>
            _countdownCoroutine = StartCoroutine(Countdown(seconds));

        private IEnumerator Countdown(float seconds)
        {
            var counter = seconds;
            while (counter > 0)
            {
                yield return null;
                counter -= Time.deltaTime;
                UpdateRemainingTime(counter);
            }
            
            gameObject.SetActive(false);
        }

        private void UpdateRemainingTime(float remainingTime)
        { 
            float minutes = Mathf.FloorToInt(remainingTime / 60);  
            float seconds = Mathf.FloorToInt(remainingTime % 60);
            _remainingTime.text = $"{minutes:0}:{seconds:00}";
        }

        public void StopCountdown()
        {
            if (_countdownCoroutine != null) 
                StopCoroutine(_countdownCoroutine);
            
            gameObject.SetActive(false);
        }
    }
}
