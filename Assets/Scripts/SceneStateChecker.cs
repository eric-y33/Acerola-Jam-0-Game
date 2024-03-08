using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class SceneStateChecker : MonoBehaviour
{

    public ProgressBar extractionProgress;
    public ProgressBar health;
    public SceneChanger sceneChanger;
    public PostProcessVolume volume;
    private Vignette vignette;
    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings<Vignette>(out vignette); 
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
        
        vignette.smoothness.value = 0.05f;
    }
}
