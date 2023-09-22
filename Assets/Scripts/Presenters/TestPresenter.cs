﻿using PowerUps;
using Core;
using PowerUps.ActivatedPowerUps;
using PowerUps.TimePowerUps;
using UnityEngine;
using UnityEngine.UI;

namespace Presenters
{
    public class TestPresenter : BasePresenter
    {
        [SerializeField] private Button _addHealthButton;
        [SerializeField] private Button _releaseEnemiesButton;
        [SerializeField] private Button _scoreMultiplierButton;
        [SerializeField] private Button _tongueScalerButton;

        private void Start()
        {
            _addHealthButton.onClick.AddListener(AddHealth);
            _releaseEnemiesButton.onClick.AddListener(ReleaseEnemies);
            _scoreMultiplierButton.onClick.AddListener(MultiplyScore);
            _tongueScalerButton.onClick.AddListener(ScaleTongue);
        }

        private void OnDestroy()
        {
            _addHealthButton.onClick.RemoveListener(AddHealth);
            _releaseEnemiesButton.onClick.RemoveListener(ReleaseEnemies);
            _scoreMultiplierButton.onClick.RemoveListener(MultiplyScore);
            _tongueScalerButton.onClick.RemoveListener(ScaleTongue);
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

        private async void MultiplyScore()
        {
            ScoreMultiplierPowerUp scoreMultiplierPowerUp = 
                new ScoreMultiplierPowerUp(Game.Player.Score, 2f, 5f);
            await scoreMultiplierPowerUp.Activate();
        }

        private async void ScaleTongue()
        {
            TongueHeadScalerPowerUp tongueHeadScalerPowerUp =
                new TongueHeadScalerPowerUp(Game.Player.TongueHead, 0.4f, 5f);
            await tongueHeadScalerPowerUp.Activate();
        }
    }
}