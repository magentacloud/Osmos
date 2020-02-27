using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorizePlayer : MonoBehaviour
{
    private GameObject _gameSettings;
    private Settings _settings;
    void Start()
    {
        _gameSettings = GameObject.Find("GameSettings");
        _settings = _gameSettings.GetComponent<Settings>();
        this.GetComponent<SpriteRenderer>().material.color = new Color(_settings._data._colors._user._color[0] / 255,
            _settings._data._colors._user._color[1] / 255, _settings._data._colors._user._color[2] / 255);
    }

}

