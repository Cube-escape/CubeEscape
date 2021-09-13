using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlenderScreaming : MonoBehaviour
{
    [SerializeField]
    private AudioSource slenderAudioSource;

    [SerializeField]
    private AudioSource effectAudioSource;

    [SerializeField]
    private AudioClip[] clips;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = Random.Range(10f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        if(time < 0)
        {
            slenderAudioSource.clip = clips[0];
            slenderAudioSource.Play();
            Debug.Log("Play Slender Sound");
            time = Random.Range(10f, 30f);
        }
        else
        {
            time -= Time.deltaTime;
        }
    }

    public void Screaming()
    {
        effectAudioSource.clip = clips[1];
        effectAudioSource.Play();
    }
}
