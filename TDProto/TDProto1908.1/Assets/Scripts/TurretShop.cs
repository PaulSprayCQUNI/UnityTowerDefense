using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShop : MonoBehaviour
{

    //reference to BuildManagement added 160919
    BuildManagement buildManagement;

    void Start()
    {
        buildManagement = BuildManagement.instance;
        
    }


    public void StandardTurretBuy()
    {
        Debug.Log("standard turret selected");
        buildManagement.SetTurretToBuilder(buildManagement.standardTurretPrefab);
    }

    public void MissileLauncherBuy()
    {
        Debug.Log("missile launcher selected");
        buildManagement.SetTurretToBuilder(buildManagement.missileLauncherPrefab);
    }

    public void LaserTurretBuy()
    {
        Debug.Log("laser turret bought");
    }
}
