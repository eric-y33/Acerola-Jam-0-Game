using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyInteract : Interactable
{
    public ProgressBar progressBar;
    public AudioSource voop;
    private string[] prompts = new string[]{"[...]"};

    // Start is called before the first frame update
    void Start()
    {
        // progressBar = GameObject.Find("Health");
        progressBar.decreaseCurrent(3);
        int randomPromptIndex = Random.Range(0,(prompts.Length - 1));
        promptMessage = prompts[randomPromptIndex];
        
    }

    protected override void Interact() 
    {
        Debug.Log("Interacted with " + gameObject.name);
        progressBar.increaseCurrent(2);
        voop.Play();
        Destroy(gameObject, 0.1f);
    }
}
