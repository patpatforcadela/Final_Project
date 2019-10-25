using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject girlScout, warZombie, clown;
    private int xPos, zPos, rand, lastNum;
    private float rotation;
    public int enemyCount;
	// Use this for initialization
	void Start () {
        enemyCount = 0;
        StartCoroutine(EnemyDrop());
    }
	
	// Update is called once per frame
	void Update () {

	}

    IEnumerator EnemyDrop()
    {
        while(enemyCount < 30)
        {
            rand = Random.Range(1, 4);
            while(rand == lastNum)
            {
                lastNum = rand;
            }
            xPos = Random.Range(-77, 15);
            zPos = Random.Range(-35, 60);
            rotation = Random.Range(0, 300);
            switch(rand)
            {
                case 1:
                    Instantiate(girlScout, new Vector3(xPos, 4, zPos), Quaternion.Euler(0, rotation, 0));
                    break;
                case 2:
                    Instantiate(warZombie, new Vector3(xPos, 4, zPos), Quaternion.Euler(0, rotation, 0));
                    break;
                case 3:
                    Instantiate(clown, new Vector3(xPos, 4, zPos), Quaternion.Euler(0, rotation, 0));
                    break;
            }
            yield return new WaitForSeconds(0.001f);
            enemyCount = enemyCount + 1;
        }   
    }

    public void enemyDeduct()
    {
        enemyCount -= 1;
    }
}
