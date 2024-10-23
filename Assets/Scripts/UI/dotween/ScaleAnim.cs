using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class ScaleAnim : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private float startTimeFade = .25f;
        [SerializeField] private float endTimeFade = .25f;
        [SerializeField] private float startScale = 1f;
        [SerializeField] private float scaleStrength = 1.2f;
        [SerializeField] private float endScale = 1f;
        [SerializeField] private UnityEvent animFinishAction;
        
        private Sequence _fadeSequence;
        public void StartAnimation()
        {
            ClearAnim();
            _fadeSequence = DOTween.Sequence();
            _fadeSequence.Append(rectTransform.DOScale(scaleStrength, startTimeFade)
                .From(startScale)
                .SetEase(Ease.InOutSine));
            _fadeSequence.Append(rectTransform.DOScale(endScale, endTimeFade)
                .From(scaleStrength)
                .SetEase(Ease.InOutSine));
            _fadeSequence.OnComplete(() =>
            {
                animFinishAction?.Invoke();
            });
            _fadeSequence.Play();
        }

        private void ClearAnim()
        {
            if (_fadeSequence != null)
            {
                _fadeSequence.Kill();
                _fadeSequence = null;
            }
        }
    }
}
