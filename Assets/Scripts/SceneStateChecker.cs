using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class SceneStateChecker : MonoBehaviour
{

    public ProgressBar extractionProgress;
    public ProgressBar health;
    public SceneChanger sceneChanger;
    public GameObject blast;
    public PostProcessVolume volume;
    public AudioSource music;
    private Vignette vignette;
    private ChromaticAberration chromatic;
    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings<Vignette>(out vignette); 
        volume.profile.TryGetSettings<ChromaticAberration>(out chromatic); 
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
            StartCoroutine(ending());
            
        }
        
        // Make vignette smoother and chromatic aberration more intense as health decreases
        float healthPercent = Math.Abs((float) health.current/health.maximum);
        float v = vignette.smoothness.value = 0.05f + (1f-healthPercent)*(0.320f-0.05f);
        float c = chromatic.intensity.value = (1f-healthPercent)*(0.4f);
        // Debug.Log(healthPercent);
        // Debug.Log(v);
        // Debug.Log(c);


    }

    IEnumerator ending()
    {
        blast.SetActive(true);
        extractionProgress.current = 0;
        yield return new WaitForSeconds(8);
        sceneChanger.FadeToNextLevel();
    }
}
