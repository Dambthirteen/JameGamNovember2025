using Unity.VisualScripting;
using UnityEngine;

public class CubeTester : MonoBehaviour
{
    [SerializeField] ControlModuleGood controlModuleGood;
    [SerializeField] ControlModuleBad controlModuleBad;
    [SerializeField] Explosion explosion;

    public bool GoodCube { get; private set; }
    public bool CubeEntered { get; private set; }

    void Start()
    {
        CubeEntered = false;
        controlModuleGood.OnBadConfirmed += ExplodeCrate;
    }

    

    void OnTriggerEnter(Collider other)
    {
        CubeEntered = true;

        Animation anim = other.GetComponentInChildren<Animation>();

        if(anim != null)
        {
            anim.Play();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("GoodCube"))
        {
            GoodCube = true;
        }
        if (other.CompareTag("BadCube"))
        {
            GoodCube = false;
        }
        else
        {
            GoodCube = true;
        }
        CubeEntered = true;

        if(explosion.ExplosionTrue)
        {
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        CubeEntered = false;
    }

    void ExplodeCrate()
    {
        explosion.ExplosionHandler();
    }
}
