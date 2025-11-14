using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Timing")]
    //Speed & Time
    public float FliessBandSpeed;
    [Space]
    public float SpawnTime;

    //Start & Stop
    [Header("Start and Stop Mechanics")]
    public bool StopSpawn { get; private set; }

    //InterAction
    [Header("Interaction")]
    public float MaxInteractionDistance = 10f;

    //PointSystem
    public int Points;




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

    void StartGame()
    {
        if(!StopSpawn)
        {
            Dropping();
        }
        
    }

    void Dropping()
    {

    }

    public void AddPoints(int PointAmount)
    {
        Points += PointAmount;
    }
    
    public void PlayerDeath()
    {
        
    }
}
