using DG.Tweening;
using UnityEngine;

namespace GameView.Dotween
{
    public class TappedNoteScaleAnim : MonoBehaviour
    {
        [SerializeField] private float timeScale = .5f;
        [SerializeField] private float scaleStrength = .1f;
        
        private Sequence _fadeSequence;
        public void StartAnimation()
        {
            ClearAnim();
            _fadeSequence = DOTween.Sequence();
            _fadeSequence.Append(transform.DOScale(scaleStrength, timeScale)
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
