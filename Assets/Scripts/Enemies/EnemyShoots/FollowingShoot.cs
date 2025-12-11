using Unity.VisualScripting;
using UnityEngine;

public class FollowingShoot : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    GameObject target; // Player

    float lifeTime = 2f;
    float damage = 3f;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
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
