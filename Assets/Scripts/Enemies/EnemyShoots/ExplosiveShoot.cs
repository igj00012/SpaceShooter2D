using UnityEngine;

public class ExplosiveShoot : MonoBehaviour
{
    float lifeTime = 2f;
    [SerializeField] GameObject explosionArea;
    float damage = 2f;

    // Update is called once per frame
    void Update()
    {
        if (lifeTime > 0)
        {
            transform.Translate(Vector3.left * Time.deltaTime * 1f);
            lifeTime -= Time.deltaTime;
        }
        else
        {
            Instantiate(explosionArea, transform.position, Quaternion.identity);
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
    }
}
