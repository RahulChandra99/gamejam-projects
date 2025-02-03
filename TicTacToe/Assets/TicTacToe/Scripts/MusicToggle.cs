using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicToggle : MonoBehaviour
{
    public AudioSource BGMusicPrefab;
    public void OnMouseDown()
    {
        if (BGMusicPrefab.mute)
        {
            BGMusicPrefab.mute = false;
        }
        else if(!BGMusicPrefab.mute)

            BGMusicPrefab.mute = true;
    }
}
