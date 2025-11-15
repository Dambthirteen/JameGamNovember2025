using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class StopBand : MonoBehaviour
{
    public bool HitStop { get; private set; }
    [SerializeField] ControlModuleGood controlModuleGood;
    [SerializeField] ControlModuleBad controlModuleBad;
    [SerializeField] GameManager gameManager;

    [SerializeField] Material Fliessband;
    Vector2 SpeedFL;

    void Start()
    {
        HitStop = false;
        SpeedFL = Fliessband.GetVector("_speed");
    }

    void OnTriggerEnter(Collider other)
    {
        HitStop = true;
        SetSpeedX(0);
    }

    void Update()
    {
        OpenTheGate();

        if(!HitStop)
        {SetSpeedX(gameManager.FlieesBandSpeedShader);}
    }

    void OpenTheGate()
    {
        if (controlModuleGood.GoodTestConfirmed)
        {
            HitStop = false;
            SetSpeedX(gameManager.FlieesBandSpeedShader);
        }
        if (controlModuleBad.GoodTestConfirmed2)
        {
            HitStop = false;
            SetSpeedX(gameManager.FlieesBandSpeedShader);
        }
    }

    
    void SetSpeedX(float newX)
    {
        SpeedFL.x = newX;
        Fliessband.SetVector("_speed", SpeedFL);
    }

    
    

    


}
