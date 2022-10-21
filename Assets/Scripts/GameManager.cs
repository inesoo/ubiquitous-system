using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake(){
        Instance = this;
    }
    
    public int Score = 0;
    public int Vies = 3;
    public Text scoreText;


    public float reloadSpawn;
    private bool reloading;

    public GameObject PigLeftPrefab;
    public GameObject PigRightPrefab;

    private float chooser;

    public GameObject panelLose;

    public AudioSource crouch1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Score < 5) {
            if (!reloading) {

                chooser = Random.Range(0, 3);
                print (chooser);
                if (chooser <= 1.5f) {
                    Instantiate( PigLeftPrefab, new Vector3(Random.Range(-12.5f, -16),Random.Range(-3.5f, 2.5f),0), Quaternion.identity);
                    reloading = true;
                    StartCoroutine(waitSpawn());
                }

                if (chooser >= 1.5f) {
                    Instantiate( PigRightPrefab, new Vector3(Random.Range(12.5f, 16),Random.Range(-3.5f, 2.5f),0), Quaternion.identity);
                    reloading = true;
                    StartCoroutine(waitSpawn());
                }

                
            }
        }
        
        /*if (vie <= 0) {
            GameManager.Instance.panelLose.SetActive(true);
            mort.Play();
        }*/

        if (Score >= 5) {
            if (!reloading) {

                chooser = Random.Range(0, 3);
                print (chooser);
                if (chooser <= 1.5f) {
                    Instantiate( PigLeftPrefab, new Vector3(Random.Range(-12.5f, -16),Random.Range(-3.5f, 2.5f),0), Quaternion.identity);
                    reloading = true;
                    StartCoroutine(waitSpawn());
                }

                if (chooser >= 1.5f) {
                    Instantiate( PigRightPrefab, new Vector3(Random.Range(12.5f, 16),Random.Range(-3.5f, 2.5f),0), Quaternion.identity);
                    reloading = true;
                    StartCoroutine(waitSpawn());
                }
            }
        }

        if (Vies == 0) {
            Perdu();
        }
    }

    IEnumerator waitSpawn() {
        yield return new WaitForSeconds(reloadSpawn);
        reloading = false;
    }

    public void MyloadScene(int idScene){
        UnityEngine.SceneManagement.SceneManager.LoadScene(idScene);
    }

    public void Rate() {
        Vies -= 1;
    }

    public void Crouch() {
        Score += 1;
        crouch1.Play();
        scoreText.text = Score.ToString("00");
    }

    public void Perdu() {
        panelLose.SetActive(true);
    }
}
