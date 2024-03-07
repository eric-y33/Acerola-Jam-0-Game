using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{

    public GameObject enemy;
    private int xPos;
    private int zPos;
    private int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 10)
        {
            xPos = Random.Range(35, 45) * RandomSign();
            zPos = Random.Range(-40, 40);
            Instantiate(enemy, new Vector3(xPos, 1.6f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemy.SetActive(true);
            enemyCount += 1;
        }
    }

    int RandomSign() {
    if (Random.Range(0, 2) == 0) {
        return -1;
    }
        return 1;
    }
}
