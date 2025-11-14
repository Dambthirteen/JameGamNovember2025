using UnityEngine;
using Unity.Mathematics;

public class Spawner : MonoBehaviour
{
    //Classes
    GameManager gameManager;

    [Header("Drops")]
    public Crates[] crates;

    [System.Serializable]
    public struct Crates
    {
        public string name;
        public GameObject prefab;
    }

    void Update()
    {
        
    }

    public void Drop()
    {
        if (crates.Length == 0) { Debug.Log("Failed To Drop"); return; }
        int r = UnityEngine.Random.Range(0, crates.Length);
        Instantiate(crates[r].prefab, transform.position, quaternion.identity);
    }
}
