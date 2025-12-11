using System.Collections;
using UnityEngine;

public class ExplosiveEnemy : EnemyBase
{
    [Header("Movement")]
    float speed = 1f;
    Vector3 linearVelocity = Vector3.up;

    [Header("Shooting")]
    [SerializeField] GameObject explosionShoot;

    [SerializeField] AudioClip clip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ExplosionTimer());
    }

    float limitY = 0.8f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(linearVelocity * speed * Time.deltaTime);

        if (transform.position.y < -limitY)
        {
            linearVelocity = Vector3.up;
        }

        if (transform.position.y > limitY)
        {
            linearVelocity = Vector3.down;
        }
    }

    IEnumerator ExplosionTimer()
    {
        while (true)
        {
            AudioManager.instance.PlaySFX(clip);

            Instantiate(explosionShoot, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
    }
}
