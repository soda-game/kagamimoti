using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {
    int pos;


    // Use this for initialization
    void Start() {
        pos = Random.Range(0, 5);
        switch (pos) {
            case 0:
            transform.position=new Vector3(-7.5f, 6.17f, 0f);
            break;
            case 1:
            transform.position = new Vector3(-3.8f, 6.17f, 0f);
            break;
            case 2:
            transform.position = new Vector3(0f, 6.17f, 0f);
            break;
            case 3:
            transform.position = new Vector3(3.8f, 6.17f, 0f);
            break;
            case 4:
            transform.position = new Vector3(7.5f, 6.17f, 0f);
            break;
            default:
            break;
        }
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(0, -0.1f, 0);
        Vector3 tmp = this.gameObject.transform.position;
        if (tmp.y <= -6.0f) {
            Destroy(gameObject);
        }
    }
}