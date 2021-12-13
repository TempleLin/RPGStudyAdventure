using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musics : MonoBehaviour
{
    public static Musics singleton = null;
    [SerializeField]
    private List<AudioClip> musics;
    public List<AudioClip> _Musics => musics;
    private AudioSource _AudioSource;
    public AudioSource AudioSource => _AudioSource;

    private void Awake() {
        if (singleton == null) {
            singleton = this;
        }
    }
    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
        _AudioSource.clip = musics[0];
        _AudioSource.loop = true;
        _AudioSource.Play();
    }
}
