using System.Collections;
using UnityEngine;

public class ControlModuleGood : MonoBehaviour,IInteractable
{
    [SerializeField] CubeTester cubeTester;
    [SerializeField] GameManager gameManager;
    public bool GoodTestConfirmed { get; private set; }

    public event System.Action OnGoodConfirmed;

    public string GetDescription()
    {
        return "Good Boi";
    }

    public void Interact()
    {
        if (cubeTester.GoodCube && cubeTester.CubeEntered)
        {
            GoodTestConfirmed = true;
            OnGoodConfirmed?.Invoke(); 
            gameManager.AddPoints(1);
            StartCoroutine(ResetBool(2f));
            Debug.Log("That was a very good Cube");
        }
        if (!cubeTester.GoodCube && cubeTester.CubeEntered)
        {
            GoodTestConfirmed = false;
            gameManager.PlayerDeath();
            Debug.Log("You're Dead");
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

    
}
