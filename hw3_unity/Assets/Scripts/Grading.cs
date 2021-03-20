using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grading : MonoBehaviour
{
    public GameObject Text;
    private Text text;
    
    [HideInInspector]
    public int total;

    public GameObject Canvas2;

    private Text WinLoseText;
    private Text ThrowText;
    private GameObject btnNextLevel;
    private GameObject btnReplay;

    public GameObject GradeNice;
    private GradeNice gradeNice;
    public GameObject GradeGreat;
    private GradeGreat gradeGreat;

    // Start is called before the first frame update
    void Start()
    {
        text = Text.GetComponent<Text>();

        total = 0;

        Canvas2.SetActive(false);

        WinLoseText = Canvas2.transform.Find("WinLoseText").gameObject.GetComponent<Text>();
        ThrowText = Canvas2.transform.Find("ThrowText").gameObject.GetComponent<Text>();
        btnNextLevel = Canvas2.transform.Find("NextLevel").gameObject;
        btnNextLevel.SetActive(false);
        btnReplay = Canvas2.transform.Find("Replay").gameObject;
        btnReplay.SetActive(false);

        gradeNice = GradeNice.GetComponent<GradeNice>();
        gradeGreat = GradeGreat.GetComponent<GradeGreat>();
    }

    void Update()
    {
        text.text = "Toss Time : " + total;

        ThrowText.text = "You throw " + total + " times!\n" + gradeNice.NiceCount + " times Nice Throw, " + gradeGreat.GreatCount + " times Great Throw!";
        
        if(gradeNice.Defeated == true)
        {
            WinLoseText.text = "Stage clear!";
            btnNextLevel.SetActive(true);
            Canvas2.SetActive(true);
        }
        else
        {   
            if(gradeNice.BallsRemain == true)
            {
                WinLoseText.text = "Run out of balls!";
                btnReplay.SetActive(true);
                Canvas2.SetActive(true);
            }
        }
        
    }
}
