using System.Collections;
using Player;
using TMPro;
using UnityEngine;

namespace Presenters.GamePresenters
{
    public class ScorePresenter : BasePresenter
    {
        [SerializeField] private TMP_Text _scoreText;

        private void Start()
        {
            Score.OnScoreChanged += UpdateScoreText;
        }

        private void OnDestroy()
        {
            Score.OnScoreChanged -= UpdateScoreText;
        }

        private void UpdateScoreText(Score score)
        {
            _scoreText.text = score.CurrentScore.ToString();
        }
    }
}