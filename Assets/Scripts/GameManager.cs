using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Timing")]
    //Speed & Time
    public float FliessBandSpeed;
    [Space]
    public float SpawnTime;
    [Space]
    public float StartAmountCountdown;
    public float CountDown;

    //Start & Stop
    [Header("Start and Stop Mechanics")]
    public bool StopSpawn { get; private set; }

    //InterAction
    [Header("Interaction")]
    public float MaxInteractionDistance = 10f;

    //PointSystem
    public int Points;

    //UI
    [Header("UI")]
    [SerializeField] GameObject DeathScreen;
    [SerializeField] TMP_Text PointsText;

    



    //Testing
    bool TestKey;

    void Start()
    {
        StopSpawn = false;
        DeathScreen.SetActive(false);
        CountDown = StartAmountCountdown;
    }

    void Update()
    {
        TestKey = Input.GetKey(KeyCode.F);
        PointsText.text = Points.ToString();
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
        DeathScreen.SetActive(true);
    }
    
    public void Timer()
    {
        CountDown -= Time.deltaTime;
    }
}
