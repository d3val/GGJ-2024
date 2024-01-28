using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockAnimation : MonoBehaviour
{
    [SerializeField] Sprite[] clockFrames;

    public float clockTimer;
    public bool timerOn;

    private Image image;
    private int totalFrames;
    private int actualFrame;


    void Start()
    {
        totalFrames = clockFrames.Length;
        actualFrame = 0;
        image = gameObject.GetComponent<Image>();   
    }

    // Start is called before the first frame update
    public void NextFrame()
    {
        if(actualFrame != totalFrames - 1)
        {
            actualFrame++;
            image.sprite = clockFrames[actualFrame];
        }
        else 
        {
            actualFrame = 0;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if (clockTimer > 0)
            {
                clockTimer -= Time.deltaTime;
            }
            else 
            {
                Debug.Log("Times up");
                timerOn = false;
                clockTimer = 0;

            }
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            NextFrame();    
        }
    }
}
