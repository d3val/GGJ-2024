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
    int currentDialog;

    // Start is called before the first frame update
    void Awake()
    {
        UIActionMap = primaryAssets.FindActionMap("UI");
        continueDialog = primaryAssets.FindAction("NextDialog");

        continueDialog.performed += SpeakDialog;
    }

    public void SpeakDialog(InputAction.CallbackContext ctx)
    {
        if (currentDialog >= dialogos.Count)
            return;
        StartCoroutine(DialogBox.instance.PrintDialog(dialogos[currentDialog]));
        currentDialog++;
    }

    private void OnEnable()
    {
        continueDialog.Enable();
    }

    private void OnDisable()
    {
        continueDialog.Disable();
    }
}
