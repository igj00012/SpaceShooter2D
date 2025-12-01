using UnityEngine;

public class FollowingShoot : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    GameObject target;

    float lifeTime = 2f;
    float damage = 1.5f;

    Vector3 targetCurrentPostion;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
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
