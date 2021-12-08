using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicsList : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> musics;
    public List<AudioClip> Musics => musics;
    private AudioSource _AudioSource;
    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
        _AudioSource.clip = musics[0];
        _AudioSource.loop = true;
        _AudioSource.Play();
    }
}
