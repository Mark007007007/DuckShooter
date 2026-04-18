using System.Linq;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _enemiesText;
    private int _aliveEnemyCount;
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score;
    [SerializeField] private TextMeshProUGUI _timeRemainingText;
    private float _timeRemaining;
    [SerializeField] private TextMeshProUGUI _ammoText;
    [SerializeField] private TextMeshProUGUI _wonText;
    [SerializeField] private TextMeshProUGUI _loseText;
    [SerializeField] private TextMeshProUGUI _warningText;
    private int _ammoCount;
    private int _minute;
    private int _second;
    private GameManager _gameManager;
    private int _escapedEnemiesCount;
    void Start()
    {
        InitializingVariables();
        InitializingTextValues();
        AssigningVariables();
    }

    private void AssigningVariables()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void InitializingVariables()
    {
        _aliveEnemyCount = 30;
        _score = 0;
        _timeRemaining = 201;
        _ammoCount = 50;
    }

    private void InitializingTextValues()
    {
        _enemiesText.text = "  Enemies " + _aliveEnemyCount;
        _scoreText.text = "Score\n     " + _score;
        _ammoText.text = "Ammo " + _ammoCount;
    }

    void Update()
    {
        UpdateTimeRemainingText();
        if (_score / 50 >= 25 && _gameManager.GetGoneEnemies() == 30)
        {
            ShowWonText();
        }
        else if (_escapedEnemiesCount > 5)
        {
            ShowLoseText();
        }
    }

    public void UpdateEnemiesText()
    {
        _aliveEnemyCount --;
        _enemiesText.text = "  Enemies " + _aliveEnemyCount;
    }

    public void UpdateScoreText()
    {
        _score += 50;
        _scoreText.text = "Score\n     " + _score;
    }

    private void UpdateTimeRemainingText()
    {
        _timeRemaining -= Time.deltaTime;
        
        _minute = (int)(_timeRemaining / 60);
        _second = (int)(_timeRemaining % 60);
        _timeRemainingText.text = $"{_minute:D2}:{_second:D2}";
    }

    public void UpdateAmmoText()
    {
        _ammoCount --;
        _ammoText.text = "Ammo " + _ammoCount;
    }

    private void ShowWonText()
    {
        _wonText.gameObject.SetActive(true);
    }
    private void ShowLoseText()
    {
        _loseText.gameObject.SetActive(true);
    }
    public void AddToEscapedEnemiesCount()
    {
        _escapedEnemiesCount ++;
        ShowWarningText();
    }
    private void ShowWarningText()
    {
        _warningText.text = _escapedEnemiesCount + " Enemies Escaped";
        if (_escapedEnemiesCount == 1) _warningText.text = "An enemy escaped";
        _warningText.gameObject.SetActive(true);
    }
}
