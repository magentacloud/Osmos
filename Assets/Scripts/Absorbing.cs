using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorbing : MonoBehaviour
{
    public GameObject _button;
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Absorvable") || other.gameObject.CompareTag("Player"))
        {
            if (this.transform.localScale.x > other.gameObject.transform.localScale.x)
            {
                Vector3 size = this.transform.localScale;
                float square = Mathf.Pow(size.x / 2, 2) * Mathf.PI;
                float absorbedSquare = Mathf.Pow(other.gameObject.transform.localScale.x / 2, 2) * Mathf.PI;
                square += absorbedSquare;
                float diameter = Mathf.Sqrt(square / Mathf.PI) * 2;
                size.x = diameter;
                size.y = diameter;
                this.transform.localScale = size;
                if(other.gameObject.CompareTag("Player"))
                {
                    Time.timeScale = 0;
                    Instantiate(_button);
                }
                else
                {
                    Destroy(other.gameObject);
                }
                
            }
        }
    }
}
