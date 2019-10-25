using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grannySpawn : MonoBehaviour {

    private int xPos;
    public GameObject granny;
    public int enemyCount;
    // Use this for initialization
    void Start () {
        enemyCount = 0;
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 30)
        {
            xPos = Random.Range(495, 505);
            Instantiate(granny, new Vector3(xPos, 4, 504), Quaternion.identity);
            yield return new WaitForSeconds(3f);
            enemyCount = enemyCount + 1;
        }
    }
}
