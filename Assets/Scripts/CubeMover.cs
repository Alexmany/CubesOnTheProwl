using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    public int speed;
    public int distance;   
    
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);

        if (transform.position.z > distance)
            Destroy(gameObject);
    }
}
