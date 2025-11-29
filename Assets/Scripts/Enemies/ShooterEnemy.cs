using System.Collections;
using UnityEngine;

public class ShooterEnemy : EnemyBase
{
    [Header("Movement")]
    [SerializeField] float speed = 1f;

    [Header("Shooting")]
    [SerializeField] GameObject shootPrefab;
    float delay = 2f;

    Vector3 linearVelocity = Vector3.down;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Shooting());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(linearVelocity * speed * Time.deltaTime);

        if(transform.position.y < -0.8f)
        {
            linearVelocity = Vector3.up;
        }

        if(transform.position.y > 0.8f)
        {
            linearVelocity = Vector3.down;
        }
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            Instantiate(shootPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
    }
}
