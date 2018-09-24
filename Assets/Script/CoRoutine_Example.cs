using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoRoutine_Example : MonoBehaviour {

    public Transform Cube;
    public Renderer CubeRenderer;

    //how long the fade takes, in seconds
    public float duration = 2f;

    // Use this for initialization
    void Start () {
        StartCoroutine(FadeColor(Color.black));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Make the cube do things in a CoRoutine
    IEnumerator TestCoroutine(){
        Cube.Translate(0.5f, 0f, 0f);
        yield return new WaitForSeconds(1f);
        Cube.Translate(-0.5f, 0f, 0f);
        yield return new WaitForSeconds(1f);
        StartCoroutine(TestCoroutine());
    }

    IEnumerator FadeColor(Color TargetColor){
        //starting with this colour
        Color StartColor = Color.magenta;

        float t = 0;
        while(t < 1f){

            //change the colour
            CubeRenderer.material.color = Color.Lerp(StartColor, TargetColor, t);

            //increase the increment
            t += Time.deltaTime / duration;

            //tell the script to wait for next frame
            yield return null;
        }
        //Color Example = Color.Lerp();
        yield break;
    }
}
