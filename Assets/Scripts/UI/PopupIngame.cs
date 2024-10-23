using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class PopupIngame : MonoBehaviour
    {
        [SerializeField] private ScoreText scoreText;
        [SerializeField] private ScoreTypeView scoreTypeView;
        [SerializeField] private UnityEvent startGameAction;
        [SerializeField] private UnityEvent endGameAction;
        
        public void StartGame()
        {
            startGameAction?.Invoke();
        }

        public void EndGame()
        {
            endGameAction?.Invoke();
        }

        public void UpdateScore(int score, ScoreType scoreType)
        {
            scoreText.UpdateText(score);
            if (score > 0)
            {
                scoreTypeView.UpdateScoreType(scoreType);
            }
        }
    }
}
