using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigs : MonoBehaviour
{
    public float speed;
    public float jump;

    private Rigidbody2D rb;

    public bool reloading;
    public float reloadjump;

    public bool TiwuoooooBack;

    public float forceBump;

    public BoxCollider2D BoxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        BoxCollider2D = FindObjectOfType<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TiwuoooooBack) {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        } else {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        if (reloading) {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            reloading = false;
            StartCoroutine(waitJump());
        }
    }

    IEnumerator waitJump() {
        yield return new WaitForSeconds(reloadjump);
        reloading = true;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Tuyau")) {
            if (TiwuoooooBack) {
                rb.velocity = new Vector2(-forceBump, rb.velocity.y);
                transform.Rotate(0, 0, 5);
            } else {
                rb.velocity = new Vector2(forceBump, rb.velocity.y);
                transform.Rotate(0, 0,-5);
            }
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(this);
        }
    }
}
