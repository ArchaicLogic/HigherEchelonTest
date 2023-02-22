using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class MechanismManager : MonoBehaviour

{
    [Header("Mechanism Parts")]
    [SerializeField] Image switchBar, spinner;
    [SerializeField] Button colorSwapButton;
    [SerializeField] TMP_Text switchCounterText, buttonCounterText;
    [SerializeField] GameObject tryAgainPopup;

    [Header("Mouse Input Members")]
    int switchCounter, buttonCounter;
    const int maxInputs = 10;
    [SerializeField] float? mousePosY1 = null, mousePosY2 = null;

    [Header("SwitchControl Members")]
    [SerializeField] bool switchActivated = false;
    [SerializeField] bool switchIsActive;

    [Header("SpinMembers")]
    public bool Spin = false;
    public float spinSpeed;
    int spinDir = -1;

    // Start is called before the first frame update

    private void Update()
    {

        SpinnerEngine();

        SwitchInputHandler();

        TryAgainPopUpTrigger();

    }

    /// <summary>
    /// Activates try again menu if maxInputs is reached
    /// </summary>
    private void TryAgainPopUpTrigger()
    {
        if (switchCounter + buttonCounter >= maxInputs)
        {
            // quePoppup
            tryAgainPopup.SetActive(true);

        }
    }

    /// <summary>
    /// Rotates spinner if spinning is activated via spin bool 
    /// </summary>
    private void SpinnerEngine()
    {
        if (Spin)
        {
            spinner.transform.Rotate(Vector3.forward * spinDir * spinSpeed * Time.deltaTime);
        }
    }

    /// <summary>
    /// Checks mouse input and stores vertical position to check for positional gain
    /// </summary>
    private void SwitchInputHandler()
    {
        if (Input.GetMouseButtonDown(0) && switchActivated)
        {
            mousePosY1 = Input.mousePosition.y;
        }
        if (Input.GetMouseButtonUp(0) && mousePosY1 != null)
        {
            mousePosY2 = Input.mousePosition.y;

            if (mousePosY2 > mousePosY1 && !switchIsActive)
            {
                StartCoroutine(SwitchEngineTimer());
                mousePosY1 = null;
                mousePosY2 = null;
            }
        }
    }

  

    public void ToggleSpinner()
    {
        buttonCounter++;
        buttonCounterText.text = buttonCounter.ToString();
        Spin = !Spin;
    }
    public void ResetButton()
    {
        colorSwapButton.interactable = false;
        colorSwapButton.interactable = true;

    }



    public void EnableSwitch()
    {
        switchActivated = true;
    }
    public void DisableSwitch()
    {
        switchActivated = false;
    }
    IEnumerator SwitchEngineTimer()
    {
        switchIsActive = true;
        switchActivated = false;
        spinDir = -spinDir;
        switchBar.transform.eulerAngles = new Vector3(0, 0, 135);
        switchCounter++;
        switchCounterText.text = switchCounter.ToString();
        yield return new WaitForSeconds(2);
        switchBar.transform.eulerAngles = new Vector3(0, 0, 45);
        switchIsActive = false;


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
