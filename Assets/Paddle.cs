using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    [SerializeField]
    float speed;
    float height;

    string input;
    bool isRight;

	// Use this for initialization
	void Start () {
        height = transform.localScale.y;
        speed = 5f;
	}
   public void Init (bool isRightPaddle) {

        isRight = isRightPaddle;
    
        Vector2 pos = Vector2.zero;

        if (isRightPaddle) {
            //place paddle on right screen
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x; // move a bit to the right

            input = "PaddleRight";

        } else{
            //place paddle on left screen
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.left * transform.localScale.x; // move a bit to the left

            input = "PaddleLeft";

        }
        transform.position = pos;
        transform.name = input;
    }
    // Update is called once per frame
    void Update () {
        float move = Input.GetAxis(input) * Time.deltaTime * speed;
        transform.Translate(move * Vector2.up);
	}
}
