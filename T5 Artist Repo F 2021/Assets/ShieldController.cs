using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    Renderer renderer;
    Camera mainCam;
    [SerializeField] AnimationCurve displacementCurve;
    [SerializeField] float displacementMagnitude;
    [SerializeField] float lerpSpeed;

    [SerializeField] Animator animator;

    bool shieldOn;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        mainCam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; 
            if (Physics.Raycast(ray, out hit))
            {
                ShieldHit(hit.point);
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            //EnableDisableShield
            AnimateShieldOnOff(shieldOn);
        }
    }

    //shield should accept a hit position in world space vector3 and do zoom/displacement based on that
    public void ShieldHit(Vector3 hitPos)
    {
        renderer.material.SetVector("_HitPosition", hitPos);
        StopCoroutine(HitDisplacementCoroutine());
        StartCoroutine(HitDisplacementCoroutine());
       
    }

    public void AnimateShieldOnOff(bool val)
    {
        //grab animator bool ref & toggle shield on/off 
       
        animator.SetBool("ShieldEnable", val);
        shieldOn = !shieldOn;
        Debug.Log("shield: " + shieldOn);
    }

    IEnumerator HitDisplacementCoroutine()
    {
        float lerp = 0;
        while (lerp < 1)
        {
            renderer.material.SetFloat("_DisplacementStrength", displacementCurve.Evaluate(lerp) * displacementMagnitude);
            lerp += Time.deltaTime * lerpSpeed;
            yield return null;
        }
        renderer.material.SetFloat("_DisplacementStrength", 0);

    }
}
