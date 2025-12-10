using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] public float health = 5;
    [SerializeField] public float delay = 2f;

    [Header("Buffs")]
    [SerializeField] GameObject[] buffsArray;

    float healProb = 0.4f;
    float shieldProb = 0.2f;
    float multiProb = 0.1f;

    // Method to update the health of the enemy
    public void TakeDamage(float dmg)
    {
        health -= dmg;

        // Before death, spawns a random buff or not
        if (health <= 0)
        {
            float random = Random.Range(0f, 1f);

            if (random <= healProb)
            {
                SpawnBuff("HealingPotion");
            }
            else if (random <= (healProb + shieldProb))
            {
                SpawnBuff("Shield");
            }
            else if (random <= (healProb + shieldProb + multiProb))
            {
                SpawnBuff("MultiShoot");
            }

            Destroy(gameObject);
        }
    }

    void SpawnBuff(string tag)
    {
        for (int i = 0; i < buffsArray.Length; ++i)
        {
            if (buffsArray[i].CompareTag(tag))
            {
                Instantiate(buffsArray[i], transform.position, Quaternion.identity);
                return;
            }
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
