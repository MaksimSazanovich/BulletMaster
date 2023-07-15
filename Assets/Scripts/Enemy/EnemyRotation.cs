using TMPro;
using UnityEngine;
using Zenject;

public class EnemyRotation : MonoBehaviour
{
    private Transform playerPosition;

    public bool IsFasingRight { get => isFasingRight; }
    private bool isFasingRight;

    private SpriteRenderer spriteRenderer;

    [Inject]
    private void Init(PlayerHealth player)
    {
        playerPosition = player.transform;
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        isFasingRight = true;
    }

    private void FixedUpdate()
    {
        if (playerPosition.position.x >= transform.position.x)
            spriteRenderer.flipX = false;
        else spriteRenderer.flipX = true;
    }
}