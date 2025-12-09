using UnityEngine;

public class MultiShoot : MonoBehaviour
{
    [SerializeField] float speed = 2f;

    Vector2 linearVelocity = new Vector2(-0.7f, 1);

    float lifeTime = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    float limitY = 0.5f;
    void Update()
    {
        if (transform.position.y >= limitY)
        {
            linearVelocity.y *= -1;
        }

        if (transform.position.y <= -limitY)
        {
            linearVelocity.y *= -1;
        }

        transform.Translate(linearVelocity * speed * Time.deltaTime);
    }

}
