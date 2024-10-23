using System.Collections;
using System.Collections.Generic;
using Packs.PoolerPack;
using UnityEngine;
using UnityEngine.Events;

namespace GameView
{
    public enum NoteType
    {
        Show = 0,
        Hide = 1
    }

    public class Note : ObjPooler
    {
        [SerializeField] private SpriteRenderer skinDefault;
        [SerializeField] private SpriteRenderer skinWrong;
        [SerializeField] private UnityEvent onInitAction;
        [SerializeField] private UnityEvent tappedWrongAction;
        [SerializeField] private UnityEvent<Vector3> hideNoteAction;

        private Coroutine _fallCoroutine;
        private float NoteRatio => skinDefault.size.x / skinDefault.size.y;
        public Vector2 SkinSize => skinDefault.bounds.size;
        public List<Note> noteList;
        public NoteType noteType;

        public void OnInit(NoteType typeNote = NoteType.Hide)
        {
            noteType = typeNote;
            noteList = new List<Note>();

            var color = skinDefault.color;
            color.a = noteType == NoteType.Hide ? 0 : 1;
            skinDefault.color = color;

            var noteWidth = Constant.ScreenWidth / 4;
            var noteHeight = noteWidth / NoteRatio;

            transform.localScale = new Vector3(
                noteWidth / skinDefault.bounds.size.x * transform.localScale.x,
                noteHeight / skinDefault.bounds.size.y * transform.localScale.y,
                1);
            onInitAction?.Invoke();
            Active();
        }

        public void Action(bool isFromDestroyView = true)
        {
            switch (noteType)
            {
                case NoteType.Hide:
                    if (!isFromDestroyView)
                    {
                        tappedWrongAction?.Invoke();
                    }
                    break;
                case NoteType.Show:
                    if (isFromDestroyView)
                    {
                        tappedWrongAction?.Invoke();
                    }
                    else
                    {
                        hideNoteAction?.Invoke(transform.position);
                    }
                    foreach (var note in noteList)
                    {
                        note.Inactive();
                    }
                    break;
            }
        }

        public override void Inactive()
        {
            CancelCoroutine();
            base.Inactive();
            foreach (var note in noteList)
            {
                note.Inactive();
            }
        }

        private void CancelCoroutine()
        {
            if (_fallCoroutine != null)
            {
                StopCoroutine(_fallCoroutine);
                _fallCoroutine = null;
            }
        }

        public void StartFalling(float fallSpeed)
        {
            CancelCoroutine();
            _fallCoroutine = StartCoroutine(Falling(fallSpeed));
        }

        public void StopFall()
        {
            StopCoroutine(_fallCoroutine);
        }

        private IEnumerator Falling(float fallSpeed)
        {
            while (true)
            {
                transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

                yield return null;
            }
        }
    }
}