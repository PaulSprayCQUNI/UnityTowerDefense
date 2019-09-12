using UnityEngine;

public class CameraController : MonoBehaviour
{
	
	private bool panToggle = true;
	
	public float camPanSpeed = 20f;
	public float panBuffer = 10f;
	
	public float scrollSpeed = 5f;
	public float minY = 10f;
	public float maxY = 80f;
   
    // Update is called once per frame
    void Update()

    {
        
		if (Input.GetKeyDown(KeyCode.Q))
			panToggle = !panToggle;

		if(!panToggle)
			return;
        
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBuffer)
		{
			transform.Translate(Vector3.forward * camPanSpeed * Time.deltaTime, Space.World);
		}
    
		if (Input.GetKey("s") || Input.mousePosition.y <= panBuffer)
		{
			transform.Translate(Vector3.back * camPanSpeed * Time.deltaTime, Space.World);
		}
	
		if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBuffer)
		{
			transform.Translate(Vector3.right * camPanSpeed * Time.deltaTime, Space.World);
		}

		if (Input.GetKey("a") || Input.mousePosition.x <= panBuffer)
		{
			transform.Translate(Vector3.left * camPanSpeed * Time.deltaTime, Space.World);
		}

		float scroll = Input.GetAxis("Mouse ScrollWheel");
	
		Vector3 pos = transform.position;

		pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
		pos.y = Mathf.Clamp (pos.y, minY, maxY);
		transform.position = pos;

    }
}
