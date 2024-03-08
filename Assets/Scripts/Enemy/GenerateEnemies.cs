using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{

    public GameObject enemy;
    private int xPos;
    private int zPos;
    public ProgressBar progress;

    private bool firstWave;
    private bool secondWave;
    private bool thirdWave;
    private bool fourthWave;
    private bool fifthWave;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        // Be sure to update all this if the progress bar maximum changes
        // There is probably a much better way to handle this but this works for now
        if (firstWave == false && progress.current == 50)
        {
            StartCoroutine(EnemyDrop(5));
            firstWave = true;
        }

        if (secondWave == false && progress.current == 100)
        {
            StartCoroutine(EnemyDrop(8));
            secondWave = true;
        }

        if (thirdWave == false && progress.current == 150)
        {
            StartCoroutine(EnemyDrop(12));
            thirdWave = true;
        }

        if (fourthWave == false && progress.current == 200)
        {
            StartCoroutine(EnemyDrop(15));
            fourthWave = true;
        }

        if (fifthWave == false && progress.current == 250)
        {
            StartCoroutine(EnemyDrop(18));
            fifthWave = true;
        }
    }

    IEnumerator EnemyDrop(int enemies)
    {
        for (int i = 0; i < enemies; i++)
        {
            xPos = Random.Range(35, 45) * RandomSign();
            zPos = Random.Range(-40, 40);
            GameObject clone = Instantiate(enemy, new Vector3(xPos, 1.6f, zPos), Quaternion.identity);
            clone.SetActive(true);
            yield return new WaitForSeconds(1f);
            if (progress.current == progress.maximum) {
                break;
            }
        }
    }

    int RandomSign() {
    if (Random.Range(0, 2) == 0) {
        return -1;
    }
        return 1;
    }
}
