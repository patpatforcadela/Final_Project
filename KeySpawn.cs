using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawn : MonoBehaviour {

    public GameObject key;
    private float xPos, zPos;
    public int keyCount = 0;
    public GameObject myObj;
	// Use this for initialization
	void Start () {
        StartCoroutine(KeyDrop());
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    IEnumerator KeyDrop()
    {
        while (keyCount != 3)
        {
            xPos = Random.Range(-77, 15);
            zPos = Random.Range(-35, 60);
            Instantiate(key, new Vector3(xPos, 4, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.001f);
            keyCount += 1;
        }
    }
    public void keyDeduct()
    {
        keyCount -= 1;
        if(keyCount == 0)
        {
            myObj.GetComponent<DoorController>().hasKey();
        }
    }

}
