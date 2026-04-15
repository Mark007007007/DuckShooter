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
    private int _ammoCount;
    private int _minute;
    private int _second;
    void Start()
    {
        InitializingVariables();
        InitializingTextValues();
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
}
