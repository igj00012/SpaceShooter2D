using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] normalEnemiesPrefab;
    [SerializeField] GameObject bossPrefab;

    int bossesCount = 0;

    [SerializeField] Transform spawnLineTop;
    [SerializeField] Transform spawnLineBottom;

    const int maxEnemiesOnScreen = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LineSpawning());
        StartCoroutine(BossSpawning());
    }

    float t = 0f;
    private void Update()
    {
        t += Time.deltaTime;
    }

    IEnumerator LineSpawning()
    {
        Vector3 lineTop = spawnLineTop.position;
        Vector3 lineBottom = spawnLineBottom.position;

        while (true)
        {
            while (GetEnemiesAlive() >= maxEnemiesOnScreen)
            {
                yield return null;
            }

            float t = Random.Range(0f, 1f);
            Vector3 startPosition = Vector3.Lerp(lineTop, lineBottom, t);

            GameObject enemy = GetEnemyToSpawn();

            Instantiate(enemy, startPosition, Quaternion.identity);

            yield return new WaitForSeconds(0.5f);
        }
    }

    GameObject GetEnemyToSpawn()
    {
        if (t < 10)
        {
            return normalEnemiesPrefab[Random.Range(0, normalEnemiesPrefab.Length / 2)];
        }
        else if (t < 20)
        {
            return normalEnemiesPrefab[Random.Range(normalEnemiesPrefab.Length / 2, normalEnemiesPrefab.Length)];
        }
        else return normalEnemiesPrefab[Random.Range(0, normalEnemiesPrefab.Length)];
    }

    int GetEnemiesAlive()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    const int maxBosses = 5;
    float delayBetweenBosses = 30f;
    IEnumerator BossSpawning()
    {
        if (bossesCount < maxBosses && t >= delayBetweenBosses)
        {
            Vector3 lineTop = spawnLineTop.position;
            Vector3 lineBottom = spawnLineBottom.position;

            float t = Random.Range(0f, 1f);
            Vector3 startPosition = Vector3.Lerp(lineTop, lineBottom, t);

            Instantiate(bossPrefab, startPosition, Quaternion.identity);

            ++bossesCount;

            yield return new WaitForSeconds(delayBetweenBosses);
        }
        else if (bossesCount == maxBosses)
        {
            GameObject.FindAnyObjectByType<UIManager>().GameWin();
        }
    }
}
