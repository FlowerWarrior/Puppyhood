using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : MonoBehaviour
{
    public static AudioMgr instance;

    [SerializeField] public AudioSource audioPrefab;

    [SerializeField] public AudioClip[] carCrash;
    [SerializeField] public AudioClip[] dogSteps;
    [SerializeField] public AudioClip[] dogWheels;
    [SerializeField] public AudioClip[] ThrowStick;
    [SerializeField] public AudioClip[] LandedStick;
    [SerializeField] public AudioClip[] birdAway;
    [SerializeField] public AudioClip[] ghostMove;
    [SerializeField] public AudioClip[] collectDogPart;
    [SerializeField] public AudioClip[] pinCodeClick;
    [SerializeField] public AudioClip[] lightUpCandle;
    [SerializeField] public AudioClip[] chestOpen;
    [SerializeField] public AudioClip[] clockTick;
    [SerializeField] public AudioClip[] wallGoingUp;
    [SerializeField] public AudioClip[] ladderMoved;
    [SerializeField] public AudioClip[] colllectLighter;
    [SerializeField] public AudioClip[] barking;
    [SerializeField] public AudioClip[] interactSniff;
    [SerializeField] public AudioClip[] enterDoor;
    [SerializeField] public AudioClip[] interactTrumna;
    [SerializeField] public AudioClip[] pickupStick;
    [SerializeField] public AudioClip[] uiClick;
    
    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        TaskManager.OnNewTask += OnNewTaskCallback;
    }

    private void OnDisable()
    {
        TaskManager.OnNewTask -= OnNewTaskCallback;
    }

    private void OnNewTaskCallback(task completedTask, task newTask)
    {
        switch (completedTask)
        {
            case task.CarCrash:
                PlaySound(carCrash);
                break;
            case task.PickupStick:
                PlaySound(pickupStick);
                break;
            case task.UnlockChest:
                PlaySound(chestOpen);
                break;
            case task.EnterDoor:
                PlaySound(enterDoor);
                break;
            case task.ClickTrumna:
                PlaySound(interactTrumna);
                break;
            case task.InteractClockFace:
                PlaySound(clockTick);
                break;
            case task.CollectDogPart:
                PlaySound(collectDogPart);
                break;
        }

        switch (newTask)
        {
            case task.WallUpAnim:
                PlaySound(wallGoingUp);
                break;
            case task.InteractBird:
                PlaySound(birdAway);
                break;
        }
    }

    public void PlaySound(AudioClip[] clip)
    {
        if (clip.Length == 0 || clip == null)
        {
            Debug.Log("audioclip null, skipping");
            return;
        }
        AudioSource newAudio = Instantiate(audioPrefab);
        newAudio.clip = clip[Random.Range(0, clip.Length)];
        newAudio.Play();
        Destroy(newAudio.gameObject, newAudio.clip.length);
    }
}
