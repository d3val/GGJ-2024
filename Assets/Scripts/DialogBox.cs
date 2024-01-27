using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogBox : MonoBehaviour
{

    [TextArea] public string text;
    [SerializeField] float printSpeed = 1f;
    [SerializeField] TextMeshProUGUI shownedText;
    float timer;
    int stringIndex;
    string currentText = "";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(PrintDialog());
        }
    }

    IEnumerator PrintDialog()
    { 
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
    }
}

