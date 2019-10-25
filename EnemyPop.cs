using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPop : MonoBehaviour {
    public GameObject obj;
    public ParticleSystem pop;
    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {

	}
    public void Dead()
    {
        obj.SetActive(false);
        Invoke("Respawn", 3f);
    }
    public void Respawn()
    {
        pop.Play();
        obj.SetActive(true);
    }

}
