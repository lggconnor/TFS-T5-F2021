using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnifyEffect : MonoBehaviour
{
    Renderer renderer;
    Camera cam;
    Vector3 screenPoint;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        screenPoint = cam.WorldToScreenPoint(this.transform.position);
        screenPoint.x = screenPoint.x / Screen.width;
        screenPoint.y = screenPoint.y / Screen.height;
        renderer.material.SetVector("_ObjScreenPos", screenPoint);
    }
}
