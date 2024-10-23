using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreTMProText;
        [SerializeField] private ScaleAnim scaleAnim;
         
        public void UpdateText(int score)
        {
            scoreTMProText.text = score.ToString();
            scaleAnim.StartAnimation();
        }
    }
}
