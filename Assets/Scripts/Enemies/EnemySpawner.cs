using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] normalEnemiesPrefab;
    [SerializeField] GameObject bossPrefab;

    [SerializeField] Transform spawnLineTop;
    [SerializeField] Transform spawnLineBottom;

    const int maxEnemiesOnScreen = 5;
    int bossesCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LineSpawning());
        StartCoroutine(BossSpawning());
    }

    float timer = 0f;
    private void Update()
    {
        timer += Time.deltaTime;
    }

    bool stopSpawn = false;
    IEnumerator LineSpawning()
    {
        Vector3 lineTop = spawnLineTop.position;
        Vector3 lineBottom = spawnLineBottom.position;

        while (!stopSpawn)
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

        yield return new WaitUntil(() => GetEnemiesAlive() == 0);

        GameObject.FindAnyObjectByType<UIManager>().GameWin();
    }

    GameObject GetEnemyToSpawn()
    {
        if (timer < 10)
        {
            return normalEnemiesPrefab[Random.Range(0, normalEnemiesPrefab.Length / 2)];
        }
        else if (timer < 20)
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
    float delayBetweenBosses = 25f;
    IEnumerator BossSpawning()
    {
        while (bossesCount < maxBosses)
        {
            yield return new WaitForSeconds(delayBetweenBosses);

            Vector3 lineTop = spawnLineTop.position;
            Vector3 lineBottom = spawnLineBottom.position;

            float t = Random.Range(0f, 1f);
            Vector3 startPosition = Vector3.Lerp(lineTop, lineBottom, t);

            Instantiate(bossPrefab, startPosition, Quaternion.identity);

            ++bossesCount;

            Debug.Log("Bosses spawned: " + bossesCount);
        }

        stopSpawn = true;
    }
}
