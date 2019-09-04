using UnityEngine;

public class Waypoints : MonoBehaviour
{
   //an array of game objects for Waypoints
   public static Transform[] points;

   //load the points into the Transform [] array
   void Awake ()
   {
	points = new Transform[transform.childCount];
	for (int i = 0; i < points.Length; i++) 
	{
		points[i] = transform.GetChild(i);
	}

   }
   

}
