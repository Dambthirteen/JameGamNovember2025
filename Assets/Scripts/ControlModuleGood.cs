using System.Collections;
using UnityEngine;

public class ControlModuleGood : MonoBehaviour,IInteractable
{
    [SerializeField] CubeTester cubeTester;
    [SerializeField] GameManager gameManager;
    public bool GoodTestConfirmed { get; private set; }

    public event System.Action OnGoodConfirmed;
    public event System.Action OnBadConfirmed;

    private bool canInteract;

    [SerializeField] AudioSource ButtonClick;

    public string GetDescription()
    {
        return "Good Boi";
    }

    void Start()
    {
        canInteract = true;
        OnGoodConfirmed += PlayButtonClick;
        OnBadConfirmed += PlayButtonClick;
    }

    public void Interact()
    {
        if(!canInteract) return;
        canInteract = false;
        StartCoroutine(InteractCooldown(2f));

        if (cubeTester.GoodCube && cubeTester.CubeEntered)
        {
            GoodTestConfirmed = true;
            OnGoodConfirmed?.Invoke(); 
            gameManager.AddPoints(1);
            if (gameManager.CountDown > 15f)
            {
                gameManager.AddPoints(1);
            }
            StartCoroutine(ResetBool(2f));
            Debug.Log("That was a very good Cube");
        }
        if (!cubeTester.GoodCube && cubeTester.CubeEntered)
        {
            GoodTestConfirmed = false;
            gameManager.ChangeDeathText("How do you confuse a Bomb with a Cat?");
            OnBadConfirmed?.Invoke();
        }
        if (!cubeTester.CubeEntered)
        {
            Debug.Log("No Cube detected");
            GoodTestConfirmed = false;
        }
    }

    IEnumerator ResetBool(float time)
    {
        yield return new WaitForSeconds(time);
        GoodTestConfirmed = false;
    }

    IEnumerator InteractCooldown(float time)
    {
        yield return new WaitForSeconds(time);
        canInteract = true;
    }

    void PlayButtonClick()
    {
        ButtonClick.Play();
    }

    
}
