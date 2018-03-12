using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    Vector3 touchWorldPos;

    TouchPhase touchPhase = TouchPhase.Began;

	void Update ()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == touchPhase)
        {
            touchWorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            Vector2 touchWorldPos2D = new Vector2(touchWorldPos.x, touchWorldPos.y);

            RaycastHit2D hit = Physics2D.Raycast(touchWorldPos2D, Camera.main.transform.forward);

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
            print("Touched");
        }
	}
}
