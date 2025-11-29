using Unity.Jobs;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    Vector3 linearVelocity = Vector3.left;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(linearVelocity * speed * Time.deltaTime);

        if(transform.position.x < -1.5f)
        {
            linearVelocity = Vector3.right;
        }

        if(transform.position.x > 2f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerShot"))
        {
            Destroy(gameObject);
        }

        if(collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
