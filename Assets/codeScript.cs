using UnityEngine;
using UnityEngine.UI;

public class codeScript : MonoBehaviour
{
    public Button[] buttons;
    public string code;
    public string inputCode;

    void Start() {
        for (int i = 0; i < buttons.Length; i++) {
            int buttonIndex = i;
            buttons[i].onClick.AddListener(() => TaskOnClick(buttonIndex));
        }
    }

    // void TaskOnClick(int buttonIndex)
    // {
    //     switch (buttonIndex)
    //     {
    //         case 0:
    //             inputCode += "1";
    //             break;
    //         case 1:
    //             inputCode += "2";
    //             break;
    //         case 2:
    //             inputCode += "3";
    //             break;
    //         case 3:
    //             inputCode += "4";
    //             break;
    //     }
    // }

    void TaskOnClick(int buttonIndex)
    {
        inputCode += (buttonIndex + 1).ToString();

        if (inputCode == code)
        {
            TaskManager.instance.SetTaskCompleted(task.UnlockMusicPinCode);
            GetComponent<UIpanel>().DestroySelf();
        }
        else if (inputCode.Length == 4)
        {
            inputCode = "";
        }
    }
}
