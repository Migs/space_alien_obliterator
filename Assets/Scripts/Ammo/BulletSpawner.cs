using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;
using FishNet.Object;

public class BulletSpawner : NetworkBehaviour
{
    [SerializeField] FloatVariable _bulletDelay;
    bool toFire = true;
    public GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (toFire)
        {
            StartCoroutine("Fire");
        }
    }

    IEnumerator Fire()
    {
        Debug.Log("Inside");
        toFire = false;
        
        ServerManager.Spawn(Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation));
        yield return new WaitForSeconds(_bulletDelay.Value);
        toFire = true;
    }
}
