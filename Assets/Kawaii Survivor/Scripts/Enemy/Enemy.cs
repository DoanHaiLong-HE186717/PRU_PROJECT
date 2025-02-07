using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(EnemyMovement))]
public class Enemy : MonoBehaviour
{
    [Header("Components")]
    private EnemyMovement movement;

    [Header("Health")]
    [SerializeField]
    private int maxHealth;
    private int health;
    [SerializeField]
    private TextMeshPro healthText;


    [Header("Elements")]
    [SerializeField]
    private Player player;

    [Header("Spawn Sequence")]
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private SpriteRenderer spawnIndicator;
    [SerializeField]
    private Collider2D collider;


    [Header("Attack")]
    [SerializeField]
    private int damage;
    [SerializeField]
    private float attackFrequency;
    [SerializeField]
    private float playerDectectionRadius;
    private float attackDelay;
    private float attackTimer;
    bool hasSpawned;

    [Header("Actions")]
    public static Action<int, Vector2> onDamageTaken;

    [Header("Effects")]
    [SerializeField]
    private ParticleSystem dieParticles;

    [Header("DEBUG")]
    [SerializeField]
    private bool gizmos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        healthText.text = health.ToString();

        movement = GetComponent<EnemyMovement>();

        player = FindAnyObjectByType<Player>();
        if (player == null)
        {
            Debug.LogWarning("No player found, Auto-destroying...");
            Destroy(gameObject);
        }

        StartSpawnSequence();

        attackDelay = 1f / attackFrequency;
    }

    private void StartSpawnSequence()
    {
        // Hide the renderer
        // Show the spawn indicator
        SetRenderersVisibility(false);

        // Scale up & down the spawn indicator
        Vector3 targetScale = spawnIndicator.transform.localScale * 1.2f;
        LeanTween.scale(spawnIndicator.gameObject, targetScale, .3f)
            .setLoopPingPong(4)
            .setOnComplete(SpawnSequenceCompleted);
    }
    private void SpawnSequenceCompleted()   
    {
        SetRenderersVisibility(true);
        hasSpawned = true;
        collider.enabled = true;
        movement.StorePlayer(player);
    }

    private void SetRenderersVisibility(bool visibility)
    {
        // Show the enemy after the scale animation
        spriteRenderer.enabled = visibility;
        // Hide the  spawn indicator
        spawnIndicator.enabled = !visibility;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTimer >= attackDelay)
            TryAttack();
        else
            Wait();

    }

    private void Wait()
    {
        attackTimer += Time.deltaTime;
    }

    private void TryAttack()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= playerDectectionRadius)
        {
            Attack();
        }
    }

    private void Attack()
    {
        attackTimer = 0;

        player.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        int realDamage = Mathf.Min(damage, health);
        health -= realDamage;

        healthText.text = health.ToString();

        onDamageTaken?.Invoke(damage, transform.position);

        if (health <= 0) PassAway();

    }
    private void PassAway()
    {
        dieParticles.transform.SetParent(null);
        dieParticles.Play();
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        if (!gizmos)
        {
            Debug.Log("No Gizmos");
            return;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, playerDectectionRadius);
    }

}
