using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int m_maxSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Move(Vector2 vector2)
    {
        GetComponentInParent<Rigidbody2D>().velocity = vector2 * m_maxSpeed;    
    }
}
