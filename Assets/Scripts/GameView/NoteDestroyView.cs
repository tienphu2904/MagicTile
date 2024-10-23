using System;
using GameView;
using UnityEngine;
using UnityEngine.Events;

public class NoteDestroyView : MonoBehaviour
{
    [SerializeField] private UnityEvent loseAction;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var noteObj = other.GetComponent<Note>();
        if (noteObj != null)
        {
            noteObj.Action();
        }
    }
}
