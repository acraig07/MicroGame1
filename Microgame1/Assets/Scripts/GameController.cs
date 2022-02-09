using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    int _leftPlayerScore, _rightPlayerScore;
    public int _maxScore = 3;

    public Text _scoreText;

    public GameObject _gameOverUI;
    bool _gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameOver)
            if (Input.anyKeyDown)
                Restart();
    }

    public void Score(bool leftPlayerGetScore)
    {
        if (leftPlayerGetScore)
            _leftPlayerScore++;
        else
            _rightPlayerScore++;

        if (_leftPlayerScore >= _maxScore)
        {
            _scoreText.text = "Left Player Wins!";
            GameOver();
        }
        else if (_rightPlayerScore >= _maxScore)
        {
            _scoreText.text = "Right Player Wins!";
            GameOver();
        }
        else
            _scoreText.text = _leftPlayerScore + " : " + _rightPlayerScore;
    }

    void GameOver()
    {
        _gameOver = true;
        _gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
}
