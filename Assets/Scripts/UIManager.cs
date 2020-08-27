using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Image _LivesImg;
    [SerializeField]
    private GameObject _GameOverText;
    [SerializeField]
    private Text _restartText;
    [SerializeField]
    private Sprite[] _shieldSprites;
    [SerializeField]
    private Image _shieldImg;

    private GameManager _gameManager;

    void Start()
    {
        _scoreText.text = "Score: " + 0;
        _GameOverText.SetActive(false);
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore;
    }

    public void UpdateLives(int currentLives)
    {
        _LivesImg.sprite = _liveSprites[currentLives];
        if (currentLives <= 0)
            GameOverSequence();
    }

    public void UpdateShield(int shieldStrength)
    {

        if (shieldStrength > 0)
        {
            _shieldImg.gameObject.SetActive(true);
            _shieldImg.sprite = _shieldSprites[shieldStrength - 1];
        }
        else
            _shieldImg.gameObject.SetActive(false);
    }

    void GameOverSequence()
    {
        _restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
        _gameManager.GameOver();
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            _GameOverText.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _GameOverText.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
