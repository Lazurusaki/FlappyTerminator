
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private SceneCleaner _sceneCleaner;
    [SerializeField] private EnemyFabric _enemyFabric;



    private void OnEnable()
    {
        if (_startScreen)
        {
            _startScreen.PlayButtonClicked += OnPlayButtonClick;
        }

        if (_endGameScreen)
        {
            _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
        }

        if (_bird)
        {
            _bird.GameOver += OnGameOver;
        }   
    }

    private void OnDisable()
    {
        if (_startScreen)
        {
            _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        }

        if (_endGameScreen)
        {
            _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
        }

        if (_bird)
        {
            _bird.GameOver -= OnGameOver;
        }
    }

    private void Start()
    {
        if (_startScreen)
        {
            _bird.gameObject.SetActive(false);
            _enemyFabric.enabled = false;
            Time.timeScale = 0;
            _startScreen.Open();
        }
    }

    private void OnGameOver()
    {   
        if (_endGameScreen)
        {
            _sceneCleaner.ClearScene();
            _bird.gameObject.SetActive(false);
            Time.timeScale = 0;
            _endGameScreen.Open();
        }
    }

    private void OnRestartButtonClick()
    {
        if (_endGameScreen)
        {
            _endGameScreen.Close();
            StartGame();
        }
    }
    private void OnPlayButtonClick()
    {
        if (_startScreen)
        { 
            _startScreen.Close();
            StartGame();
        }
    }

    private void StartGame()
    {
        if (_bird && _sceneCleaner)
        {   
            Time.timeScale = 1;
            _bird.Reset();
            _bird.gameObject.SetActive(true);
            _enemyFabric.enabled = true;
        }
    }
}
