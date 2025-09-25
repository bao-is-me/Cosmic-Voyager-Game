using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject enemyPrefab;
    public float minInstantateValue;
    public float maxInstantateValue;
    public float enemyDestroyTime = 10f;

    [Header("Particle Effects")]
    public GameObject explosion;
    public GameObject muzzleFlash;

    [Header("Panels")]
    public GameObject StartMenu;
    public GameObject PauseMenu;
    public GameObject GameOverMenu;
    private bool isGameOver = false;

    [Header("Score System")]
    public int score = 0;
    public TMP_Text scoreText;
    public TMP_Text finalScoreText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartMenu.SetActive(true);
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        scoreText.gameObject.SetActive(false);
        finalScoreText.gameObject.SetActive(false);


        Time.timeScale = 0f;
        InvokeRepeating("InstantiateEnemy", 1f, 2f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame(true);
        }
    }

    void InstantiateEnemy()
    {
        if (isGameOver) return;
        Vector3 enemyPos = new Vector3(Random.Range(minInstantateValue, maxInstantateValue), 6f);
        GameObject enemy = Instantiate(enemyPrefab,enemyPos, Quaternion.Euler(0f, 0f, 180f));
        Destroy(enemy, enemyDestroyTime);
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;
        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }

    public void StartGameButton()
    {
        StartMenu.SetActive(false);
        scoreText.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }

    public void PauseGame(bool isPaused)
    {
        if (isPaused == true)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
        } 
        else
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        GameOverMenu.SetActive(true);
        scoreText.gameObject.SetActive(false);
        finalScoreText.gameObject.SetActive(true);


        if (finalScoreText != null)
        {
            finalScoreText.text = "Final Score: " + score.ToString();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
