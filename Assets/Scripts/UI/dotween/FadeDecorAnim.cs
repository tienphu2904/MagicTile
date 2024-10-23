using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.dotween
{
    public class FadeDecorAnim : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private float timeFade = .5f;
        
        private Sequence _fadeSequence;

        public void StartAnimation()
        {
            ClearAnim();
            _fadeSequence = DOTween.Sequence();
            _fadeSequence.Append(image.DOFade(1f, timeFade)
                .From(.5f));
            _fadeSequence.Append(image.DOFade(.5f, timeFade)
                .From(1f));
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
