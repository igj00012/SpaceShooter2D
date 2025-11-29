using System.Collections;
using UnityEngine;

public class ExplosiveEnemy : EnemyBase
{
    float delay = 5f;

    [SerializeField] GameObject explosionShoot;

    float actualXPos;
    Vector3 linearVelocity = Vector3.up;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actualXPos = transform.position.x;

        StartCoroutine(ExplosionTimer());
    }

    float factor = 0.4f;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 1.3f)
        {
            linearVelocity = Vector3.left;
        }

        if(transform.position.x > actualXPos + factor)
        {
            linearVelocity = Vector3.down;
        }

        if(transform.position.y < -1.3f)
        {
            linearVelocity = Vector3.left;
        }

        if (transform.position.x < actualXPos - factor)
        {
            linearVelocity = Vector3.up;
        }
    }

    IEnumerator ExplosionTimer()
    {
        while (true)
        {
            Instantiate(explosionShoot, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
    }
}
