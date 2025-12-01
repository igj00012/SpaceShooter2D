using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] public float health = 5;
    [SerializeField] public float delay = 2f;

    public void TakeDamage(float dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerShot"))
        {
            TakeDamage(collision.GetComponent<PlayerShot>().GetDamage());
            Destroy(collision.gameObject);
        }
    }
}
