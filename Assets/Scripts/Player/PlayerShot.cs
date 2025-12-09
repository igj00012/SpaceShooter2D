using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] float speed = 1.5f;
    [SerializeField] float damage = 1f;

    float lifeTime = 10f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    public float GetDamage()
    {
        return damage;
    }
}
