using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchWeapon : MonoBehaviour
{
    public GameObject defaltStaff;
    public GameObject FastShootingStaff;
    public GameObject FastProjectileStaff;

    public Image defaltStaffImage;
    public Image FastShootingStaffImage;
    public Image FastProjectileStaffImage;
    void Start() 
    {
        EquipDefaultStaff();
    }
    public void EquipDefaultStaff() 
    {
        defaltStaff.SetActive(true);
        FastShootingStaff.SetActive(false);
        FastProjectileStaff.SetActive(false);
        defaltStaffImage.enabled = true;
        FastProjectileStaffImage.enabled = false;
        FastShootingStaffImage.enabled = false;
    }

    public void EquipFastShootingStaff() 
    {
        defaltStaff.SetActive(false);
        FastShootingStaff.SetActive(true);
        FastProjectileStaff.SetActive(false);
        defaltStaffImage.enabled = false;
        FastProjectileStaffImage.enabled = false;
        FastShootingStaffImage.enabled = true;
    }

    public void EquipFastProjectileStaff() 
    {
        defaltStaff.SetActive(false);
        FastShootingStaff.SetActive(false);
        FastProjectileStaff.SetActive(true);
        defaltStaffImage.enabled = false;
        FastProjectileStaffImage.enabled = true;
        FastShootingStaffImage.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
         if (obj.collider.gameObject.tag == "WeaponFastProjectile")
        {
            EquipFastProjectileStaff();
            Destroy(obj.collider.gameObject);
        }
        if (obj.gameObject.tag == "WeaponFastShooting")
        {
            EquipFastShootingStaff();
            Destroy(obj.collider.gameObject);
        }
    }
    
}
