using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

interface IInteractable
{
    public void Interact();
    string GetDescription();
}

public class Interact : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Transform interactorSource;
    [SerializeField] Transform interactorDirection;
    float MaxInteractDistance;

    public GameObject interactionGUI;
    public TextMeshProUGUI interactionText;

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

        InteractionRay();
    }

    void InteractionRay()
    {
        Ray r = new Ray(interactorSource.position, interactorDirection.forward);
        RaycastHit hit;

        bool hitSomething = false;

        if(Physics.Raycast(r, out hit, MaxInteractDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if(interactable != null)
            {
                hitSomething = true;
                interactionText.text = interactable.GetDescription();
            }
        }

        interactionGUI.SetActive(hitSomething);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(interactorSource.position, interactorDirection.forward * MaxInteractDistance);
    }
}
