using System.Collections;
using UnityEngine;

public class ShooterEnemy : EnemyBase
{
    [Header("Movement")]
    [SerializeField] float speed = 1f;

    [Header("Shooting")]
    [SerializeField] GameObject shootPrefab;

    Vector3 linearVelocity = Vector3.up;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Shooting());
    }

    float limitY = 0.8f;
    float rightLimit = 1.4f;
    float leftLimit = -0.6f;
    float factor = 0.05f;
    bool movedOnX = false;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(linearVelocity * speed * Time.deltaTime);

        if (transform.position.y < -limitY && !movedOnX)
        {
            linearVelocity = Vector3.up;
            MoveOnXAxis();
            movedOnX = true;
        }
        else if (transform.position.y > limitY && !movedOnX)
        {
            linearVelocity = Vector3.down;
            MoveOnXAxis();
            movedOnX = true;
        }

        if (transform.position.y > -limitY && transform.position.y < limitY) movedOnX = false;
    }

    float dir = 1f;
    void MoveOnXAxis()
    {
        if (transform.position.x < leftLimit)
        {
            transform.position += Vector3.right * factor;
            dir = 1f;
        }
        else if (transform.position.x > rightLimit)
        {
            transform.position += Vector3.left * factor;
            dir = -1f;
        }
        else
        {
            transform.position += Vector3.right * dir * factor;
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
