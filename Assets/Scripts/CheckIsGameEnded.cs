using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckIsGameEnded : MonoBehaviour
{
    public float _biggestEnemySize;
    public GameObject _button;
    private bool _isWin = false;
    void Update()
    {
        if(this.transform.localScale.x > _biggestEnemySize && !_isWin)
        {
            Time.timeScale = 0;
            _isWin = true;
            Instantiate(_button);
        }
    }
}
