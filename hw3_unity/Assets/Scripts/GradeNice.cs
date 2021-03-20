using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GradeNice : MonoBehaviour
{
    [HideInInspector]
    public int NiceCount;
    [HideInInspector]
    public bool isGraded;
    [HideInInspector]
    public float EnemyHealth;
    [HideInInspector]
    public bool Defeated;
    [HideInInspector]
    public bool BallsRemain;

    public GameObject HealthBar;
    public GameObject HitText;

    public GameObject SEgameObject;
    private AudioSource SE;
    public AudioClip light_smash;

    public float DamageAmount;
    // Start is called before the first frame update
    void Start()
    {
        NiceCount = 0;

        Defeated = false;
        BallsRemain = false;

        isGraded = false;
        HitText.SetActive(false);

        SE = SEgameObject.GetComponent<AudioSource>();

        EnemyHealth = 1f;
    }

    void Update()
    {
        //Debug.Log("Health : " + EnemyHealth);
        HealthBar.GetComponent<Image>().fillAmount = EnemyHealth;

        if(EnemyHealth <= 0f)
        {
            //Debug.Log("Stage clear!");
            Defeated = true;
        }

        if(isGraded)
        {
            StartCoroutine(RefreshGrade());
        }
    }

    IEnumerator RefreshGrade()
    {
        yield return new WaitForSeconds(2f);

        isGraded = false;
        HitText.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player" && !isGraded)
        {
            isGraded = true;
            SE.PlayOneShot(light_smash);
            EnemyHealth -= DamageAmount;

            NiceCount += 1;
            //Debug.Log("nice : " + NiceCount);
            HitText.GetComponent<Text>().text = "NICE";
            HitText.GetComponent<Text>().color = new Color(45f/255f,1f,0);
            HitText.SetActive(true);
        }
    }
}
