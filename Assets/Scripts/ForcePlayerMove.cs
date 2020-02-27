using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePlayerMove : MonoBehaviour
{
    GameObject _field;
    FieldClickListener _fieldClickListener;
    private bool IsNotEmptyVector(Vector2 vec)
    {
        if (vec.x == 0 && vec.y == 0)
        {
            return false;
        }
        return true;
    }
    void Start()
    {
        _field = GameObject.Find("Field");
    }

    void Update()
    {
        _fieldClickListener = _field.GetComponent<FieldClickListener>();
        if (IsNotEmptyVector(_fieldClickListener._clickTarget))
        {
            float deltaX = _fieldClickListener._clickTarget.x - this.transform.position.x;
            float deltaY = _fieldClickListener._clickTarget.y - this.transform.position.y;
            float dragTime = (float)_fieldClickListener._dragTime.TotalMilliseconds;
            Vector2 force = new Vector2(-deltaX * dragTime / 500, -deltaY * dragTime / 500);
            this.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
            _fieldClickListener._clickTarget.x = 0;
            _fieldClickListener._clickTarget.y = 0;
        }
            
    }
}
