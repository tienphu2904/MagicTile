using UnityEngine;
using UnityEngine.Events;

namespace GameView
{
    public class TappedNoteSkin : MonoBehaviour
    {
        [SerializeField] private UnityEvent playAnimAction;
        [SerializeField] private UnityEvent despawnNoteAction;

        public void Show()
        {
            transform.gameObject.SetActive(true);
            playAnimAction?.Invoke();
            Invoke(nameof(Hide), .5f);
        }

        public void Hide()
        {
            transform.gameObject.SetActive(false);
        }

        public void OnDespawnNote()
        {
            despawnNoteAction?.Invoke();
        }
    }
}
