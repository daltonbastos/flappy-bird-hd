using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 4f;
    [SerializeField] private float rotationAmount = 4f;

    [SerializeField] private ParticleSystem jumpParticle;

    private Animator m_Animator;
    private Rigidbody2D m_Rigidbody2D;
    private AudioSource m_AudioSource;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            Jump();
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, m_Rigidbody2D.velocity.y * rotationAmount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.collider.CompareTag("Limit"))
            GameMananger.Instance.GameOver();
    }

    private void Jump()
    {
        //m_Rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        m_Rigidbody2D.velocity = Vector2.up * jumpForce;
        m_AudioSource.Play();
        m_Animator.SetTrigger("Jump");

        if (jumpParticle)
            jumpParticle.Play();
    }
}
