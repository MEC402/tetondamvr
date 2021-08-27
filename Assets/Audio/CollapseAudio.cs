using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapseAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip broadcastAudio;
    public AudioClip waterAudio;

    public int waterDelayTime;

    private AudioSource broadcastSource;
    private AudioSource waterSource;
    void Start()
    {
        broadcastSource = this.gameObject.AddComponent<AudioSource>();
        waterSource = this.gameObject.AddComponent<AudioSource>();

        broadcastSource.clip = broadcastAudio;
        waterSource.clip = waterAudio;
        waterSource.volume = .1f;
        waterSource.time = 40;

        StartCoroutine(playAudio());
    }

    IEnumerator playAudio()
    {
        broadcastSource.Play();
        yield return new WaitForSeconds(waterDelayTime);
        yield return playWater();
    }

    IEnumerator playWater()
    {
        
        waterSource.Play();
        //loop infinitely
        while (waterSource.isPlaying)
        {
            if(waterSource.time > 60)
            {
                waterSource.time = 45;
            }

            yield return null;
        }
    }
}
