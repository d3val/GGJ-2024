using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class AnswerManager : MonoBehaviour
{
    [SerializeField] float confidenceWinValue = 40;
    [SerializeField] float confidenceLostValue = 30;
    [SerializeField] List<GameObject> answers;
    List<Answer> answersComponents;
    public static AnswerManager instance;
    public bool isAnswering;
    public Friend currentFriend;
    public GameObject confidenceSlider;
    public float confidenceDecreaseSpeed = 2;
    public GameObject dialogUI;
    Slider slider;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            answersComponents = new List<Answer>();
            foreach (GameObject gameObject in answers)
            {
                answersComponents.Add(gameObject.GetComponent<Answer>());
            }
            slider = confidenceSlider.GetComponent<Slider>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ActiveDialog()
    {
        dialogUI.SetActive(true);
    }

    private void Update()
    {
        if (slider.IsActive())
        {
            if(slider.value==slider.maxValue)
            {
                EndConversation();
                return;
            }
            slider.value -= Time.deltaTime* confidenceDecreaseSpeed;
        }
    }

    public void CheckAnswer(Answer ans)
    {
        if (DialogBox.instance.isPrinting)
            return;

        foreach (GameObject x in answers)
        {
            x.GetComponent<Answer>().canMove = false;
            x.GetComponent<Button>().interactable = false;
        }
        currentFriend.currentQuestion++;
        isAnswering = false;

        if (ans.state)
            slider.value += confidenceWinValue;
        else
            slider.value -= confidenceLostValue;

    }

    public void EndConversation()
    {
        confidenceSlider.SetActive(false);
        currentFriend.currentDialog = currentFriend.dialogos.Count - 1;
        currentFriend = null;
    }

    public void ActiveAnswers(List<string> answerTexts, List<bool> state, Friend friend)
    {
        currentFriend = friend;
        isAnswering = true;
        int i = 0;
        foreach (GameObject answer in answers)
        {
            answer.SetActive(true);
            Answer ans = answer.GetComponent<Answer>();
            ans.textMeshProUGUI.text = answerTexts[i];
            ans.state = state[i];
            ans.canMove = true;
            i++;
        }
        confidenceSlider.SetActive(true);
    }

    public void DeactiveAnswers()
    {
        foreach (GameObject answer in answers)
        {
            answer.SetActive(false);
        }
    }
}
