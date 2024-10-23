using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class ScoreTypeView : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Sprite[] spriteList;
        [SerializeField] private UnityEvent scoreTypeUpdateAction;

        public void UpdateScoreType(ScoreType scoreType)
        {
            image.sprite = spriteList[(int)scoreType];
            scoreTypeUpdateAction?.Invoke();
        }
    }
}