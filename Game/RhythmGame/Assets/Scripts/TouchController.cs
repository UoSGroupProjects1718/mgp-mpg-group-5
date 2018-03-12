using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    Vector3 touchWorldPos;

    TouchPhase touchPhase = TouchPhase.Ended;

	void Update ()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    touchWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //    Vector2 touchWorldPos2D = new Vector2(touchWorldPos.x, touchWorldPos.y);

        //    RaycastHit2D hit = Physics2D.Raycast(touchWorldPos2D, Camera.main.transform.forward);

        //    if (hit.collider != null && hit.collider.tag == "PlayerOneTag")
        //    {
        //        GameObject touchedNode = hit.transform.gameObject;
        //        Destroy(touchedNode);
        //    }
        //    else if (hit.collider != null && hit.collider.tag == "PlayerTwoTag")
        //    {
        //        GameObject touchedNode = hit.transform.gameObject;
        //        Destroy(touchedNode);
        //    }
        //}



        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == touchPhase)
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 100f);

            if (hit.collider != null)
            {
                if (hit.collider != null && hit.transform.gameObject.tag == "PlayerOneTag")
                {
                    GameObject touchedNode = hit.transform.gameObject;
                    print("Touched 1 " + touchedNode.gameObject.name);
                    Destroy(touchedNode);
                }
                else if (hit.collider != null && hit.transform.gameObject.tag == "PlayerTwoTag")
                {
                    GameObject touchedNode = hit.transform.gameObject;
                    print("Touched 2 " + touchedNode.gameObject.name);
                    Destroy(touchedNode);
                }
            }


            /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics2D.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;

                // Do something with the object that was hit by the raycast.

                if (hit.collider != null && hit.collider.tag == "PlayerOneTag")
                {
                    GameObject touchedNode = hit.transform.gameObject;
                    print("Touched 1 " + touchedNode.gameObject.name);
                    Destroy(touchedNode);
                }
                else if (hit.collider != null && hit.collider.tag == "PlayerTwoTag")
                {
                    GameObject touchedNode = hit.transform.gameObject;
                    print("Touched 2 " + touchedNode.gameObject.name);
                    Destroy(touchedNode);
                }

            }*/
        }
	}
}
