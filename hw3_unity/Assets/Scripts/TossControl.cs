using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TossControl : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 angle;
    private bool isPressed;

    public GameObject Grading;
    private Grading grading;

    public GameObject GradeNice;
    private GradeNice gradeNice;

    public GameObject nextBall;

    public GameObject SEgameObject;
    private AudioSource SE;
    public AudioClip throw_SE;

    [HideInInspector]
    public float power;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        isPressed = false;

        grading = Grading.GetComponent<Grading>();
        gradeNice = GradeNice.GetComponent<GradeNice>();

        SE = SEgameObject.GetComponent<AudioSource>();

        power = 0f;
    }

    void Update()
    {
        if(isPressed)
        {
            angle = rb.position - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            angle.Normalize();
            //Debug.Log(angle);

            if(power<1f){
                power += .01f;
                //Debug.Log(power);
            }
        }


        if(Input.GetMouseButtonDown(0))
        {
            isPressed = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            SE.PlayOneShot(throw_SE);

            isPressed = false;

            grading.total += 1;
            //Debug.Log("total : " + grading.total);

            GetComponent<SpringJoint2D>().enabled = false;
            rb.isKinematic = false;
            rb.AddForce(angle*power*1000f);
            //Debug.Log(angle*power*1000f);

            power = 0f;
            this.enabled = false;

            StartCoroutine(NextBall());
            
        }
    }

    IEnumerator NextBall()
    {

        yield return new WaitForSeconds(3f);

        // nextBall coming alive
        if(nextBall != null)
        {
            nextBall.SetActive(true);
        }
        else
        {
            gradeNice.BallsRemain = true;
            Debug.Log("Run out of balls!");
            //SceneManager.LoadScene(0);
        }

        
        Destroy(gameObject);
    }
}
