using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    Camera _cam;

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.forward = (_cam.transform.position - this.transform.position);
        
     //   Debug.Log("transform pos is: " + this.transform.forward);
    }
}
