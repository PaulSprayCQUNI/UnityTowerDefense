using UnityEngine;

public class BuildManagement : MonoBehaviour
{

	/* every time the game starts their will be one instance of BuildManagement 
	put into the instance variable and accessed from anywhere - important that we are only
	using one BuildManagement */

	public  static BuildManagement instance;
		
	void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManagement instance in scene");
			return;	
		}
		instance = this;
	}

	public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

	
	private GameObject turretToBuild;

	public GameObject GetTurretToBuild()
	{
		return turretToBuild;
	}

    public void SetTurretToBuilder(GameObject turret)
    {
        turretToBuild = turret;
    }


}
