using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagonistBehavior : MonoBehaviour
{
    [SerializeField] ProtagonistBehavior m_Behavior;
    public GameObject [] faces;
    private GameObject actualFace;
    private int facesAmount;
    public  int desireFace;
    private int a;

    public void HideActualFace(GameObject OldFace)
    {
        OldFace.SetActive(false);
    }
    public void ShowNewFace(GameObject newFace)
    {
        faces[desireFace].SetActive(true);
    }

    //Funci�n de cambio 
    public void ChangeFace(GameObject face)
    {
        HideActualFace(actualFace);
        ShowNewFace(face);
        actualFace = faces[desireFace];
    }
    void Start()
    {
        facesAmount = faces.Length;
        actualFace = faces[0];
        ShowNewFace(actualFace);

        //variable para comprobaci�n para cambio de caras
        a = 0;
    }
    
    // M�todo de comprobaci�n para cambio de caras
    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(desireFace < 2)
            {
                a++;
                desireFace = a;
                ChangeFace(faces[desireFace]);
                Debug.Log(a);
                Debug.Log(desireFace);
            }
            else
            {
                a = 0;
                desireFace = a;
                ChangeFace(faces[desireFace]);
            }
        }
    }
}