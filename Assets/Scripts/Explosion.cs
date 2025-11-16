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
        ExplosionTrue = false;
    }


    public void ExplosionHandler()
    {
        ExplosionTrue = true;
        CameraShakerHandler.Shake(Shaker);
        StartCoroutine(KillPlayer(2));
    }

    IEnumerator KillPlayer(float time)
    {
        yield return new WaitForSeconds(time);
        gameManager.PlayerDeath();
    }

}
