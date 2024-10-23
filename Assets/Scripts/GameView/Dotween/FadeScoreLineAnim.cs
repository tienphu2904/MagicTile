using DG.Tweening;
using UnityEngine;

namespace GameView.Dotween
{
    public class FadeScoreLineAnim : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private float timeFade = .5f;
        [SerializeField] [Range(0, 1f)] private float fadeStength = .6f;
        
        private Sequence _fadeSequence;
        private void Start()
        {
            StartAnimation();
        }

        private void StartAnimation()
        {
            ClearAnim();
            _fadeSequence = DOTween.Sequence();
            _fadeSequence.Append(sprite.DOFade(fadeStength, timeFade)
                .From(1f)
                .SetEase(Ease.InOutSine));
            _fadeSequence.SetLoops(-1, LoopType.Yoyo);
            _fadeSequence.Play();
        }

        private void OnEnable()
        {
            if (_fadeSequence != null)
            {
                _fadeSequence.PlayForward();
            }
        }

        private void OnDisable()
        {
            if (_fadeSequence != null)
            {
                _fadeSequence.Pause();
            }
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
