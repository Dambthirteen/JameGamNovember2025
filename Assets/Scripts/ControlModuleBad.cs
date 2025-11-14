using UnityEngine;

public class ControlModuleBad : MonoBehaviour,IInteractable
{
    [SerializeField] CubeTester cubeTester;
    [SerializeField] GameManager gameManager;
    public bool GoodTestConfirmed2 { get; private set; }

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
            Debug.Log("That was a good BAD Cube");
        }
        if(!cubeTester.CubeEntered)
        {
            Debug.Log("No Cube detected");
            GoodTestConfirmed2 = false;
        }
    }

    
}
