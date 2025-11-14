using UnityEngine;
using UnityEngine.InputSystem;

interface IInteractable
{
    public void Interact();
}

public class Interact : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Transform interactorSource;
    [SerializeField] Transform interactorDirection;
    float MaxInteractDistance;

    void Start()
    {
        
    }


    void Update()
    {
        MaxInteractDistance = gameManager.MaxInteractionDistance;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(interactorSource.position, interactorDirection.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, MaxInteractDistance))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(interactorSource.position, interactorDirection.forward * MaxInteractDistance);
    }
}
