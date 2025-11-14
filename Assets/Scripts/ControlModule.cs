using UnityEngine;

public class ControlModule : MonoBehaviour, IInteractable
{
    [SerializeField] Spawner spawner;

    public void Interact()
    {
        Debug.Log("Pressed");
        spawner.Drop();
    }
}
