using Unity.Jobs;
using UnityEngine;

public class MeleeEnemy : EnemyBase
{
    [Header("Movement")]
    [SerializeField] float speed = 1f;
    Vector3 linearVelocity = Vector3.left;

    [Header("Damage")]
    [SerializeField] int damage = 2;

    float limitX = 1.5f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(linearVelocity * speed * Time.deltaTime);

        if(transform.position.x < -limitX)
        {
            linearVelocity = Vector3.right;
        }

        if(transform.position.x > limitX)
        {
            linearVelocity = Vector3.left;
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerSpaceShip>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
