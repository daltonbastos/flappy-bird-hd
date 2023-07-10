using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private float heightRange = 2f;

    [Space]

    [SerializeField] Pipe pipePrefab;
    [SerializeField, Range(1, 20)] private int destroyAfter = 5;

    private float currentRate;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (currentRate < spawnRate)
            currentRate += Time.deltaTime;
        else
            SpawPipe();
    }

    private void SpawPipe()
    {
        currentRate = 0;

        Vector3 spawnPosition = new Vector2(transform.position.x, Random.Range(-heightRange, heightRange));
        GameObject tempPipe = Instantiate(pipePrefab.gameObject, spawnPosition, Quaternion.identity);

        Destroy(tempPipe, destroyAfter);
    }
}
