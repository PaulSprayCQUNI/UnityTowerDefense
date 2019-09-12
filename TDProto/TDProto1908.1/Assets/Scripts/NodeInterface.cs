using UnityEngine;

public class NodeInterface : MonoBehaviour
{

	public Color hoverColor;
	public Vector3 positionOffset;
	private GameObject turret;

	/* avoid having all nodes storing their own reference to BuildManagement, 
	instead make it available via a Singleton pattern to make access of an instance of the BuildManagement easier
	*/

	private Renderer rendit;
	private Color initColor;


    // Start is called before the first frame update
    void Start()
    {

	rendit = GetComponent<Renderer>();
	initColor = rendit.material.color;
        
    }

	void OnMouseDown ()
	{
		if(turret != null)
		{
			Debug.Log("Can't build on another turret - soz TODO - for UI later");
			return;
		}
		// Build a turret if turret == null, with instatiation, that is integrated as part of a build manager

		GameObject turretToBuild =  BuildManagement.instance.GetTurretToBuild();
		turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);


		 

	}

	void OnMouseEnter ()
	{
		rendit.material.color = hoverColor;
	}
   
   void OnMouseExit ()
   {
   	   rendit.material.color = initColor;	 
   }
}
