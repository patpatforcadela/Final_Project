using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeIn : MonoBehaviour {

    public Image src;
    // Use this for initialization
    void Start () {
        src.canvasRenderer.SetAlpha(1.0f);
        StartCoroutine(fadein());
    }
	
    IEnumerator fadein()
    {
        src.CrossFadeAlpha(0, 1.5f, false);
        yield return new WaitForSeconds(1.5f);
        Destroy(src);
    }
}
