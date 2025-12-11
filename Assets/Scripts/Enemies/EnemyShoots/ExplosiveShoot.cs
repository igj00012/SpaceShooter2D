using UnityEngine;

public class ExplosiveShoot : MonoBehaviour
{
    float lifeTime = 3f;
    [SerializeField] GameObject explosionArea;
    float damage = 2f;

    [SerializeField] AudioClip clip;

    private void Start()
    {
        lifeTime = Random.Range(1.5f, 3f);
    }

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
            AudioManager.instance.PlaySFX(clip);

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
