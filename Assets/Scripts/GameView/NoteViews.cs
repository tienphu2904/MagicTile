using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Packs.PoolerPack;
using UnityEngine;

namespace GameView
{
    public class NoteViews : MonoBehaviour
    {
        [SerializeField] private Note noteTemplate;

        private int _prevNoteIndex;
        private readonly Pooler _pooler = new();
        public List<Note> NoteActive => _pooler.GetPooler(noteTemplate).ListActive.OfType<Note>().ToList();

        public void OnInit()
        {
            _prevNoteIndex = Constant.InvalidIndex;

            noteTemplate.OnInit();
            _pooler.InActiveAll();
            noteTemplate.Inactive();

            var positionY = Constant.ScreenHeight;
            var positionX = -(Constant.ScreenWidth - noteTemplate.SkinSize.x) / 2f;
            transform.position = new Vector2(positionX, positionY);
        }

        public void OnDespawn()
        {
            _pooler.InActiveAll();
        }

        public void StopNote()
        {
            foreach (var note in NoteActive)
            {
                note.StopFall();
            }
        }

        public IEnumerator SpawnNotes(float fallSpeed)
        {
            var delayTime = noteTemplate.SkinSize.y / fallSpeed;
            
            while (true)
            {
                SpawnNote(fallSpeed);
                yield return new WaitForSeconds(delayTime);
            }
        }

        private void SpawnNote(float fallSpeed)
        {
            var noteIndex = GetRandomNoteIndex();
            var noteRowList = new List<Note>();
            
            for (int i = 0; i < Constant.NumberColumn; i++)
            {
                var obj = _pooler.GetObj(noteTemplate, transform);
                obj.transform.position = transform.position + Vector3.right * i * noteTemplate.SkinSize.x;
                var noteType = noteIndex == i ? NoteType.Show : NoteType.Hide;
                obj.OnInit(noteType);
                obj.StartFalling(fallSpeed);
                noteRowList.Add(obj);
            }
            var noteHideList = noteRowList.Find((note) => note.noteType == NoteType.Show);
            noteHideList.noteList = noteRowList.FindAll((note) => note.noteType == NoteType.Hide);
        }

        private int GetRandomNoteIndex()
        {
            var randomNoteIndex = Random.Range(0, 4);
            while (randomNoteIndex == _prevNoteIndex) randomNoteIndex = Random.Range(0, 4);
            _prevNoteIndex = randomNoteIndex;
            return randomNoteIndex;
        }
    }
}