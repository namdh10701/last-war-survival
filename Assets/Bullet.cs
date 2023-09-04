using HyperCasual.Runner;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : ShotBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move the bullet forward along its local Z-axis
        transform.Translate(Vector3.up * 20 * Time.deltaTime);
    }

    public override void OnHit()
    {
        gameObject.SetActive(false);
    }
}
