using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private const int LevelTime = 5;
    [SerializeField] private float _timer;
    [SerializeField] private int _score;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TMP_Text _gameOverScoreText;
    private bool _isGameOver;

    public bool IsGameOver { get { return _isGameOver; } }

    // Start is called before the first frame update
    void Start()
    {
        _timer = LevelTime;
        _score = 0;

        SetTimerText(_timer);
        SetScoreText(_score);
        SetGameOver(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isGameOver)
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
                SetTimerText(_timer);
            }
            else
            {
                SetGameOver(true);
            }
        }
    }

    public void AddScore()
    {
        _score++;
        SetScoreText(_score);
    }

    public void SetTimerText(float timer)
    {
        _timerText.text = _timer.ToString("N1");
    }

    public void SetScoreText(int score)
    {
        _scoreText.text = _score.ToString().PadLeft(3, '0');
    }

    public void SetGameOver(bool isGameOver)
    {
        _isGameOver = isGameOver;
        _gameOverPanel.SetActive(_isGameOver);
        if (_isGameOver)
        {
            _gameOverScoreText.text = "Score: " + _score.ToString().PadLeft(3, '0');
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}