using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogText;
    public Text nameText;
    public GameObject dialogBox;
    public GameObject nameBox;

    public string[] dialogLines;
    public int currentLine;

    public static DialogManager instance;

    private bool justStarted;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogBox.activeInHierarchy)
        {
            if(Input.GetButtonUp("Fire1"))
            {

                if(currentLine >= dialogLines.Length)
                {
                    dialogBox.SetActive(false);
                    GameManager.instance.dialogActive = false;

                }
                else
                {
                    CheckName();
                    dialogText.text = dialogLines[currentLine];
                    currentLine++;
                }

            }
        }
    }

    public void ShowDialog(string[] newLines, bool isPerson)
    {
        dialogLines = newLines;
        currentLine = 0;
        CheckName();
        dialogText.text = dialogLines[currentLine];
        dialogBox.SetActive(true);
        GameManager.instance.dialogActive = true;
        nameBox.SetActive(isPerson);
    }

    public void CheckName()
    {
        if(dialogLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogLines[currentLine].Replace("n-", "");
            currentLine++;
        }
    }
}
