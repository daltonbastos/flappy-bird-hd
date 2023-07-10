using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Background : MonoBehaviour
{
    [SerializeField] private float loopSpeed = 2f;
    [SerializeField] private float width = 6f;

    private Vector2 startSize;

    private SpriteRenderer m_SpriteRenderer;

    private void Awake() => m_SpriteRenderer = GetComponent<SpriteRenderer>();

    private void Start() => startSize = m_SpriteRenderer.size;

    private void Update()
    {
        m_SpriteRenderer.size = new Vector2(m_SpriteRenderer.size.x + loopSpeed * Time.deltaTime, m_SpriteRenderer.size.y);

        if (m_SpriteRenderer.size.x > width)
            m_SpriteRenderer.size = startSize;
    }
}
