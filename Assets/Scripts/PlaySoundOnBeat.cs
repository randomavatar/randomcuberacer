using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnBeat : MonoBehaviour
{
    public SoundManager soundManager;
    public AudioClip tap, tick;
    public AudioClip[] strum;
    int randomStrum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BPeerM.beatFull)
        {
            soundManager.PlaySound(tap, 1);

            if (BPeerM.beatCountFull % 2 == 0)
            {
                randomStrum = Random.Range(0, strum.Length);
            }
        }

        if (BPeerM.beatD8 && BPeerM.beatCountD8 % 2 == 0)
        {
            soundManager.PlaySound(tick, 0.1f);
        }

        if (BPeerM.beatD8 && (BPeerM.beatCountD8 % 8 == 2 || BPeerM.beatCountD8 % 8 == 4))
        {
            soundManager.PlaySound(strum[randomStrum], 1);
        } 
    }
}
