using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunProjectiles : MonoBehaviour
{
    //Timer
    Time timer;

    //Skott
    public GameObject bullet;

    //Kraft av skott
    public float shootForce, uppwardsForce;

    //Vapen info
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;

    //bools
    bool shooting, readyToShoot, reloading;

    //Referenser
    public Camera fpsCam;
    public Transform attackPoint;
    public Transform ShellEjection;

    //Grafik
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

    public bool allowInvoke = true;

    private void Awake()
    {
        //Kollar s� du har fullt magasin
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();

        //Ammo display
        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);
    }

    private void MyInput()
    {
        //Kollar om man f�r h�lla in skjutknappen eller inte
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Ladda om
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();
        //Ladda om automatiskt om man f�rs�ker skjuta utan ammo
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();

        //Skjuta
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //S�ger att man inte skjutit �n
            bulletsShot = 0;

            Shoot();
        }
    }

    public void Shoot()
    {
        readyToShoot = false;

        //Hittar vart skottet ska tr�ffa genom att anv�nda raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //Raycast genom mitten av sk�rmen
        RaycastHit hit;

        //Kollar om raycast tr�ffar n�got
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);//Bara en punkt l�ngt fr�n spelaren

        //R�kna ut riktningen fr�n attackPoint till targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //R�kna ut bulletspread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //R�kna ut ny riktning med bulletspread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //L�gger bara till spread till f�rra riktningen

        //Instansiate skottet
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        //Rotera skotten till skjutriktningen
        currentBullet.transform.forward = directionWithSpread.normalized;

        //L�gg p� kraft till skottet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * uppwardsForce, ForceMode.Impulse);

        //Instansiate muzzle flash
        if (muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot++;

        //Invoke resetShot funktionen(om inte redan gjort det), med timeBetweenShooting
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        //Om mer �n ett bulletsPerTap s� repeterar den shoot funktionen
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        //Till�t skjuta och invoking igen
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
