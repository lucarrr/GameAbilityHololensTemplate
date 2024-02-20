using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField]
    private float timeBeforeExplode = 1f;
    private bool isTouched = false;
    private AudioSource audioFeedback; 
   
    // Update is called once per frame
    void Update()
    {
        if(isTouched == true)
        {   
            isTouched=false;
            audioFeedback.PlayOneShot(audioFeedback.clip);
            GameObject.Destroy(gameObject, timeBeforeExplode);

        }
    }
    public void StartExploding()
    {
        isTouched = true;
        audioFeedback = GetComponent<AudioSource>();
    }
}
