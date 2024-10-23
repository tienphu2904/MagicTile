using System;
using Lean.Touch;
using UnityEngine;
using UnityEngine.Events;

namespace GameView
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private NoteViews noteViews;
        [SerializeField] private LayerMask gameViewLayer;
        [SerializeField] private float noteFallSpeed = 2.5f;
        [SerializeField] private UnityEvent onLoseEvent;

        private Coroutine _spawnNotes;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                StartGame();
            }
            
            if (Input.GetKeyDown(KeyCode.S))
            {
                EndGame();
            }
        }

        public void StartGame()
        {
            CancelCoroutine();
            noteViews.OnInit();
            _spawnNotes = StartCoroutine(noteViews.SpawnNotes(noteFallSpeed));
        }

        public void EndGame()
        {
            CancelCoroutine();
        }
        
        public void OnLose()
        {
            StopCoroutine(_spawnNotes);
            noteViews.StopNote();
            onLoseEvent?.Invoke();
        }

        private void CancelCoroutine()
        {
            if (_spawnNotes != null)
            {
                StopCoroutine(_spawnNotes);
                _spawnNotes = null;
            }
        }

        public void LeanTouchOnFingerTap(LeanFinger obj)
        {
            var origin = Camera.main.ScreenToWorldPoint(obj.ScreenPosition);
            var hit = Physics2D.Raycast(origin, Vector2.zero, gameViewLayer);
            if (hit.collider != null)
            {
                var noteObj = hit.collider.GetComponent<Note>();
                if (noteObj != null)
                {
                    noteObj.Action(false);
                }
            }
        }
    }
}
