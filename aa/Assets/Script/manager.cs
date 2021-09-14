using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class manager : MonoBehaviour
{
    public GameObject ballPrefab;
    int ballnumber;
    List<Rigidbody2D> allballs = new List<Rigidbody2D>();

    float speed = 20.0f;
    float firstballposition = -3f;
    [SerializeField]
    TextMeshProUGUI level_txt;
    int level;

    pnl ui;
    void Start()
    {
        ui = GameObject.FindObjectOfType<pnl>();
        levelcontrole();

        firstballadd();
    }

    void levelcontrole()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            level = PlayerPrefs.GetInt("level");
        }
        else
        {
            level = 1;
            PlayerPrefs.SetInt("level", level);
        }
        level_txt.text = level.ToString();
    }

    void firstballadd()
    {
        ballnumber = level * 3;

        for (int i = 0; i < ballnumber; i++)
        {
            GameObject newball = Instantiate(ballPrefab);

            if (i == 0)
            {
                newball.transform.position = new Vector2(0, firstballposition);
            }
            else
            {
                newball.transform.position = new Vector2(0, allballs[i - 1].transform.position.y - (allballs[i - 1].GetComponent<CircleCollider2D>().bounds.size.y * 1.5f));
            }

            newball.GetComponentInChildren<TextMeshProUGUI>().text = (ballnumber - i).ToString();

            allballs.Add(newball.GetComponent<Rigidbody2D>());
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && allballs.Count > 0)
        {
            allballs[0].velocity = Vector2.up * speed;

            allballs.RemoveAt(0);
        }
        else if (allballs.Count <= 0)
        {
            youwin();
        }
    }
    void youwin()
    {
        ui.youwinpnl_show();
        this.enabled = false;
    }
    public  void youlost()
    {
        ui.youlostpnl_show();
        this.enabled = false;
    }

    public void ballspositionupdate()
    {
        for (int i = 0; i < allballs.Count; i++)
        {
            if (i == 0)
            {
                allballs[i].transform.position = new Vector2(0, firstballposition);
            }
            else
            {
                allballs[i].transform.position = new Vector2(0, allballs[i - 1].transform.position.y - (allballs[i - 1].GetComponent<CircleCollider2D>().bounds.size.y * 1.5f));
            }
        }
    }
}
