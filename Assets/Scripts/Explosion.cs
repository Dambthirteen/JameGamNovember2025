using UnityEngine;
using FirstGearGames.SmoothCameraShaker;
using Unity.VisualScripting.FullSerializer;
using System.Collections;

public class Explosion : MonoBehaviour
{
    //Classes
    GameManager gameManager;

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
        CameraShakerHandler.Shake(Shaker);
        StartCoroutine(ExplodePlayer(2));
    }

    IEnumerator ExplodePlayer(float time)
    {
        yield return new WaitForSeconds(time);
        CameraShakerHandler.Shake(Shaker);
        StartCoroutine(PlayerDeathEnum(2));
    }

    IEnumerator PlayerDeathEnum(float time)
    {
        yield return new WaitForSeconds(time);
        gameManager.PlayerDeath();
    }

}
