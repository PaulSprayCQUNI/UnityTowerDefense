using UnityEngine;
using UnityEngine.EventSystems;

public class NodeInterface : MonoBehaviour
{

	public Color hoverColor;
    public Color notEnoughCredColor;
	public Vector3 positionOffset;

    // GameObject made public for option of turrets in place before Start(), per BuildManagement function
    [Header("Optional")]
    public GameObject turret;

	/* avoid having all nodes storing their own reference to BuildManagement, 
	instead make it available via a Singleton pattern to make access of an instance of the BuildManagement easier
	*/

	private Renderer rend;
	private Color initColor;

    private BuildManagement buildManagement;

    // Start is called before the first frame update
    void Start()
    {

	rend = GetComponent<Renderer>();
	initColor = rend.material.color;

    buildManagement = BuildManagement.instance;
        
    }

    // helper function called in BuildManagement
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

	void OnMouseDown ()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        // changed call to condition check in BuildManagement class to call a property in same class
        // same applied to MouseEnter
        if (!buildManagement.CanBuild)
            return;

		if(turret != null)
		{
			Debug.Log("Can't build on another turret - soz TODO - for UI later");
			return;
		}
		// 1st October replaced instantiation based on condition of turret == null with function called within BuildManagement
        buildManagement.BuildTurretOn(this);
    }

	void OnMouseEnter ()
	{

        if (EventSystem.current.IsPointerOverGameObject())
            return;
      
        if (!buildManagement.CanBuild)
            return;

        if (buildManagement.HasCreds)
        {
            rend.material.color = hoverColor;
        } else
        {
            rend.material.color = notEnoughCredColor;
        }

	}
   
   void OnMouseExit ()
   {
   	   rend.material.color = initColor;	 
   }
}
