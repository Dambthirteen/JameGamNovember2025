using UnityEngine;
using FirstGearGames.SmoothCameraShaker;
using Unity.VisualScripting.FullSerializer;
using System.Collections;

public class Explosion : MonoBehaviour
{
    //Classes
    GameManager gameManager;

    //Vfx
    [SerializeField] ParticleSystem ExplosionParticles;
    [SerializeField] AudioSource ExplosionSound;

    //Bools
    public bool ExplosionTrue {get; private set;}

    public ShakeData Shaker;

    void Start()
    {
        gameManager = GetComponent<GameManager>();
        ExplosionTrue = false;
    }


    public void ExplosionHandler()
    {
        ExplosionTrue = true;
        ExplosionParticles.Play();
        ExplosionSound.Play();
        //CameraShakerHandler.Shake(Shaker);
        StartCoroutine(ExplodePlayer(0.5f));
    }

    IEnumerator ExplodePlayer(float time)
    {
        yield return new WaitForSeconds(time);
        CameraShakerHandler.Shake(Shaker);
        StartCoroutine(PlayerDeathEnum(1.5f));
    }

    IEnumerator PlayerDeathEnum(float time)
    {
        yield return new WaitForSeconds(time);
        gameManager.PlayerDeath();
    }

}
