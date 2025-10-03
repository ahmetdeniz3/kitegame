using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public  GameObject bullet;
    public  Transform bulletTransform;
    public bool canfire;
    private float timer;
    public float timerbetweemFiring;
    public float AmmoChangeSpeed;
    public float ammoChangeTimer;
    public float ammoNumber;
    public static float availableAmmo;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        availableAmmo=ammoNumber;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos=mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation=mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y,rotation.x)*Mathf.Rad2Deg;

        transform.rotation=Quaternion.Euler(0,0,rotZ);
        if(availableAmmo<=0)
        {
            canfire = false;
            ammoChangeTimer += Time.deltaTime;
            if (ammoChangeTimer > AmmoChangeSpeed)
            {
                availableAmmo = ammoNumber;
                canfire = true;
                ammoChangeTimer = 0;
            }
        }

        if (!canfire&&availableAmmo>0)
        {
            timer += Time.deltaTime;
            if(timer > timerbetweemFiring)
            {
                canfire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButtonDown(0)&&canfire) 
        {
            canfire = false;
        Instantiate(bullet,bulletTransform.position,Quaternion.identity);
            availableAmmo--;
        }
    }
}
