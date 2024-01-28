using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogBox : MonoBehaviour
{
    public static DialogBox instance;
    [TextArea] public string text;
    [SerializeField] float printSpeed = 1f;
    public TextMeshProUGUI shownedText;
    float timer;
    int stringIndex;
    string currentText = "";
    public bool isPrinting;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    IEnumerator PrintDialog()
    {
        isPrinting = true;
        stringIndex = 0;
        currentText = "";
        while (currentText != text)
        {
            if (timer > printSpeed)
            {
                currentText += text[stringIndex];
                shownedText.text = currentText;
                stringIndex++;
                timer = 0;
            }
            timer += Time.deltaTime;
            yield return null;
        }
        isPrinting = false;
    }

    public void InstantPrint()
    {
        StopAllCoroutines();
        shownedText.text = text;
        isPrinting= false;
    }

    public void StartPrint(string targetText)
    {
        text= targetText;
        StartCoroutine(PrintDialog());
    }
}

