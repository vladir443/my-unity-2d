using UnityEngine;

public class FollowCamera2D : MonoBehaviour
{
    [SerializeField] private Rigidbody2D targetRb;
    [SerializeField] private float smoothTime = 0.15f;

    private Vector3 velocity;

    private void Start()
    {
        // если забыл проставить в инспекторе Ч попробуем найти по тегу Player
        if (targetRb == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null) targetRb = player.GetComponent<Rigidbody2D>();
        }

        // стандартна€ Z дл€ 2D
        Vector3 p = transform.position;
        transform.position = new Vector3(p.x, p.y, -10f);
    }

    private void LateUpdate()
    {
        if (targetRb == null) return;

        // ¬ј∆Ќќ: берЄм позицию из Rigidbody2D
        Vector2 p2 = targetRb.position;
        Vector3 targetPos = new Vector3(p2.x, p2.y, -10f);

        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPos,
            ref velocity,
            smoothTime
        );
    }
}