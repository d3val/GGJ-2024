using System;
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
    public int currentDialog;
    [SerializeField] List<Question> questions;
    [SerializeField] List<int> dialogQuestions;
    public int currentQuestion;

    // Start is called before the first frame update
    void Awake()
    {
        UIActionMap = primaryAssets.FindActionMap("UI");
        continueDialog = primaryAssets.FindAction("NextDialog");

        continueDialog.performed += SpeakDialog;
    }

    public void SpeakDialog(InputAction.CallbackContext ctx)
    {
        if (AnswerManager.instance.isAnswering)
            return;

        AnswerManager.instance.DeactiveAnswers();

        if (DialogBox.instance.isPrinting)
        {
            DialogBox.instance.InstantPrint();
            return;
        }

        if (currentDialog < dialogos.Count)
        {
            DialogBox.instance.StartPrint(dialogos[currentDialog]);
            currentDialog++;
        }

        if (dialogQuestions.Contains(currentDialog - 1))
        {
            List<string> answerTexts = new List<string>();
            List<bool> answerValue = new List<bool>();
            foreach (PosssibleAnswer x in questions[currentQuestion].answers)
            {
                answerTexts.Add(x.answerText);
                answerValue.Add(x.isCorrect);
            }
            AnswerManager.instance.ActiveAnswers(answerTexts, answerValue, this);
        }
    }

    private void OnEnable()
    {
        continueDialog.Enable();
    }

    private void OnDisable()
    {
        continueDialog.Disable();
    }

    [Serializable]
    public class PosssibleAnswer
    {
        [TextArea] public string answerText;
        public bool isCorrect = false;
    }

    [Serializable]
    public class Question
    {
        public List<PosssibleAnswer> answers;
    }
}
