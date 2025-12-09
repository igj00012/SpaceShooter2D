using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] public float health = 5;
    [SerializeField] public float delay = 2f;

    [Header("Buffs")]
    [SerializeField] GameObject[] buffsArray;

    // Method to update the health of the enemy
    public void TakeDamage(float dmg)
    {
        health -= dmg;

        // Before death, spawns a random buff or not
        if (health <= 0)
        {
            int buffIndex = Random.Range(-1, buffsArray.Length);

            if (buffIndex != -1)
            {
                Instantiate(buffsArray[buffIndex], transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerShot"))
        {
            if (collision.GetComponent<PlayerShot>())
            {
                TakeDamage(collision.GetComponent<PlayerShot>().GetDamage());
                Destroy(collision.gameObject);
            }
            else if (collision.GetComponent<PlayerMultiShoot>())
            {
                TakeDamage(collision.GetComponent<PlayerMultiShoot>().GetDamage());
                Destroy(collision.gameObject);
            }
        }
    }
}
