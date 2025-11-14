using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Speed & Time
    public float FliessBandSpeed;

    //Start & Stop
    public bool StopSpawn { get; private set; }




    //Testing
    bool TestKey;

    void Start()
    {
        StopSpawn = false;
    }

    void Update()
    {
        TestKey = Input.GetKey(KeyCode.F);
    }
}
