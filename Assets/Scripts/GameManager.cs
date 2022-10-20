using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score = 0;

    public float reloadSpawn;
    private bool reloading;

    public GameObject PigLeftPrefab;
    public GameObject PigRightPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Score < 5) {
            if (!reloading) {
                Instantiate( PigLeftPrefab, new Vector3(-13,Random.Range(-3.5f, 2.5f),0), Quaternion.identity);
            }
        }

        if (Score >= 5 && Score < 10) {

        }

        if (Score >= 10 && Score < 15) {

        }
    }

    void PlusScore() {
        Score++;
    }

    IEnumerator waitSpawn() {
        yield return new WaitForSeconds(reloadSpawn);
        reloading = false;
    }
}
