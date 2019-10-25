using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    private float xPos, zPos;
    public GameObject key;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Metal"))
        {
            xPos = Random.Range(-77, 15);
            zPos = Random.Range(-35, 60);
            Instantiate(key, new Vector3(xPos, 4, zPos), Quaternion.identity);
            Debug.Log("Overlapped");
            Destroy(gameObject);
        } else if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Key was picked up!");
            Destroy(gameObject);
        }
    }
}
