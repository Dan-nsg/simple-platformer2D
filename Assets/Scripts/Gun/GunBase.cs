using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;
    public float timeBetweenShoot = .3f;
    public Transform playerSideReference;

    private Coroutine _currentCoroutine;

    public KeyCode keyCode = KeyCode.Z;
    public AudioRandomPlayAudioClips randomShoot;

    private void Awake()
    {
        playerSideReference = GameObject.FindObjectOfType<Player>().transform;
    }


    private void Update() 
    {
        if(Input.GetKeyDown(keyCode))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
            if(randomShoot != null) randomShoot.PlayRandom();
        }
        else if (Input.GetKeyUp(keyCode))
        {
            if(_currentCoroutine != null) 
                StopCoroutine(_currentCoroutine);
        }
    }

    IEnumerator StartShoot()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = playerSideReference.transform.localScale.x;
    }
}
