using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeBlueController : MonoBehaviour { 

    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    private bool moving;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    private float timeToMoveCounter;
    public float timetoMove;
    private Vector3 moveDirection;

    public float waitToReload;
    private bool reloading;

    private GameObject thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        //timeBetweenMoveCounter = timeBetweenMove;
        //timeToMoveCounter = timetoMove;

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timetoMove * 0.75f, timeBetweenMove * 1.25f);


    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = moveDirection;

            if(timeToMoveCounter < 0f)
            {
                moving = false;
                //timeBetweenMoveCounter = timeBetweenMove;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;
            if(timeBetweenMoveCounter < 0f)
            {
                moving = true;
                //timeToMoveCounter = timetoMove;
                timeToMoveCounter = Random.Range(timetoMove * 0.75f, timeBetweenMove * 1.25f);


                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }
        if(reloading == true)
        {
            waitToReload -= Time.deltaTime;
            if(waitToReload < 0f)
            {
                Application.LoadLevel(Application.loadedLevel);
                thePlayer.SetActive(true);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.tag == "Weapon")
        {
        }*/
    }
}
