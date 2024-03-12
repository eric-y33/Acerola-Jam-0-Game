using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(closeGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator closeGame()
    {
        yield return new WaitForSeconds(20);
        Application.Quit();
    }
}
