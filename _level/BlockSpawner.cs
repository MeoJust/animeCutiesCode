using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] GameObject _blockPrefab;

    void Start()
    {
        InvokeRepeating("SpawnDatBlock", 1f, Random.Range(.7f, 1.3f));
    }

    void SpawnDatBlock()
    {
        //Instantiate(_blockPrefab, transform.position, Quaternion.identity);
        Instantiate(_blockPrefab, 
        new Vector3(Random.Range(-9f, 9f), transform.position.y, transform.position.z), 
        Quaternion.identity);
    }
}
