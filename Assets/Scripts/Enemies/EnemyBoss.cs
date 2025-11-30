using UnityEngine;

public class EnemyBoss : EnemyBase
{
    [Header("Movement")]
    [SerializeField] float speed = 1f;
    Vector3 linearVelocity = Vector3.zero;

    [Header("Goal")]
    [SerializeField] GameObject target;

    [Header("Shooting")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] GameObject followingShootPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
