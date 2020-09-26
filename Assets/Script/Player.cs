using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    int play;
    float time = 20;
    int score;
    int spornX;
    int lossF;

    public Text scoreT;
    public Text timeT;
    public Text GameT;
    public Text resultT;

    public GameObject Fruit00;
    public GameObject Fruit01;
    public GameObject Fruit02;
    public GameObject Fruit03;

    SpriteRenderer MainSpriteRenderer;
    public Sprite LossSp;
    public Sprite NomalSp;

    public GameObject ita;

    public GameObject gameobject;
    AudioSource audioSource;
    public AudioClip HazimeSE;
    public AudioClip LossSE;
    public AudioClip GetSE;
    public AudioClip RappaSE;
    public AudioClip ButtonSE;

    // Use this for initialization
    void Start() {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(StartCo());
    }


    private IEnumerator StartCo() {
        GameT.text = "よーい";
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(HazimeSE);
        GameT.text = "はじめ！";
        yield return new WaitForSeconds(1.5f);
        gameobject.GetComponent<GameBGM>().ReturnAccess();
        GameT.text = "";
        play = 1;
        StartCoroutine(Sporn());
    }

    // Update is called once per frame
    void Update() {
        Vector3 tmp = this.gameObject.transform.position;

        if (play == 1) {
            time -= Time.deltaTime;
            timeT.text = ((int)time).ToString();
            if (time <= 0) {
                play = 0;
                StartCoroutine(Result());
            }
            scoreT.text = "フルーツ：" + score.ToString();

            //移動
            if ((Input.GetKey(KeyCode.A)) && (lossF == 0)&&(tmp.x>=-7.5)) {
                transform.Translate(-0.16f, 0, 0);
            }
            if ((Input.GetKey(KeyCode.D)) && (lossF == 0)&&(tmp.x<=7.5)) {
                transform.Translate(0.16f, 0, 0);
            }
        }
    }


    private IEnumerator Sporn() {
        while (play == 1) {
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
            spornX = Random.Range(1, 6);

            switch (spornX) {
                case 1:
                Instantiate(Fruit00, new Vector3(0f, 6.17f, 0f), Quaternion.identity);
                break;
                case 2:
                Instantiate(Fruit01, new Vector3(0f, 6.17f, 0f), Quaternion.identity);
                break;
                case 3:
                Instantiate(Fruit02, new Vector3(0f, 6.17f, 0f), Quaternion.identity);
                break;
                case 4:
                Instantiate(Fruit03, new Vector3(0f, 6.17f, 0f), Quaternion.identity);
                break;

                default:
                break;
            }

        }
    }


    void OnTriggerEnter2D(Collider2D other) {
        if (play == 1) {
            if (other.gameObject.tag == "Loss") {
                audioSource.PlayOneShot(LossSE);
                StartCoroutine(LossCo());
                Destroy(other.gameObject);
            } else {
                audioSource.PlayOneShot(GetSE);
                score += 1;
                Destroy(other.gameObject);
            }
        }
    }

    private IEnumerator LossCo() {
        MainSpriteRenderer.sprite = LossSp;
        lossF = 1;
        yield return new WaitForSeconds(1f);
        MainSpriteRenderer.sprite = NomalSp;
        lossF = 0;
    }


    private IEnumerator Result() {
        audioSource.PlayOneShot(HazimeSE);
        GameT.text = "おわり！";
        yield return new WaitForSeconds(3f);
        audioSource.PlayOneShot(RappaSE);
        timeT.text = "";
        scoreT.text = "";
        GameT.text = "";
        ita.SetActive(true);
        resultT.text = score.ToString() + " こ";
    }

    public void GoTitleB00() {
        audioSource.PlayOneShot(ButtonSE);
        Invoke("GoTitleB01", 1);
    }
    void GoTitleB01() {
        SceneManager.LoadScene("Title");
    }

    public void GoRetry00() {
        audioSource.PlayOneShot(ButtonSE);
        Invoke("GoRetry01", 1);
    }
    void GoRetry01() {
        SceneManager.LoadScene("Game");
    }
}