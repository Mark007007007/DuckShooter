using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] _backgroundAudios;
    private AudioSource _bgAudioSource; // bg = background
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private AudioClip[] _deathSounds;
    private int _poolSize = 3;
    private int _poolforDeathSoundsSize = 3;
    private List<AudioSource> _pool = new List<AudioSource>();
    private List<AudioSource> _poolForDeathSounds = new List<AudioSource>();
    [SerializeField] private AudioSource _audioSourcePrefab;
    private int _currentAudioIndex;
    private GameManager _gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _bgAudioSource = GetComponent<AudioSource>();
        _bgAudioSource.clip = _backgroundAudios[0];
        _bgAudioSource.Play();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        for (var i = 0; i < _poolSize; i++)
        {
            AudioSource source = Instantiate(_audioSourcePrefab, transform);
            source.playOnAwake = false;
            source.clip = _audioClips[i];
            _pool.Add(source);
        }
        for (var i = 0; i < _poolforDeathSoundsSize; i++)
        {
            AudioSource source = Instantiate(_audioSourcePrefab, transform);
            source.playOnAwake = false;
            source.clip = _deathSounds[i];
            _poolForDeathSounds.Add(source);
        }

    }

    // Update is called once per frame
    void Update()
    {
        UpdateBackgroundMusic();
    }

    public void ChangeBackGroundAudio(int index)
    {
        _bgAudioSource.Stop();
        _bgAudioSource.clip = _backgroundAudios[index];
        _bgAudioSource.Play();
    }

    private void UpdateBackgroundMusic()
    {
        if (_gameManager.GetGoneEnemies() == 10 && _currentAudioIndex == 0)
        {
            ChangeBackGroundAudio(1);
            _currentAudioIndex ++;
        }
        else if (_gameManager.GetGoneEnemies() == 20 && _currentAudioIndex == 1)
        {
            ChangeBackGroundAudio(2);
            _currentAudioIndex ++;
        }
    }

    public void PlayShootSound()
    {
        _pool[0].Play();
    }

    public void PlayAIDeathSound(int typeId)
    {
        _poolForDeathSounds[typeId].Play();
    }

    public void PlayShotBarrierSound()
    {
        _pool[1].Play();
    }

    public void PlayAICompletedTrackSound()
    {
        _pool[2].Play();
    }
}
