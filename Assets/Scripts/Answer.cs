using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Answer : MonoBehaviour
{
    RectTransform rectTransform;
    [SerializeField] float speed = 5f;
    Vector2 direction;
    public bool state;
    public bool canMove;
    public TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        canMove = true;
        direction.x = Random.Range(-5, 5f);
        direction.y = Random.Range(-2.5f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
        {
            return;
        }
        rectTransform.Translate(direction.normalized * speed * Time.deltaTime);

        if (rectTransform.position.x > 1920)
        {
            rectTransform.position = new Vector2(1919, rectTransform.position.y);
            direction.x = Random.Range(-5, -0.5f);
        }
        else if (rectTransform.position.x < 0)
        {
            rectTransform.position = new Vector2(1, rectTransform.position.y);
            direction.x = Random.Range(0.5f, 5f);
        }

        if (rectTransform.position.y > 1080)
        {
            rectTransform.position = new Vector2(rectTransform.position.x, 1079);
            direction.y = Random.Range(-2.5f, -0.5f);
        }
        else if (rectTransform.position.y < 0)
        {
            rectTransform.position = new Vector2(rectTransform.position.x, 1);
            direction.y = Random.Range(0.5f, 2.5f);
        }

    }
}
