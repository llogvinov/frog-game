using System;
using Bonus;
using Core;
using UnityEngine;
using UnityEngine.UI;

namespace Presenters
{
    public class TestPresenter : BasePresenter
    {
        [SerializeField] private Button _addHealthButton;
        [SerializeField] private Button _releaseEnemiesButton;

        private void Start()
        {
            _addHealthButton.onClick.AddListener(AddHealth);
            _releaseEnemiesButton.onClick.AddListener(ReleaseEnemies);
        }

        private void OnDestroy()
        {
            _addHealthButton.onClick.RemoveListener(AddHealth);
            _releaseEnemiesButton.onClick.RemoveListener(ReleaseEnemies);
        }

        private void AddHealth()
        {
            HealthPowerUp healthPowerUp = new HealthPowerUp(Game.Player.Health, 1);
            healthPowerUp.Apply();
        }

        private void ReleaseEnemies()
        {
            ReleaseEnemiesPowerUp releaseEnemiesPowerUp = new ReleaseEnemiesPowerUp(Game.FrogGirl.Targets);
            releaseEnemiesPowerUp.Apply();
        }
    }
}