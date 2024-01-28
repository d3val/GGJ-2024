using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    public enum Scene
    {
        UIScene,
        Nivel1
    }
    public void LoadScene(int scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
    public void LoadNewGame(int scene) 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
