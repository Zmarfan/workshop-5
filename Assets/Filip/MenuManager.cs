using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _soundVolumeSlider;
    [SerializeField] private AudioMixer _audioMixer;

    private void Awake()
    {
        _masterVolumeSlider.onValueChanged.AddListener(value => ChangeMixerMasterVolume(value, "MasterVolume"));
        _musicVolumeSlider.onValueChanged.AddListener(value => ChangeMixerMasterVolume(value, "MusicVolume"));
        _soundVolumeSlider.onValueChanged.AddListener(value => ChangeMixerMasterVolume(value, "SoundVolume"));
    }

    public void StartGame() {
        SceneManager.LoadScene("game");
    }
    
    public void QuitGame() {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ChangeMixerMasterVolume(float value, string name)
    {
        _audioMixer.SetFloat(name, MathF.Log10(value) * 20);
    }
}
