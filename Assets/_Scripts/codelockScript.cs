using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class codelockScript : MonoBehaviour
{
    public Image[] images;
    public Sprite[] sprites;
    public Button[] upButtons;
    public Button[] downButtons;
    public int[] code;
    public List<int> spriteIndexes;
    public bool isUnlocked = false;

    void Start() {
        for (int i = 0; i < upButtons.Length; i++) {
            int buttonIndex = i;
            upButtons[i].onClick.AddListener(() => upButtonTask(buttonIndex));
        }

        for (int i = 0; i < downButtons.Length; i++) {
            int buttonIndex = i;
            downButtons[i].onClick.AddListener(() => downButtonTask(buttonIndex));
        }
    }

    void UpdateLock()
    {
        if (spriteIndexes.Count == code.Length && spriteIndexes.All(x => code.Contains(x)))
        {
            isUnlocked = true;
            TaskManager.instance.SetTaskCompleted(task.UnlockChest);
            GetComponent<UIpanel>().DestroySelf();
        }
    }


    void upButtonTask(int buttonIndex)
    {
        spriteIndexes[buttonIndex] = (spriteIndexes[buttonIndex] % 4) + 1;
        images[buttonIndex].sprite = sprites[spriteIndexes[buttonIndex] - 1];
        UpdateLock();
    }

    void downButtonTask(int buttonIndex)
    {
        spriteIndexes[buttonIndex] = (spriteIndexes[buttonIndex] - 2 + 4) % 4 + 1;
        images[buttonIndex].sprite = sprites[spriteIndexes[buttonIndex] - 1];
        UpdateLock();
    }
}

