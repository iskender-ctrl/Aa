using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pnl : MonoBehaviour
{
    [SerializeField]
    GameObject win_pnl, lost_pnl;
    public void youwinpnl_show()
    {
        win_pnl.SetActive(true);
    }
    public void youlostpnl_show()
    {
        lost_pnl.SetActive(true);
    }
    public void nextbtn()
    {
        int thislevel = PlayerPrefs.GetInt("level");
        thislevel++;
        PlayerPrefs.SetInt("level", thislevel);

        SceneManager.LoadScene(0);
    }
    public void againbtn()
    {
        SceneManager.LoadScene(0);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
