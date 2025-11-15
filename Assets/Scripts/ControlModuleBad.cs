using System.Collections;
using UnityEngine;

public class ControlModuleBad : MonoBehaviour,IInteractable
{
    [SerializeField] CubeTester cubeTester;
    [SerializeField] GameManager gameManager;
    public bool GoodTestConfirmed2 { get; private set; }

    public string GetDescription()
    {
        return "Bad Boi";
    }

    public void Interact()
    {
        if (cubeTester.GoodCube && cubeTester.CubeEntered)
        {
            GoodTestConfirmed2 = false;
            gameManager.PlayerDeath();
            Debug.Log("You are dead");
        }
        if (!cubeTester.GoodCube && cubeTester.CubeEntered)
        {
            GoodTestConfirmed2 = true;
            gameManager.AddPoints(1);
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

    
}
