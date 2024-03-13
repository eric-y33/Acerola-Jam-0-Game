using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    private int xPos;
    private int zPos;
    public ProgressBar progress;

    private bool firstWave;
    private bool secondWave;
    private bool thirdWave;
    private bool fourthWave;
    private bool fifthWave;

    private string[] prompts = new string[]{"[DESTROY]", "[FORGET]", "[ABANDON]"};

    // Update is called once per frame
    void Update()
    {
        // Be sure to update all this if the progress bar maximum changes
        // There is probably a much better way to handle this but this works for now
        if (firstWave == false && progress.current == 50)
        {
            StartCoroutine(EnemyDrop(5, 0, enemy1));
            firstWave = true;
        }

        if (secondWave == false && progress.current == 100)
        {
            StartCoroutine(EnemyDrop(8, 0, enemy1));
            secondWave = true;
        }

        if (thirdWave == false && progress.current == 150)
        {
            StartCoroutine(EnemyDrop(12, 1, enemy2));
            thirdWave = true;
        }

        if (fourthWave == false && progress.current == 200)
        {
            StartCoroutine(EnemyDrop(4, 1, enemy2));
            StartCoroutine(EnemyDrop(10, 2, enemy3));
            fourthWave = true;
        }

        if (fifthWave == false && progress.current == 250)
        {
            StartCoroutine(EnemyDrop(6, 0, enemy1));
            StartCoroutine(EnemyDrop(6, 1, enemy2));
            StartCoroutine(EnemyDrop(6, 2, enemy3));
            fifthWave = true;
        }
    }

    IEnumerator EnemyDrop(int numEnemies, int enemyIndex, GameObject enemy)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            xPos = Random.Range(35, 45) * RandomSign();
            zPos = Random.Range(-40, 40);
            GameObject clone = Instantiate(enemy, new Vector3(xPos, 0f, zPos), Quaternion.identity);
            clone.SetActive(true);

            yield return new WaitForSeconds(1f);
            // This is not a great way of changing the prompt message
            EnemyInteract interact = clone.GetComponent<EnemyInteract>();
            interact.promptMessage = prompts[enemyIndex];

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
