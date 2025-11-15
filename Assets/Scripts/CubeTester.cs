using UnityEngine;

public class CubeTester : MonoBehaviour
{
    public bool GoodCube { get; private set; }
    public bool CubeEntered { get; private set; }

    void Start()
    {
        CubeEntered = false;
    }

    void OnTriggerEnter(Collider other)
    {
        CubeEntered = true;
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
}
