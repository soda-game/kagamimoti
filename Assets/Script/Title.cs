using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {
    public Text TitleT;
    public GameObject TutT;

    public GameObject TitleB;
    public GameObject TutB;

    AudioSource audioSource;
    public AudioClip ButtonSE;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoTut() {
        audioSource.PlayOneShot(ButtonSE);

        TitleT.text = "";
        TitleB.SetActive(false);

        TutT.SetActive(true);
        TutB.SetActive(true);
    }

    public void GoGame00() {
        audioSource.PlayOneShot(ButtonSE);
        Invoke("GoGame01", 1);
    }
    void GoGame01() { 
        SceneManager.LoadScene("Game");
    }
}
