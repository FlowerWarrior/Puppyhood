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
    public float a, b;

    void Start() {
        volumeChangeSpeed = 2f;
        muzyczka.volume = 0f;
    }

    private void Update()
    {
        RotateObject();
        Radio();
    }

    public void RotateObject() {
        if(!Input.GetMouseButton(0)) return;
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = Vector3.Normalize(cursorPosition - objectToRotate.transform.position);

        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.back);
        rotation = Quaternion.Euler(0, 0, -rotation.eulerAngles.z);
        objectToRotate.transform.rotation = rotation;
    }

    public void Radio() {
        rot = transform.rotation.eulerAngles.z;
        if((rot > a) && (rot < b)) {
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
                TaskManager.instance.SetTaskCompleted(task.TuneTheRadio);
                GetComponentInParent<UIpanel>().DestroySelf();
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