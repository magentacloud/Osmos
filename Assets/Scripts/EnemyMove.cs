using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    void Update()
    {
        Vector2 force = new Vector2(Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f));
        this.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
    }
}
