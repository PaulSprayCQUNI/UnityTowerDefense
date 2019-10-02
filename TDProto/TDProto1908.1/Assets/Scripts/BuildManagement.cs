using UnityEditor.Experimental.UIElements.GraphView;
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

	
	private TurretSchema turretToBuild;

    // 1st October introducing a property of public bool variable called CanBuild
    public bool CanBuild
    {
        get { return turretToBuild != null; }
    }

    public bool HasCreds
    {
        get { return PlayerStats.Creds >= turretToBuild.schemaCost; }   
    }

    public void BuildTurretOn(NodeInterface node)
    {

        if (PlayerStats.Creds < turretToBuild.schemaCost)
        {
            Debug.Log("Not enough creds to build that!");
            return;
        }

        PlayerStats.Creds -= turretToBuild.schemaCost;
        
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret Built, Creds remaining: " + PlayerStats.Creds);
    }

	public void SelectTurretToBuild(TurretSchema turret)
    {
        turretToBuild = turret;
    }

}
