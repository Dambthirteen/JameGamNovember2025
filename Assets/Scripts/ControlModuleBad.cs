using System.Collections;
using UnityEngine;

public class ControlModuleBad : MonoBehaviour,IInteractable
{
    [SerializeField] CubeTester cubeTester;
    [SerializeField] GameManager gameManager;
    public bool GoodTestConfirmed2 { get; private set; }

    public event System.Action OnGoodConfirmed;
    public event System.Action OnBadConfirmed;
    
    bool canInteract;


    public string GetDescription()
    {
        return "Bad Boi";
    }

    void Start()
    {
        canInteract = true;
    }

    public void Interact()
    {
        if(!canInteract) return;
        canInteract = false;
        StartCoroutine(InteractCooldown(2f));
        if (cubeTester.GoodCube && cubeTester.CubeEntered)
        {
            GoodTestConfirmed2 = false;
            OnBadConfirmed?.Invoke();
            gameManager.PlayerDeath();
            Debug.Log("You are dead");
        }
        if (!cubeTester.GoodCube && cubeTester.CubeEntered)
        {
            GoodTestConfirmed2 = true;
            OnGoodConfirmed?.Invoke(); 
            gameManager.AddPoints(1);
            if (gameManager.CountDown > 15f)
            {
                gameManager.AddPoints(1);
            }
            StartCoroutine(ResetBool(2f));
            Debug.Log("That was a good BAD Cube");
        }
        if (!cubeTester.CubeEntered)
        {
            Debug.Log("No Cube detected");
            GoodTestConfirmed2 = false;
        }
    }
    
    IEnumerator ResetBool(float time)
    {
        yield return new WaitForSeconds(time);
        GoodTestConfirmed2 = false;
    }

    IEnumerator InteractCooldown(float time)
    {
        yield return new WaitForSeconds(time);
        canInteract = true;
    }

    
}
