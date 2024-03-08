using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateChecker : MonoBehaviour
{

    public ProgressBar extractionProgress;
    public ProgressBar health;
    public SceneChanger sceneChanger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health.current <= 0) 
        {
            sceneChanger.FadeToLevel(SceneManager.GetActiveScene().buildIndex);
        }

        if (extractionProgress.current >= extractionProgress.maximum)
        {
            // Do other ending stuff before fading to level
            sceneChanger.FadeToNextLevel();
        }
    }
}
