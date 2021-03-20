using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradeGreat : MonoBehaviour
{
    [HideInInspector]
    public int GreatCount;

    public GameObject GradeNice;
    private GradeNice gradeNice;

    public GameObject HitText;

    public GameObject SEgameObject;
    private AudioSource SE;
    public AudioClip smash;

    public float DamageAmount;
    // Start is called before the first frame update
    void Start()
    {
        GreatCount = 0;

        gradeNice = GradeNice.GetComponent<GradeNice>();

        HitText.SetActive(false);
        
        SE = SEgameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player" && !gradeNice.isGraded)
        {
            gradeNice.isGraded = true;
            SE.PlayOneShot(smash);
            gradeNice.EnemyHealth -= DamageAmount;

            GreatCount += 1;
            //Debug.Log("great : " + GreatCount);
            HitText.GetComponent<Text>().text = "GREAT";
            HitText.GetComponent<Text>().color = new Color(1f,177f/255f,0);
            HitText.SetActive(true);
        }
    }
}
