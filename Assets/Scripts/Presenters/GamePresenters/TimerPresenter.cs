using System;
using System.Collections.Generic;
using Core;
using PowerUps.TimePowerUps;
using UnityEngine;

namespace Presenters.GamePresenters
{
    public class TimerPresenter : BasePresenter
    {
        [SerializeField] private ObjectPool _pool;

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
            var timer = (Timer) _pool.GetPooledObject();
            _activeTimers.Add(powerUp, timer);
            timer.StartCountdown(seconds);
            powerUp.Finished += OnTimerFinished;
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