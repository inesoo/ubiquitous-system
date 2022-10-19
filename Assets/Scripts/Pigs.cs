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


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

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
}
