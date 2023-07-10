using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;

public class GameMananger : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Animator scoreAnimator;

    [Space]

    [SerializeField] private TMP_Text recordScoreText;

    [Space]

    [SerializeField] private GameObject gameplayScreen;
    [SerializeField] private GameObject gameOverScreen;

    [Header("Audio")]
    [SerializeField] private AudioSource scoreSound;

    private int score;

    public static GameMananger Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        Time.timeScale = 1f;
    }

    private void Start()
    {
        gameplayScreen.SetActive(true);
        gameOverScreen.SetActive(false);

        scoreText.text = score.ToString();
    }

    private void Update()
    {
        
    }

    public void AddScore()
    {
        score++;

        if(scoreSound)
            scoreSound.Play();

        scoreText.text = score.ToString();
        scoreAnimator.SetTrigger("AddScore");
    }

    public void GameOver()
    {
        Time.timeScale = 0f;

        int highScore = 0;

        if(PlayerPrefs.HasKey("RecordScoreData"))
        {
            highScore = PlayerPrefs.GetInt("RecordScoreData");

            if(score > highScore)
                PlayerPrefs.SetInt("RecordScoreData", score);

            recordScoreText.text = highScore.ToString();
        }
        else
        {
            highScore = score;
            PlayerPrefs.SetInt("RecordScoreData", score);
        }

        recordScoreText.text = string.Concat("Record: ", highScore.ToString());

        gameplayScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
