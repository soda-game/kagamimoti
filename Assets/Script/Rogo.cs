using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rogo : MonoBehaviour {

    // Use this for initialization
    void Start () {
        Invoke("GoTitle", 4);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void GoTitle() {
        SceneManager.LoadScene("Title");
    }
}
