using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject panelLose;
    public static GameManager Instance;
    private void Awake(){
        Instance = this;
    }
    
    public int Score = 0;
    public int Vies = 3;

    public float reloadSpawn;
    private bool reloading;

    public GameObject PigLeftPrefab;
    public GameObject PigRightPrefab;

    private float chooser;

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

        if (Score >= 5 && Score < 10) {

        }

        if (Score >= 10 && Score < 15) {

        }
    }

    IEnumerator waitSpawn() {
        yield return new WaitForSeconds(reloadSpawn);
        reloading = false;
    }

    public void MyloadScene(int idScene){
        UnityEngine.SceneManagement.SceneManager.LoadScene(idScene);
    }
}
