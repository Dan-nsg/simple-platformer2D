using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{

    public string compareTag = "Player";
    public ParticleSystem coinParticleSystem;
    public float timeToHide = 1;
    public GameObject graphicItem;

    private void Awake() 
    {
        if(coinParticleSystem != null) coinParticleSystem.transform.SetParent(null);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.transform.CompareTag(compareTag)) 
        {
            Collect();
        }
    }
    protected virtual void Collect() 
    {
        if(graphicItem != null) graphicItem.SetActive(false);
        Invoke("HideObject", timeToHide);
        OnCollect();
    }

    private void HideObject()
    {
      gameObject.SetActive(false);
    }

    protected virtual void OnCollect() 
    { 

    }


}
