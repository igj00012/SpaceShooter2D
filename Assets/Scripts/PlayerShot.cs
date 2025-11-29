using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] float speed = 1.5f;
    [SerializeField] int damage = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    public int GetDamage()
    {
        return damage;
    }
}
