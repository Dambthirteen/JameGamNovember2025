using UnityEngine;
using FirstGearGames.SmoothCameraShaker;
using Unity.VisualScripting.FullSerializer;
using System.Collections;

public class Explosion : MonoBehaviour
{
    //Classes
    GameManager gameManager;
    [SerializeField] PlayerMovement playerMovement;

    //Vfx
    [SerializeField] ParticleSystem ExplosionParticles;
    [SerializeField] AudioSource ExplosionSound;
    [SerializeField] AudioSource ExplosionSoundLong;
    
    //Enviroment
    [SerializeField] GameObject Deckenlampe;
    [SerializeField] GameObject Deckenlampe1;
    [SerializeField] GameObject Deckenlampe2;

    //UI
    [SerializeField] GameObject PointLight;

    //Bools
    public bool ExplosionTrue {get; private set;}

    public ShakeData Shaker;

    void Start()
    {
        gameManager = GetComponent<GameManager>();
        ExplosionTrue = false;

        PointLight.SetActive(false);
        Deckenlampe.SetActive(true);
        Deckenlampe1.SetActive(true);
        Deckenlampe2.SetActive(true);
    }


    public void ExplosionHandler()
    {
        playerMovement.speed = 0;
        ExplosionTrue = true;
        ExplosionParticles.Play();
        ExplosionSoundLong.Play();
        //CameraShakerHandler.Shake(Shaker);
        StartCoroutine(ExplodePlayer(1.0f));
    }

    IEnumerator ExplodePlayer(float time)
    {
        yield return new WaitForSeconds(time);
        PointLight.SetActive(true);
        ExplosionSound.Play();
        StartCoroutine(TurnOffLight(1.5f));
        Deckenlampe1.SetActive(false);
        Deckenlampe2.SetActive(false);
        CameraShakerHandler.Shake(Shaker);
        StartCoroutine(PlayerDeathEnum(2.5f));
    }

    IEnumerator PlayerDeathEnum(float time)
    {
        yield return new WaitForSeconds(time);
        gameManager.PlayerDeath();
    }

    IEnumerator TurnOffLight(float time)
    {
        yield return new WaitForSeconds(time);
        PointLight.SetActive(false);
    }

}
