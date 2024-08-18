using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmPlayer : MonoBehaviour
{
    public AudioSource bgmSource;

    void Start()
    {
        bgmSource.Play();
    }
}
