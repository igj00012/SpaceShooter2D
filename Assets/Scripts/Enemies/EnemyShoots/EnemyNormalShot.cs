using UnityEngine;

public class EnemyNormalShot : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    float damage = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerSpaceShip>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("PlayerShot"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
