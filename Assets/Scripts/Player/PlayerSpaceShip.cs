using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpaceShip : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float maxSpeed = 100f;
    [SerializeField] float acceleration = 300f;

    [Header("Shooting")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float health = 10f;
    [SerializeField] GameObject multiShootPrefab;

    float maxHealth;

    [Header("Actions")]
    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference shoot;

    [Header("References")]
    [SerializeField] HPManager hpmanager;
    [SerializeField] GameObject shield;

    // Initialize health
    private void Start()
    {
        if (hpmanager != null)
        {
            hpmanager.UpdateHP(health);
        }

        maxHealth = health;
        shield.SetActive(false);
    }

    // Activate input actions
    private void OnEnable()
    {
        move.action.Enable();
        shoot.action.Enable();

        move.action.started += OnMove;
        move.action.performed += OnMove;
        move.action.canceled += OnMove;

        shoot.action.started += OnShoot;
    }

    Vector2 currentVelocity = Vector2.zero;
    const float rawMoveTresholdorBreaking = 0.1f;
    const float velocityFactor = 0.1f;
    // Update is called once per frame
    void Update()
    {
        if (rawMove.magnitude < rawMoveTresholdorBreaking)
        {
            currentVelocity *= velocityFactor * Time.deltaTime;
        }

        currentVelocity += rawMove * acceleration * Time.deltaTime;

        float linearVelocity = currentVelocity.magnitude;
        linearVelocity = Mathf.Clamp(linearVelocity, 0, maxSpeed);
        currentVelocity = currentVelocity.normalized * linearVelocity;

        transform.Translate(currentVelocity * Time.deltaTime);

        Debug.Log("Health: " + health);
    }

    // Deactivate input actions
    private void OnDisable()
    {
        move.action.Disable();
        shoot.action.Disable();

        move.action.started -= OnMove;
        move.action.performed -= OnMove;
        move.action.canceled -= OnMove;

        shoot.action.started += OnShoot;
    }

    // Method that decrement current health
    bool shieldActivated = false;
    public void TakeDamage(float damage)
    {
        if (!shieldActivated)
        {
            health -= damage;

            if (hpmanager != null)
            {
                hpmanager.UpdateHP(health);
            }
        }

        if (health <= 0)
        {
            StopAllCoroutines();
            Destroy(gameObject);
        }
    }

    // Input actions methods
    Vector2 rawMove;
    private void OnMove(InputAction.CallbackContext context)
    {
        rawMove = context.ReadValue<Vector2>();
    }

    bool multiShoots = false;
    private void OnShoot(InputAction.CallbackContext context)
    {
        if (!multiShoots)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HealingPotion"))
        {
            if (health < maxHealth)
            {
                hpmanager.UpdateHP(health * 0.2f);
                Destroy(collision.gameObject);
            }
        }
        else if (collision.CompareTag("Shield"))
        {
            shieldActivated = true;
            StartCoroutine(Invulnerability());
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("MultiShoot"))
        {
            multiShoots = true;
            StartCoroutine(MultiShooting());
            Destroy(collision.gameObject);
        }
    }

    float invulnerabilityTime = 5f;
    // Activates the shield, wait for 5 seconds and deactivate it
    IEnumerator Invulnerability()
    {
        shield.SetActive(true);

        yield return new WaitForSeconds(invulnerabilityTime);

        shieldActivated = false;
        shield.SetActive(false);
    }


    float multiShootingTime = 2f;
    float zRotation = 25f;
    float currentTime = 0;
    float delayTime = 0.1f;
    // Activate the multi shoot of the player for 2 seconds
    IEnumerator MultiShooting()
    {
        currentTime = 0f;

        while (currentTime < multiShootingTime)
        {
            Instantiate(multiShootPrefab, transform.position, Quaternion.Euler(0, 0, -zRotation));
            Instantiate(multiShootPrefab, transform.position, Quaternion.identity);
            Instantiate(multiShootPrefab, transform.position, Quaternion.Euler(0, 0, zRotation));

            yield return new WaitForSeconds(delayTime);

            currentTime += delayTime;
        }

        multiShoots = false;
    }
}
