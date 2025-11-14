using System.Collections;
using UnityEngine;

public class FliessBandEnd : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    public bool NextCube;
    float SpawnTime;

    void Start()
    {
        NextCube = false;
    }

    void Update()
    {
        SpawnTime = gameManager.SpawnTime;
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        StartCoroutine(NextCubeSpawn(SpawnTime));
    }
    
    IEnumerator NextCubeSpawn(float time)
    {
        yield return new WaitForSeconds(time);
        NextCube = true;
    }
}
