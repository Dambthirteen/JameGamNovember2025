using Unity.VisualScripting;
using UnityEngine;

public class StopBand : MonoBehaviour
{
    public bool HitStop { get; private set; }

    void Start()
    {
        HitStop = false;
    }

    void OnTriggerEnter(Collider other)
    {
        HitStop = true;
    }

    void OnTriggerExit(Collider other)
    {
        HitStop = false;
    }


}
