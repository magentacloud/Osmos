using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private GameObject _gameField;
    private Settings _settings;
    private int _enemyCount;
    private float[] _enemySizes;
    private float _gameFieldSquare;
    private Vector2 _gameFieldSize;
    public GameObject _enemy;
    void Awake()
    {
        _settings = GameObject.Find("GameSettings").GetComponent<Settings>();
        _enemyCount = _settings._data._enemyCount;
        _gameField = GameObject.Find("Field");
        _gameFieldSize = new Vector2(_gameField.transform.localScale.x, _gameField.transform.localScale.y);
        _gameFieldSquare = _gameFieldSize.x * _gameFieldSize.y;
        _enemySizes = GetEnemySizes(_enemyCount, _gameFieldSquare);
        GenerateEnemies(_enemySizes);
    }
    private float CalculateEnemyDiameter(float enemySquare)
    {
        return 2 * Mathf.Sqrt(enemySquare / Mathf.PI);
    }
    private float[] GetEnemySizes(int enemyCount, float gameFieldSquare)
    {
        float[] enemySizes = new float[enemyCount];
        float totalEnemySquare = gameFieldSquare * 0.1f;
        for(int i = 0; i < enemyCount; i++)
        {
            if(i < 4)
            {
                enemySizes[i] = CalculateEnemyDiameter(totalEnemySquare / 16);
            } else if(i > (enemyCount - 10))
            {
                enemySizes[i] = CalculateEnemyDiameter(totalEnemySquare / 100);
            } else
            {
                enemySizes[i] = CalculateEnemyDiameter(totalEnemySquare * 0.65f / (enemyCount - 14));
            }
        }
        return enemySizes;
    }
    private void GenerateEnemies(float[] enemySizes)
    {
        for(int i = 0; i < _enemyCount; i++)
        {
            Collider2D[] checkResult;
            do
            {
                Vector3 scale = new Vector3(enemySizes[i], enemySizes[i], 1);
                _enemy.transform.localScale = scale;
                Vector3 position = new Vector3(
                    Random.Range(-(_gameFieldSize.x / 2) + enemySizes[i] / 2,
                    _gameFieldSize.x / 2 - enemySizes[i] / 2),
                    Random.Range(-(_gameFieldSize.y / 2) + enemySizes[i] / 2,
                    _gameFieldSize.y / 2 - enemySizes[i] / 2),
                    1);
                _enemy.transform.localPosition = position;
                checkResult = Physics2D.OverlapCircleAll(position, (enemySizes[i] / 2));
                if (checkResult.Length == 1)
                {
                    Instantiate(_enemy);
                }
            }
            while (checkResult.Length != 1);
            
            
            
        }
    }
}
