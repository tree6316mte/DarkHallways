using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public int chapterProgress = 0;
    // Start is called before the first frame update
    void Start()
    {
        chapterProgress = PlayerPrefs.GetInt("chapterProgress", 0);
    }

}
