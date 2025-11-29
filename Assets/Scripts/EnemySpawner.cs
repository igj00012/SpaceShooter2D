using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemiesPrefab;

    public enum SpawnMode
    {
        Line,
        Points,
    }

    [SerializeField] SpawnMode spawnMode;

    [SerializeField] Transform spawnLineTop;
    [SerializeField] Transform spawnLineBottom;

    [SerializeField] Transform[] spawnPoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (spawnMode == SpawnMode.Line)
        {
            StartCoroutine(LineSpawning());
        }
        else if(spawnMode == SpawnMode.Points)
        {
            int numPoints = spawnPoints.Length;
            int j = Random.Range(0, numPoints);

            Vector3 startPosition = spawnPoints[j].position;

            int enemyIndex = Random.Range(0, enemiesPrefab.Length);
            Instantiate(enemiesPrefab[enemyIndex], startPosition, Quaternion.identity);
        }
    }

    IEnumerator LineSpawning()
    {
        Vector3 lineTop = spawnLineTop.position;
        Vector3 lineBottom = spawnLineBottom.position;

        for (int i = 0; i < 5; ++i)
        {
            float t = Random.Range(0f, 1f);
            Vector3 startPosition = Vector3.Lerp(lineTop, lineBottom, t);

            int enemyIndex = Random.Range(0, enemiesPrefab.Length);
            Instantiate(enemiesPrefab[enemyIndex], startPosition, Quaternion.identity);

            yield return new WaitForSeconds(0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
