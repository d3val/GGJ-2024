using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerManager : MonoBehaviour
{
    [SerializeField] List<GameObject> answers;
    public static AnswerManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
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
