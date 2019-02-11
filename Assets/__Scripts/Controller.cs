using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Lets you interact with the UI

public class Controller : MonoBehaviour
{
    public float speed;
    public Text scoreText;
    Score points = new Score();
    private Rigidbody rigidb;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidb = GetComponent<Rigidbody>();
        int score = 0;
        SetScoreText(score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveH, 0.0f, moveV);
        rigidb.AddForce(move * speed);
    }

    //Called when game object touches a trigger collider, will remove the game object we touch if it is a pick up
    void OnTriggerEnter (Collider otherObj)
    {
        //Diamond pick up
        if (otherObj.GetComponent<Renderer>().material.color == Color.cyan)
        {
            otherObj.gameObject.SetActive(false);
            points.score += 4;
            SetScoreText(points.score);        
        }
        //Gold pick up
        else if (otherObj.GetComponent<Renderer>().material.color == Color.yellow)
        {
            otherObj.gameObject.SetActive(false);
            points.score += 3;
            SetScoreText(points.score);
        }
        //Silver pick up
        else if (otherObj.GetComponent<Renderer>().material.color == Color.grey)
        {
            otherObj.gameObject.SetActive(false);
            points.score += 2;
            SetScoreText(points.score);
        }
        //Bronze pick up
        else if (otherObj.GetComponent<Renderer>().material.color == Color.magenta)
        {
            otherObj.gameObject.SetActive(false);
            points.score += 1;
            SetScoreText(points.score);
        }
    }

    public class Score
    {
        private int _score;
        //Properties for scoring
        public int score
        {
            get { return _score; }
            set { _score = value; }
        }
    }
    public void SetScoreText(int score)
    {
        scoreText.text = "Current Score: " + score.ToString();
    }
}
