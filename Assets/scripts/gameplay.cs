using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameplay : MonoBehaviour
{

    public GameObject bg;
    public Sprite bg1;
    public Sprite bg2;
    public Sprite bg3;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("level")) { PlayerPrefs.SetInt("level", 1); }
        levelbg();
    }
    private void Start()
    {

    }
    void levelbg()
    {
        if (PlayerPrefs.GetInt("level") == 1)
        {
            bg.GetComponent<SpriteRenderer>().sprite=bg1;
        }
        else if (PlayerPrefs.GetInt("level") == 2)
        {
            bg.GetComponent<SpriteRenderer>().sprite = bg2;
        }
        else if(PlayerPrefs.GetInt("level") == 3)
        {
            bg.GetComponent<SpriteRenderer>().sprite = bg3;
        }

    }
}
