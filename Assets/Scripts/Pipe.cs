using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Pipe : MonoBehaviour
{
    [SerializeField] private float speed = .1f;
    [SerializeField] private ParticleSystem scoreParticle;

    private bool scoreCount = false;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!scoreCount)
        {
            scoreCount = true;
            GameMananger.Instance.AddScore();

            if(scoreParticle)
                scoreParticle.Play();
        }
    }
}
