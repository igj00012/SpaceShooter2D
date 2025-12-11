using System.Collections;
using UnityEngine;

public class EnemyBoss : EnemyBase
{
    [Header("Shooting")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] GameObject followingShootPrefab;

    [Header("Fire Points")]
    [SerializeField] Transform laserFirePoint;
    [SerializeField] Transform[] followingShootFirePoint;

    [SerializeField] AudioClip laser;
    [SerializeField] AudioClip followingShoot;

    float delayLaser = 4f;
    bool isLaserActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ShootingCycle());
    }

    IEnumerator ShootingCycle()
    {
        while (true)
        {
            isLaserActive = true;
            Instantiate(laserPrefab, laserFirePoint.position, Quaternion.identity);

            AudioManager.instance.PlaySFX(laser);

            yield return new WaitForSeconds(delayLaser);
            isLaserActive = false;

            float t = 0f;
            while (t < delayLaser)
            {
                if (!isLaserActive)
                {
                    for (int i = 0; i < followingShootFirePoint.Length; i++)
                    {
                        AudioManager.instance.PlaySFX(followingShoot);
                        Instantiate(followingShootPrefab, followingShootFirePoint[i].position, Quaternion.identity);
                    }
                }

                yield return new WaitForSeconds(delay);

                t += delay;
            }
        }
    }

}
