using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class GameManager : MonoBehaviour
{
    public bool DebugMode;
    [Space]
    //Classes
    [SerializeField] Spawner spawner;
    [SerializeField] ControlModuleGood controlModuleGood;
    [SerializeField] ControlModuleBad controlModuleBad;
    [SerializeField] CubeTester cubeTester;
    [SerializeField] StopBand stopBand;

    [Header("Game Timing")]
    //Speed & Time
    public float GameSpeed = 1;
    [Space]
    public float FliessBandSpeed;
    [HideInInspector] public float FlieesBandSpeedShader;
    [Space]
    public float SpawnTime;
    [Space]
    public bool StartGameCheck;
    public float StartDelay;
    public float StartAmountCountdown;
    public float CountDown;

    //Start & Stop
    [Header("Start and Stop Mechanics")]
    public bool StopSpawn { get; private set; }
    public bool isDead { get; private set; }

    //InterAction
    [Header("Interaction")]
    public float MaxInteractionDistance = 10f;

    //PointSystem
    public int Points;

    //UI
    [Header("UI")]
    [SerializeField] GameObject DeathScreen;
    [SerializeField] GameObject PointsUI;
    [SerializeField] GameObject InteractionSystem;
    [SerializeField] TMP_Text PointsText;
    [SerializeField] TMP_Text PointsTextDS;
    [SerializeField] TMP_Text DigitalCountdown;
    int FloatToInt;

    



    //Testing
    bool TestKey;

    void Awake()
    {
        StartGameCheck = false;
    }

    void Start()
    {
        if(!DebugMode)
        {
            StartAmountCountdown = DifficultyManager.StartTime;
        }
        StopSpawn = false;
        isDead = false;
        DeathScreen.SetActive(false);
        CountDown = StartAmountCountdown;
    }

    void Update()
    {
        TestKey = Input.GetKey(KeyCode.F);
        PointsText.text = Points.ToString();
        FloatToInt = (int)CountDown;
        DigitalCountdown.text = FloatToInt.ToString();

        if(StartGameCheck && !StopTimer() && cubeTester.CubeEntered)
        {
            StartTimer();
        }

        if(DeathByTime())
        {
            PlayerDeath();
        }
    }

    public void StartGame()
    {
        if(!StopSpawn)
        {
            StartCoroutine(StartDelayEnum(StartDelay));
        }
    }

    void GameStart()
    {
        StartGameCheck = true;
        FlieesBandSpeedShader = FliessBandSpeed * -0.6f;
        stopBand.PlaySound();
        spawner.Drop();
    }

    public void AddPoints(int PointAmount)
    {
        Points += PointAmount;
    }

    public void PlayerDeath()
    {
        //System
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        PointsTextDS.text = Points.ToString();
        isDead = true;
        DeathScreen.SetActive(true);
        DisableUI();
        Time.timeScale = 0;
    }

    public bool DeathByTime()
    {
        return CountDown <= 0;
    }
    
    public void StartTimer()
    {
        CountDown -= Time.deltaTime;
    }

    public bool StopTimer()
    {
        return controlModuleGood.GoodTestConfirmed || controlModuleBad.GoodTestConfirmed2;
    }

    public void ResetTimer()
    {
        CountDown = StartAmountCountdown;
    }

    void DisableUI()
    {
        PointsUI.SetActive(false);
        InteractionSystem.SetActive(false);
    }

    IEnumerator StartDelayEnum(float time)
    {
        yield return new WaitForSeconds(time);
        GameStart();
    }

}
