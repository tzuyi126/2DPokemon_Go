using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject Canvas2;

    void Start()
    {
        Canvas2.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void btnLevel1()
    {
        SceneManager.LoadScene("level1");
    }
    public void btnLevel2()
    {
        SceneManager.LoadScene("level2");
    }
    public void btnExit()
    {
        //Debug.Log("QUIT");
        Application.Quit();
    }

    public void btnHow()
    {
        Canvas2.SetActive(true);
    }
    public void btnBack()
    {
        Canvas2.SetActive(false);
    }
}
