using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

    public float ballInitialVelocity = 600f;
    private Rigidbody rb;
    private bool ballInPlay;
    public static float bottomY = -20f;
    static public int brick = 20;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
        }

        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            BrickBreaker bbScript = Camera.main.GetComponent<BrickBreaker>();
            bbScript.BallDestroyed();
        }

	}

    void OnCollisionEnter (Collision coll) {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Brick")
        {
            Destroy(collidedWith);
            brick -= 1;
            if (brick < 1)
            {
                LevelDisplay.level += 1;
                SceneManager.LoadScene("_Scene_0");
                brick = 20;
            }
        }
    }
}
