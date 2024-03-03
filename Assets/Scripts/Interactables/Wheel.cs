using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : Interactable
{
    private bool isTurning;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact() 
    {
        Debug.Log("Interacted with " + gameObject.name);
        float startTime = 0;
        isTurning = !isTurning;
        GetComponent<Animator>().SetBool("IsTurning", isTurning);
        while (startTime < 0.5) {
            startTime += Time.fixedDeltaTime;
            // wait till animation is done (there has to be a better way to do this)
        }
        isTurning = !isTurning;
    }
}
