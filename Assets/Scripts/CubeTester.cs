using UnityEngine;

public class CubeTester : MonoBehaviour
{
    [SerializeField] ControlModuleGood controlModuleGood;
    [SerializeField] ControlModuleBad controlModuleBad;

    public bool GoodCube { get; private set; }
    public bool CubeEntered { get; private set; }

    void Start()
    {
        CubeEntered = false;
        controlModuleGood.OnBadConfirmed += ExplodeCrate;
        controlModuleBad.OnBadConfirmed += ExplodeCrate;
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
    }

    void OnTriggerExit(Collider other)
    {
        CubeEntered = false;
    }

    void ExplodeCrate()
    {
        
    }
}
