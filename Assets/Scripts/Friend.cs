using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Friend : MonoBehaviour
{
    [SerializeField] InputActionAsset primaryAssets;
    InputActionMap UIActionMap;
    InputAction continueDialog;
    [TextArea] public List<string> dialogos;
    int i;

    // Start is called before the first frame update
    void Awake()
    {
        UIActionMap = primaryAssets.FindActionMap("UI");
        continueDialog = primaryAssets.FindAction("NextDialog");
    }

    public void SpeakDialog()
    {
        StartCoroutine(DialogBox.instance.PrintDialog(dialogos[0]));
    }
}
