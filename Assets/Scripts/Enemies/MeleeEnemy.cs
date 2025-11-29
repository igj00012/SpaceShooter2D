using Unity.Jobs;
using UnityEngine;

public class MeleeEnemy : EnemyBase
{
    [SerializeField] float speed = 1f;
    Vector3 linearVelocity = Vector3.left;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(linearVelocity * speed * Time.deltaTime);

        if(transform.position.x < -1.5f)
        {
            linearVelocity = Vector3.right;
        }

        if(transform.position.x > 1.5f)
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
            Destroy(collision.gameObject);
        }
    }
}
