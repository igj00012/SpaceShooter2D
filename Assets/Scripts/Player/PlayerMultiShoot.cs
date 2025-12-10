using UnityEngine;

public class PlayerMultiShoot : MonoBehaviour
{
    float speed = 2f;
    float lifeTime = 4f;
    float damage = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public float GetDamage() {  return damage; }
}
