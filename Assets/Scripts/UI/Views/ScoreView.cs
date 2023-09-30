using TMPro;
using UnityEngine;

namespace UI.Views
{
    public class ScoreView : BaseView
    {
        [SerializeField] private TMP_Text _scoreText;

        public TMP_Text ScoreText => _scoreText;
    }
}