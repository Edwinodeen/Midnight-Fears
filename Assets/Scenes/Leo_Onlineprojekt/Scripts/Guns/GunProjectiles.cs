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
        //Kollar så du har fullt magasin
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
        //Kollar om man får hålla in skjutknappen eller inte
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Ladda om
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();
        //Ladda om automatiskt om man försöker skjuta utan ammo
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();

        //Skjuta
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //Säger att man inte skjutit än
            bulletsShot = 0;

            Shoot();
        }
    }

    public void Shoot()
    {
        readyToShoot = false;

        //Hittar vart skottet ska träffa genom att använda raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //Raycast genom mitten av skärmen
        RaycastHit hit;

        //Kollar om raycast träffar något
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);//Bara en punkt långt från spelaren

        //Räkna ut riktningen från attackPoint till targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //Räkna ut bulletspread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Räkna ut ny riktning med bulletspread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //Lägger bara till spread till förra riktningen

        //Instansiate skottet
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        //Rotera skotten till skjutriktningen
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Lägg på kraft till skottet
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

        //Om mer än ett bulletsPerTap så repeterar den shoot funktionen
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        //Tillåt skjuta och invoking igen
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
