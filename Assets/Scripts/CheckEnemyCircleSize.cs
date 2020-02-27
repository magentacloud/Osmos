using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemyCircleSize : MonoBehaviour
{
    GameObject _checkIsGameEnded;

    void Start()
    {
        _checkIsGameEnded = GameObject.Find("PlayerCircle");
    }
    void Update()
    {
        if (_checkIsGameEnded != null)
        {
            if (this.transform.localScale.x > _checkIsGameEnded.GetComponent<CheckIsGameEnded>()._biggestEnemySize)
            {
                _checkIsGameEnded.GetComponent<CheckIsGameEnded>()._biggestEnemySize = this.transform.localScale.x;
            }
        }
            
    }
}
