using UnityEngine;

public class ControlModuleGood : MonoBehaviour,IInteractable
{
    [SerializeField] CubeTester cubeTester;
    [SerializeField] GameManager gameManager;
    public bool OpenGate { get; private set; }

    public void Interact()
    {
        if (cubeTester.GoodCube && cubeTester.CubeEntered)
        {
            OpenGate = true;
            gameManager.AddPoints(1);
            Debug.Log("That was a very good Cube");
        }
        if (!cubeTester.GoodCube && cubeTester.CubeEntered)
        {
            OpenGate = false;
            gameManager.PlayerDeath();
            Debug.Log("You're Dead");
        }
        if(!cubeTester.CubeEntered)
        {
            Debug.Log("No Cube detected");
        }
    }

    
}
