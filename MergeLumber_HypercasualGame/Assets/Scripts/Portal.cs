using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform target;
    public Transform map;
    private float xDistance = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        xDistance = transform.position.x - target.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        map.position = new Vector3(map.position.x + xDistance, map.position.y, map.position.z);
        // target.position = new Vector3(col.transform.position.x, target.position.y, target.position.z);
        // col.transform.position = new Vector3(target.position.x, col.transform.position.y, col.transform.position.z);
    }
}
