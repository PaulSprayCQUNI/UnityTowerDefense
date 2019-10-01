using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShop : MonoBehaviour
{
    public TurretSchema standardTurret;
    public TurretSchema missileLauncher;

    //reference to BuildManagement added 160919
    BuildManagement buildManagement;

    void Start()
    {
        buildManagement = BuildManagement.instance;
        
    }


    public void SelectStandardTurret()
    {
        Debug.Log("standard turret selected");
        buildManagement.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("missile launcher selected");
        buildManagement.SelectTurretToBuild(missileLauncher);
    }

    public void LaserTurretBuy()
    {
        Debug.Log("laser turret bought");
    }
}
