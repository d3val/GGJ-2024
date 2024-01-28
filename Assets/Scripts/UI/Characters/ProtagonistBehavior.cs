using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagonistBehavior : MonoBehaviour
{
    [SerializeField] ProtagonistBehavior m_Behavior;
    public GameObject [] faces;
    private GameObject actualFace;
    
    public  int desireFace;
    
    /* Variables para testeo de caras
    private int facesAmount;
    private int a;*/

    public void HideActualFace(GameObject OldFace)
    {
        OldFace.SetActive(false);
    }
    public void ShowNewFace(GameObject newFace)
    {
        faces[desireFace].SetActive(true);
    }

    //Función de cambio 
    public void ChangeFace(GameObject face)
    {
        HideActualFace(actualFace);
        ShowNewFace(face);
        actualFace = faces[desireFace];
    }
    void Start()
    {
        desireFace = 1;

        actualFace = faces[desireFace];
        ShowNewFace(actualFace);

        //variable para comprobación para cambio de caras
        //facesAmount = faces.Length;
        //a = 0;
    }
    
    // Método de comprobación para cambio de caras
    /*void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(desireFace < facesAmount)
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
    }*/
}
