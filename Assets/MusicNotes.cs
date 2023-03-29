using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNotes : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject musicNotesCanvas;

    public void Pressed()
    {

    }

    public void Released()
    {
        Instantiate(musicNotesCanvas);
    }
}
