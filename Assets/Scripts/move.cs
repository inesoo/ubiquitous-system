using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject TuyauA;
    public GameObject TuyauB;

    public float speedJump = 5;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 ) 
        {
            rb2d.velocity = new Vector2(0, speedJump);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision) {
    //    if (collision.CompareTag("Pig")) {
    //        ouvreTuyau = true;
    //    }
    //}

    IEnumerator waitTuyau() {
        yield return new WaitForSeconds(0.2f);
        TuyauA.GetComponent<Tuyau>().fermeture();
        TuyauB.GetComponent<Tuyau>().fermeture();
        yield return new WaitForSeconds(0.2f);
        TuyauA.GetComponent<Tuyau>().stopTout();
        TuyauB.GetComponent<Tuyau>().stopTout();
        rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    void OnTriggerEnter2D(Collider2D truc) {
        if (truc.tag == "Pig") {
            //rb2d.constraints = RigidbodyConstraints2D.FreezeRotationX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotationZ;
            //rb2d.constraints = RigidbodyConstraints2D.None;
            //rb2d.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            TuyauA.GetComponent<Tuyau>().ouverture();
            TuyauB.GetComponent<Tuyau>().ouverture();
            StartCoroutine(waitTuyau());
        }
    }
}
