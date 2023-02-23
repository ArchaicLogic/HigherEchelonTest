using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationEngine : MonoBehaviour
{
    [SerializeField]
    Image spinner;
    bool engineRunning=false;
    int spinSpeed = 120;
    int spinDir = -1;
    // Start is called before the first frame update
    void Start()
    {

        SwitchBarHandler.OnSwitchThrown += SpinDirectionSwap;
        CollorButtonHandler.OnColorButtonPressed += EngineOnOff;
    }

    // Update is called once per frame
    void Update()
    {
        Engine();
        
    }
    void EngineOnOff()
    {
        engineRunning = !engineRunning;

    }
    void SpinDirectionSwap()
    {
        spinDir = -spinDir;
    }
    void Engine()
    {
        if(engineRunning)
        {
         spinner.transform.Rotate(Vector3.forward * spinDir * spinSpeed * Time.deltaTime);

        }
    }
}
