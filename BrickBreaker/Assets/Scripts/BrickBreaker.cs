using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrickBreaker : MonoBehaviour {

    public GameObject ballPrefab;
    public GameObject paddlePrefab;

	// Use this for initialization
	void Start ()
    {
        GameObject tBallGO = Instantiate(ballPrefab) as GameObject;
        GameObject tPaddleGO = Instantiate(paddlePrefab) as GameObject;
    }

    // Update is called once per frame
    void Update () {
    
	}

    public void BallDestroyed()
    {
        LivesDisplay.lives -= 1;
        //Paddle.PaddleDestroy();
        GameObject tBallGO = Instantiate(ballPrefab) as GameObject;
        if (LivesDisplay.lives == 0)
        {
            SceneManager.LoadScene("_Scene_0");
            Ball.brick = 20;
            LivesDisplay.lives = 3;
        }
    }
}
