using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] public int health = 5;
    [SerializeField] public int damage = 1;

    public void TakeDamage(int dmg)
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
