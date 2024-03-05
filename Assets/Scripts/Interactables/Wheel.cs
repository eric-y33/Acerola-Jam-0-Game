using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : Interactable
{
    private bool isTurning;
    public ProgressBar progressBar;

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
        GetComponent<Animator>().Play("Turn");
        progressBar.increaseCurrent();
    }
}
