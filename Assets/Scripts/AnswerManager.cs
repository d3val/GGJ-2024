using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;

public class AnswerManager : MonoBehaviour
{
    [SerializeField] List<GameObject> answers;
    List<Answer> answersComponents;
    public static AnswerManager instance;
    public bool isAnswering;
    public Friend currentFriend;
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
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CheckAnswer(Answer ans)
    {
        if (DialogBox.instance.isPrinting)
            return;

        foreach (GameObject x in answers)
        {
            x.GetComponent<Answer>().canMove = false;
        }
        currentFriend.currentQuestion++;
        isAnswering = false;

        if (ans.state)
            Debug.Log("Exito en la vida");
        else
            Debug.Log("No pues chale");
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
    }

    public void DeactiveAnswers()
    {
        foreach (GameObject answer in answers)
        {
            answer.SetActive(false);
        }
    }
}
