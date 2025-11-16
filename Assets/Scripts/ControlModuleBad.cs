using System.Collections;
using UnityEngine;

public class ControlModuleBad : MonoBehaviour, IInteractable
{
    [SerializeField] CubeTester cubeTester;
    [SerializeField] GameManager gameManager;
    public bool GoodTestConfirmed2 { get; private set; }

    public event System.Action OnGoodConfirmed;
    public event System.Action OnClickConfirmed;

    bool canInteract;

    [SerializeField] AudioSource ButtonClick;

    public string GetDescription()
    {
        return "Bad Boi";
    }

    void Start()
    {
        canInteract = true;
        OnGoodConfirmed += PlayButtonClick;
        OnClickConfirmed += PlayButtonClick;
    }

    public void Interact()
    {
        if (!canInteract) return;
        canInteract = false;
        StartCoroutine(InteractCooldown(2f));
        if (cubeTester.GoodCube && cubeTester.CubeEntered)
        {
            GoodTestConfirmed2 = false;
            OnClickConfirmed?.Invoke();
            gameManager.ChangeDeathText("Why did you kill a car?");
            gameManager.PlayerDeath();
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

    void PlayButtonClick()
    {
        ButtonClick.Play();
    }


}
