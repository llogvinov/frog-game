using Core;
using Core.Factory;
using PowerUps.ActivatedPowerUps;
using PowerUps.TimePowerUps;
using UI.Presenters;
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

        private Player.Player _player;
        private FrogGirl.FrogGirl _frogGirl;

        private void Start()
        {
            _addHealthButton.onClick.AddListener(AddHealth);
            _releaseEnemiesButton.onClick.AddListener(ReleaseEnemies);
            _scoreMultiplierButton.onClick.AddListener(MultiplyScore);
            _tongueScalerButton.onClick.AddListener(ScaleTongue);

            _player = AllServices.Container.Single<IGameFactory>().Player;
            _frogGirl = AllServices.Container.Single<IGameFactory>().FrogGirl;
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
            var healthPowerUp = new HealthPowerUp(_player.Health, 1);
            healthPowerUp.Apply();
        }

        private void ReleaseEnemies()
        {
            var releaseEnemiesPowerUp = new ReleaseEnemiesPowerUp(_frogGirl.Targets);
            releaseEnemiesPowerUp.Apply();
        }

        private async void MultiplyScore()
        {
            var scoreMultiplierPowerUp = new ScoreMultiplierPowerUp(_player.Score, 2f, 10f);
            await scoreMultiplierPowerUp.Activate();
        }

        private async void ScaleTongue()
        {
            var tongueHeadScalerPowerUp = new TongueHeadScalerPowerUp(_player.TongueHead, 0.4f, 7f);
            await tongueHeadScalerPowerUp.Activate();
        }
    }
}