using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorb : MonoBehaviour
{
    private bool _isAbsorbing = false;
    private Collision2D _other;
    private float _absorbRate = 0.1f;
    public GameObject _button;
    void OnCollisionEnter2D(Collision2D other)
    {   

        if (other.gameObject.CompareTag("Absorvable") || other.gameObject.CompareTag("Player"))
        {
            if (this.transform.localScale.x > other.gameObject.transform.localScale.x)
            {
                _isAbsorbing = true;
                _other = other;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(this._isAbsorbing == true)
        {
            _isAbsorbing = false;
            _other = null;
        }
    }
    void Update()
    {
        if (this._isAbsorbing == true)
        {
            Vector3 size = this.transform.localScale;
            Vector3 otherSize = _other.transform.localScale;
            float square = Mathf.Pow(size.x / 2, 2) * Mathf.PI;
            float otherSquare = Mathf.Pow(otherSize.x / 2, 2) * Mathf.PI;
            otherSquare -= _absorbRate;
            square += _absorbRate;
            float diameter = Mathf.Sqrt(square / Mathf.PI) * 2;
            size.x = diameter;
            size.y = diameter;
            float otherDiameter = Mathf.Sqrt(otherSquare / Mathf.PI) * 2;
            otherSize.x = otherDiameter;
            otherSize.y = otherDiameter;
            if(otherSize.x < 0.5) {
                _isAbsorbing = false;
                if (_other.gameObject.CompareTag("Player"))
                {
                    Time.timeScale = 0;
                    Instantiate(_button);
                }
                else
                {
                    Destroy(_other.gameObject);
                }
            }

            this.transform.localScale = size;
            _other.transform.localScale = otherSize;
        }
    }
}
