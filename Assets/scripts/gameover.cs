using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{
    public Sprite spriteend;
    public Sprite spritewin;
    void Awake()
    {
        if (PlayerPrefs.GetString("winlose")=="lose") {
            this.GetComponent<SpriteRenderer>().sprite = spriteend;

        }
        else if (PlayerPrefs.GetString("winlose") == "win")
        {
            this.GetComponent<SpriteRenderer>().sprite = spritewin;

        }
    }

}
