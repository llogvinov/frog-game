using System.Collections.Generic;
using Core;
using PowerUps.TimePowerUps;
using Presenters.GamePresenters;
using UnityEngine;

namespace UI.Presenters.GamePresenters
{
    public class TimerPresenter : BasePresenter
    {
        [SerializeField] private ObjectPool _timerPool;

        private Dictionary<TimePowerUp, Timer> _activeTimers;

        private void Start()
        {
            _activeTimers = new Dictionary<TimePowerUp, Timer>();
            TimePowerUp.AnyTimePowerUpStarted += StartNewTimer;
        }

        private void OnDestroy()
        {
            TimePowerUp.AnyTimePowerUpStarted -= StartNewTimer;
        }

        private void StartNewTimer(TimePowerUp powerUp, float seconds)
        {
            var pooledObject = _timerPool.TryGetPooledObject();
            if (pooledObject != null)
            {
                var timer = (Timer) pooledObject;
                _activeTimers.Add(powerUp, timer);
                timer.StartCountdown(seconds);
                powerUp.Finished += OnTimerFinished;
            }
        }

        private void OnTimerFinished(TimePowerUp timePowerUp)
        {
            _activeTimers.TryGetValue(timePowerUp, out var timer);
            if (timer != null)
            {
                timer.StopCountdown();
                timer.Release();
            }
        }
    }
}