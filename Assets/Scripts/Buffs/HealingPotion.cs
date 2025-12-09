using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    float lifeTime = 10f;
    float speed = 0.5f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
