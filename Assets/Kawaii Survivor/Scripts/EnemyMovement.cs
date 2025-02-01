using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header ("Elements")]
    private Player player;

    [Header("Spawn Sequence")]
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private SpriteRenderer spawnIndicator;
    private bool hasSpawned;

    [Header("Effects")]
    [SerializeField]
    private ParticleSystem dieParticles;

    [Header("Settings")]
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float playerDectectionRadius;

    [Header("DEBUG")]
    [SerializeField]
    private bool gizmos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<Player>();
        if (player == null) 
        {
            Debug.LogWarning("No player found, Auto-destroying...");
            Destroy(gameObject);
        }
        // Hide the renderer
        spriteRenderer.enabled = false;
        // Show the spawn indicator
        spawnIndicator.enabled = true;
        // Scale up & down the spawn indicator
        Vector3 targetScale = spawnIndicator.transform.localScale * 1.2f;
        LeanTween.scale(spawnIndicator.gameObject, targetScale, .3f)
            .setLoopPingPong(4)
            .setOnComplete(SpawnSequenceCompleted);


        //Prevent Following & Attacking during the spawn sequencd
        
    }
    // Update is called once per frame
    void Update()
    {
        if (!hasSpawned) return;
        FollowPlayer();
        TryAttack();
    }

    private void SpawnSequenceCompleted() 
    {
        // Show the enemy after the scale animation
        spriteRenderer.enabled = true;
        // Hide the  spawn indicator
        spawnIndicator.enabled = false;
        hasSpawned = true;
    }

    private void FollowPlayer() 
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;

        Vector2 targetPosition = (Vector2)transform.position + direction * moveSpeed * Time.deltaTime;

        transform.position = targetPosition;
    }

    private void TryAttack()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= playerDectectionRadius)
        {
            PassAway();
        }
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
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerDectectionRadius);
    }
}
