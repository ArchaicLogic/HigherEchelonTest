using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwitchBarHandler : MonoBehaviour
{
    [SerializeField] float? mousePosY1 = null, mousePosY2 = null;
    [Header("SwitchControl Members")]
    [SerializeField] bool switchActivated = false;
    [SerializeField] bool switchIsActive;
    int switchCounter;
    [SerializeField] Image switchBar;
    [SerializeField] TMP_Text switchCounterText;
    
    public delegate void  SwitchThrown();
    public static event SwitchThrown OnSwitchThrown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SwitchInputHandler();
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
    IEnumerator SwitchEngineTimer()
    {
        if (OnSwitchThrown != null) { OnSwitchThrown(); }
        switchIsActive = true;
        switchActivated = false;
        switchBar.transform.eulerAngles = new Vector3(0, 0, 135);
        switchCounter++;
        switchCounterText.text = switchCounter.ToString();
        yield return new WaitForSeconds(2);
        switchBar.transform.eulerAngles = new Vector3(0, 0, 45);
        switchIsActive = false;


    }
    public void EnableSwitch()
    {
        switchActivated = true;
    }
    public void DisableSwitch()
    {
        switchActivated = false;
    }
}
