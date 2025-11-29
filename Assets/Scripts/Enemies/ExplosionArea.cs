using UnityEngine;

public class ExplosionArea : MonoBehaviour
{
    int initialDamage = 5;
    int damageOverTime = 2;
    float lifeTime = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerSpaceShip>().TakeDamage(initialDamage);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerSpaceShip>().TakeDamage(damageOverTime);
        }
    }
}
