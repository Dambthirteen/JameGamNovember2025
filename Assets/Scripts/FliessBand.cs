using UnityEngine;

public class FliessBand : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] StopBand stopBand;
    float Speed;

    public Vector3 direction = Vector3.forward;

    void Start()
    {
        
    }

    void Update()
    {
        Speed = gameManager.FliessBandSpeed;
    }

    void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        if (rb != null && !stopBand.HitStop)
        {
            rb.MovePosition(rb.position + direction.normalized * Speed * Time.deltaTime);
        }
    }
    
    void StopBand()
    {
        
    }
}
