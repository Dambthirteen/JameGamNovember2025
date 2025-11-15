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

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip FliessBandSound;

    void Start()
    {
        controlModuleGood.OnGoodConfirmed += OpenTheGate;
        controlModuleBad.OnGoodConfirmed += OpenTheGate;
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
        if(!HitStop)
        {SetSpeedX(gameManager.FlieesBandSpeedShader);}

        if(HitStop)
        {
            audioSource.Stop();
        }
    }

    void OpenTheGate()
    {
        HitStop = false;
        PlaySound();
        SetSpeedX(gameManager.FlieesBandSpeedShader);
    }

    void SetSpeedX(float newX)
    {
        SpeedFL.x = newX;
        Fliessband.SetVector("_speed", SpeedFL);
    }

    public void PlaySound()
    {
        audioSource.Play();
    }

    
    

    


}
