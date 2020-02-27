using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorizeEnemies : MonoBehaviour
{
    private GameObject _playerCircle;
    private GameObject _settings;
    private float _playerSize;
    private float _enemySize;
    private int[] _enemyColor1;
    private int[] _enemyColor2;
    void Start()
    {   
        _settings = GameObject.Find("GameSettings");
        _enemyColor1 = _settings.GetComponent<Settings>()._data._colors._enemy._color1;
        _enemyColor2 = _settings.GetComponent<Settings>()._data._colors._enemy._color2;
        _playerCircle = GameObject.Find("PlayerCircle");
        
    }
    void Update()
    {
        if (_playerCircle != null)
        {
            _playerSize = _playerCircle.transform.localScale.x;
        }   
        _enemySize = gameObject.transform.localScale.x;
        gameObject.GetComponent<SpriteRenderer>().material.color = CalculateColor(_playerSize, _enemySize, _enemyColor1, _enemyColor2);

    }
    Color CalculateColor(float playerSize, float enemySize, int[] enemyColor1, int[] enemyColor2)
    {
        Color enemyColor;
        float ratio = enemySize / playerSize;
        if(ratio > 3)
        {
            enemyColor = new Color(enemyColor2[0] / 255, enemyColor2[1] / 255, enemyColor2[2] / 255, 1.0f);
        }
        else if (ratio < 1f)
        {
            enemyColor = new Color(enemyColor1[0] / 255, enemyColor1[1] / 255, enemyColor1[2] / 255, 1.0f);
        }
        else
        {
            ratio = (ratio - 1f) / 2f;
            enemyColor = new Color(
                (enemyColor2[0] * (ratio) + enemyColor1[0] * (1 - ratio)) / 2 / 255,
                (enemyColor2[1] * (ratio) + enemyColor1[1] * (1 - ratio)) / 2 / 255,
                (enemyColor2[2] * (ratio) + enemyColor1[2] * (1 - ratio)) / 2 / 255,
                1.0f);
        }
        return enemyColor;
    }
}

