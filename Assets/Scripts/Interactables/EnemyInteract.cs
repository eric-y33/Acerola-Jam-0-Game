using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteract : Interactable
{
    public ProgressBar progressBar;

    // Start is called before the first frame update
    void Start()
    {
        // progressBar = GameObject.Find("Health");
        progressBar.decreaseCurrent();
        promptMessage = "Hello";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact() 
    {
        Debug.Log("Interacted with " + gameObject.name);
        progressBar.increaseCurrent();
        // play death animation, GetComponent<Animator>().Play("death") or whatever
        Destroy(gameObject, 0.1f);
    }
}
