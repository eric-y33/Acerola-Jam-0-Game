using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : Interactable
{
    private bool isTurning;
    public ProgressBar progressBar;
    public AudioSource turn;
    protected override void Interact() 
    {
        Debug.Log("Interacted with " + gameObject.name);
        GetComponent<Animator>().Play("Turn");
        turn.Play();
        progressBar.increaseCurrent(1);
    }
}
