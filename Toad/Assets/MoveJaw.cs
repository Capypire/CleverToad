using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class MoveJaw : MonoBehaviour
{
    public float speed = 1.0f;
  
    public Transform target; 
        // Start is called before the first frame update
    void Start()
    {
        Move();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {
        // The step size is equal to speed times frame time.
        var step = speed * Time.deltaTime;

        // Rotate our transform a step closer to the target's.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);
        UnityEngine.Debug.Log("rotated");
    }
}
