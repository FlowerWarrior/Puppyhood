using UnityEngine;

public class RotateUIObject : MonoBehaviour
{
    public GameObject objectToRotate;
    [SerializeField] float rot;
    public AudioSource szum;
    public AudioSource muzyczka;
    public float radioCooldown = 5f; //czas przed ukończeniem minigierki w sekundach
    bool miniGameFinished = false;
    public float volumeChangeSpeed = 5f;
    public float maxVolume = 1f;
    public float minVolume = 0f;

    void Start() {
        volumeChangeSpeed = 2f;
        muzyczka.volume = 0f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnPointerDown();
        }
        OnDrag();
        Radio();
    }

    private Vector2 pointerDownPosition;
    private Quaternion initialRotation;

    public void OnPointerDown()
    {
        Debug.Log("Debug skip of broken radio script");
        TaskManager.instance.SetTaskCompleted(task.TuneTheRadio);
        Destroy(transform.parent.gameObject);

        // Save the initial position of the mouse pointer and the initial rotation of the object.
        pointerDownPosition = Input.mousePosition;
        initialRotation = transform.rotation;
    }

    public void OnDrag()
    {
        // Calculate the rotation angle based on the mouse movement.
        Vector2 pointerDragPosition = Input.mousePosition;
        Vector3 rotationDirection = (pointerDragPosition - pointerDownPosition).normalized;
        float rotationAngle = Vector2.Dot(rotationDirection, Vector2.up) * 90f;

        // Apply the rotation to the object.
        transform.rotation = initialRotation * Quaternion.Euler(0f, 0f, rotationAngle);
    }

    Vector3 startMousePos;
    public void RotateObject() 
    {
        if(!Input.GetMouseButton(0)) return;

        Vector3 direction = (startMousePos - Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + transform.rotation.eulerAngles.z;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void Radio() {
        rot = transform.rotation.eulerAngles.z;
        if((rot > 0) && (rot <30)) {
            //podgłośnienie muzyczki
            float newMusicVolume = Mathf.Clamp01((rot + 180f) / 360f);
            muzyczka.volume = Mathf.Lerp(muzyczka.volume, newMusicVolume, volumeChangeSpeed * Time.deltaTime);
            muzyczka.volume = Mathf.Clamp(muzyczka.volume, minVolume, maxVolume);
            //ściszenie szumu
            float newNoiseVolume = Mathf.Clamp01((rot + 180f) / (-360f));
            szum.volume = Mathf.Lerp(szum.volume, newNoiseVolume, volumeChangeSpeed * Time.deltaTime);
            szum.volume = Mathf.Clamp(szum.volume, minVolume, maxVolume);

            radioCooldown -= Time.deltaTime; //cooldown do zakończenia minigierki
            if((radioCooldown < 0f) && (miniGameFinished == false)) { //zakończenie minigierki
                Debug.Log("Radio Completed");
                miniGameFinished = true; //może dodać, że zamyka to UI odrazu?
            }
        } 
        else {
            //podgłośnienie szumu
            float newNoiseVolume = Mathf.Clamp01((rot + 180f) / 360f);
            szum.volume = Mathf.Lerp(szum.volume, newNoiseVolume, volumeChangeSpeed * Time.deltaTime);
            szum.volume = Mathf.Clamp(szum.volume, minVolume, maxVolume);
            //ściszenie muzyczki
            float newMusicVolume = Mathf.Clamp01((rot + 180f) / (-360f));
            muzyczka.volume = Mathf.Lerp(muzyczka.volume, newMusicVolume, volumeChangeSpeed * Time.deltaTime);
            muzyczka.volume = Mathf.Clamp(muzyczka.volume, minVolume, maxVolume);
        }
    }
}
