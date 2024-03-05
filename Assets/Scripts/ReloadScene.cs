using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public SceneChanger sceneChanger;
    void OnTriggerEnter(Collider col) {
        if (col.CompareTag("Player"))
        {
            sceneChanger.FadeToLevel(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
