using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
    {
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Image _livesImage;
    [SerializeField]
    private Sprite[] _liveSprites;

    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartText;

    private GameManager _gameManager;

    void Start()
        {
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        _scoreText.text = "Score :" + 0;
        }
    
    public void UpdateScore(int playerScore)
        {
        _scoreText.text = "Score :" + playerScore.ToString();
        }

    public void UpdateLives(int currentLives)
        {
        // acess display image sprite and give it a new one based on the current lives index
        _livesImage.sprite = _liveSprites[currentLives];

        if (currentLives == 0)
            {
            GameOverSequence();
            }

        void GameOverSequence()
            {
            _gameManager.GameOver();
            _gameOverText.gameObject.SetActive(true);
            _restartText.gameObject.SetActive(true);
            StartCoroutine(GameOverFlicker());
            if (_gameManager == null)
                {
                Debug.LogError("Game Manager is NULL");
                }

            }
            }

    IEnumerator GameOverFlicker()
        {
        while (true)
            {
            _gameOverText.text = "Game over!";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
            }
        }
    }

    
