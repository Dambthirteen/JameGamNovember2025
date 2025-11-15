using UnityEngine;

public class ControlModule : MonoBehaviour, IInteractable
{
    [SerializeField] GameManager gameManager;
    bool GameStarted;

    void Start()
    {
        GameStarted = false;
    }

    public void Interact()
    {
        if(!GameStarted)
        {
            gameManager.StartGame();
            GameStarted = true;
        }
    }
}
