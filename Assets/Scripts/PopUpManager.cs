using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    const int maxInputs = 10;
    int currentInputs;
    [SerializeField] GameObject tryAgainPopup;
    // Start is called before the first frame update
    void Start()
    {
        SwitchBarHandler.OnSwitchThrown += InputCounter;
        ColorButtonHandler.OnColorButtonPressed += InputCounter;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentInputs >= maxInputs)
        {
            tryAgainPopup.SetActive(true);
        }
    }
    void InputCounter()
    {
        currentInputs++;
    }



    public void restartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void QuitGameOverkill()
    {
        GameObject[] _gameObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject o in _gameObjects)
        {
            Destroy(o);
        }
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(0);
        Application.Quit();
    }
    
}
