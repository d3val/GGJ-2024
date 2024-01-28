using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerManager : MonoBehaviour
{
    [SerializeField] List<GameObject> answers;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ActiveAnswers();
        }
    }

    public void ActiveAnswers()
    {
        foreach (GameObject answer in answers)
        {
            answer.SetActive(true);
        }
    }

}
