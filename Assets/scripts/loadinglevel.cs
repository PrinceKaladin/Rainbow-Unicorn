using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadinglevel : MonoBehaviour
{
    public void loadscene(int scene) {
        SceneManager.LoadScene(scene);
    }

}
