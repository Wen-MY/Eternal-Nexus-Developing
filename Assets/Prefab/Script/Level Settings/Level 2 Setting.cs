using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Setting : MonoBehaviour
{
    public AudioClip bgm;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.ChangeBGM(bgm);
    }

    // Update is called once per frame
    
}
