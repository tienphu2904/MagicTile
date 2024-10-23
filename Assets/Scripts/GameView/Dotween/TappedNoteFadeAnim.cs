using DG.Tweening;
using UnityEngine;

namespace GameView.Dotween
{
    public class TappedNoteFadeAnim : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private float timeFade = .5f;
        [SerializeField] private float fadeStrength = .1f;
        
        private Sequence _fadeSequence;
        public void StartAnimation()
        {
            ClearAnim();
            _fadeSequence = DOTween.Sequence();
            _fadeSequence.Append(sprite.DOFade(fadeStrength, timeFade)
                .From(1f)
                .SetEase(Ease.InOutSine));
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
