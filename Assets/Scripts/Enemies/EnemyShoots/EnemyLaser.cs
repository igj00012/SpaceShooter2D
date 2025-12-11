using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    float lifeTime = 5;
    float damage = 0.2f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerSpaceShip>().TakeDamage(damage);
        }
    }
}
