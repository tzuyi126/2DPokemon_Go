using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    private GameObject ball;
    TossControl tossControl;

    public GameObject Bar1;
    Image bar1;
    public GameObject Bar2;
    Image bar2;

    // Start is called before the first frame update
    void Start()
    {
        ball = gameObject.transform.parent.gameObject;
        tossControl = ball.GetComponent<TossControl>();

        bar1 = Bar1.GetComponent<Image>();
        bar2 = Bar2.GetComponent<Image>();

        bar1.fillAmount = 0f;
        bar2.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(tossControl.power);
        float val = tossControl.power;
        bar1.fillAmount = val;
        bar2.fillAmount = val;
    }
}
