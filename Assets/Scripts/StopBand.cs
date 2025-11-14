using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class StopBand : MonoBehaviour
{
    public bool HitStop { get; private set; }
    [SerializeField] ControlModuleGood controlModuleGood;
    [SerializeField] ControlModuleBad controlModuleBad;

    void Start()
    {
        HitStop = false;
    }

    void OnTriggerEnter(Collider other)
    {
        HitStop = true;
    }

    void Update()
    {
        OpenTheGate();
    }

    void OpenTheGate()
    {
        if (controlModuleGood.GoodTestConfirmed)
        {
            HitStop = false;
        }
        if(controlModuleBad.GoodTestConfirmed2)
        {
            HitStop = false;
        }
    }
    
    

    


}
