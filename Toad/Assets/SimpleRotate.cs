using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class SimpleRotate : MonoBehaviour
{
    public float RotationAmount = 2f;
    public int TicksPerSecond = 60;
    public bool Pause = false;
    public Transform target;
    private float Orotation;
    public Animator animator;
    public Button button;

    public AudioSource randomSound;

    public AudioClip coinAudio;
    public AudioClip musicAudio;

    public AudioClip[] audioSourcesAdverb;
    public AudioClip[] audioSourcesInstruct;
    public AudioClip[] audioSourcesPreposition;
    public AudioClip[] audioSourcesVerb;
    public AudioClip[] audioSourcesNoun;

    // DISABLE BUTTON ONCE PUSHED!!


//  "You will have good luck when The Maiden Cries under the stone arch"
/// <summary>
/// Instruct --> "You will have", "find", "beware", "seek" "
/// Subject/Noun   ----> "The maiden", "Good luck", "bad luck", The Spire", "The moon"
/// Preposition --->  "when", "if", "on", "after", "across", "above", "beneath", "for", "against", "before"
/// Subject/Noun (s)
/// Verb ---> "cries", "fades", "speaks", "hides", "lingers", "whispers", "shines", 
/// Adverb ---> "Next week", "at midday", "under the full moon"
/// 
/// </summary>
    private void Start()
    {
        Orotation = transform.rotation.y;
        button.interactable = true;
    }

    public void Talk()
    {
        //randomSound.clip = coinAudio;
        StartCoroutine(Activate());

      //  randomSound.clip = musicAudio;
        //StartCoroutine(Rotate());
       // CallAudio();
    }


    void CallAudio(int count)
    {

        switch (count)
        {
            case 0: {

                    randomSound.clip = audioSourcesInstruct[UnityEngine.Random.Range(0, audioSourcesInstruct.Length)];
                    randomSound.Play();
                    break;

                }

            case 1: {
                    randomSound.clip = audioSourcesNoun[UnityEngine.Random.Range(0, audioSourcesNoun.Length)];
                    randomSound.Play();
                    break;
                }

            case 2:
                {
                    randomSound.clip = audioSourcesPreposition[UnityEngine.Random.Range(0, audioSourcesPreposition.Length)];
                    randomSound.Play();
                    break;
                }
            case 3:
                {
                    randomSound.clip = audioSourcesNoun[UnityEngine.Random.Range(0, audioSourcesNoun.Length)];
                    randomSound.Play();
                    break;
                }

            case 4:
                {
                    randomSound.clip = audioSourcesVerb[UnityEngine.Random.Range(0, audioSourcesVerb.Length)];
                    randomSound.Play();
                    break;
                }
            case 5:
                {
                    randomSound.clip = audioSourcesAdverb[UnityEngine.Random.Range(0, audioSourcesAdverb.Length)];
                    randomSound.Play();
                    break;
                }
        }
        
       
    }

    private IEnumerator Activate()
    {
        //WaitForSeconds WaitNow = new WaitForSeconds(
        int i = 0;
        while (i < 2)
        {
            if( i == 0)
            {
                randomSound.clip = coinAudio;
                randomSound.Play();
                while(randomSound.isPlaying)
                {
                    yield return null;
                }
                i++;
            }
            if (i == 1)
            {
                randomSound.clip = musicAudio;
                randomSound.Play();
                while (randomSound.isPlaying)
                {
                    yield return null;
                }
                i++;
            }
            yield return Rotate();
        }
        
    }

    private IEnumerator Rotate()
    {
        button.interactable = false;
        WaitForSeconds Wait = new WaitForSeconds(1f / TicksPerSecond);
        int i = 0;
        CallAudio(i);

        while (i < 6)
        {
            
            if (!Pause)

            {
                transform.Rotate(Vector3.down * RotationAmount);
                if(transform.rotation.y > target.rotation.y)
                {
                    Pause = true;
                }
            }

           if (Pause)
            {
                transform.Rotate(Vector3.up * RotationAmount);
                if ( transform.rotation.y < Orotation)
                {
                    Pause = false;
                    i++;
                    if (i < 6) { CallAudio(i); }



                }
            }
           

            yield return Wait;
        }
        button.interactable = true;
    }
}