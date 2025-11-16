using UnityEngine;

public class ControlModule : MonoBehaviour, IInteractable
{
    [SerializeField] GameManager gameManager;
    AudioSource audioSource;
    public event System.Action OnStartConfirmed;
    bool GameStarted;

    void Start()
    {
        GameStarted = false;
        OnStartConfirmed += PlaySound;
        audioSource = GetComponentInChildren<AudioSource>();
    }

    public void Interact()
    {
        if(!GameStarted)
        {
            OnStartConfirmed?.Invoke();
            gameManager.StartGame();
            GameStarted = true;
        }
    }

    public string GetDescription()
    {
        return "Start Testing";
    }

    void PlaySound()
    {
        audioSource.Play();
    }
}
