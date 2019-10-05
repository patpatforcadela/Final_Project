using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemy;
    public int xPos;
    public int zPos;
    public int enemyCount;
	// Use this for initialization
	void Start () {
        StartCoroutine(EnemyDrop());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator EnemyDrop()
    {
        while(enemyCount < 20)
        {
            xPos = Random.Range(-77, 15);
            zPos = Random.Range(-35, 60);
            Instantiate(enemy, new Vector3(xPos, 4, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}
