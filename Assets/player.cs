using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    Transform one;
    Transform two;
    bool pr;
    bool po;

	// Use this for initialization
	void Start () {
        pr = false;
        po = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                //Component halo1;
                //Component halo2;

                if (!pr)
                {
                    one = hitInfo.transform;
                    //halo1 = one.GetComponent("Halo");
                    //halo1.GetType().GetProperty("enabled").SetValue(halo1, true, null);
                    pr = true;
                }
                else if (!po)
                {
                    two = hitInfo.transform;
                    //halo2 = two.GetComponent("Halo");
                    //halo2.GetType().GetProperty("enabled").SetValue(halo2, true, null);
                    po = true;
                }
                else
                {
                    one = two;
                    two = hitInfo.transform;
                }

                if (po && pr)
                {  

                    if (one.gameObject.tag == "V" || two.gameObject.tag == "V")
                    {
                        // Switch
                        Vector3 vpos = one.position;
                        Vector3 rpos = two.position;

                        one.position = rpos;
                        two.position = vpos;
                        po = false;
                        pr = false;
                    }
                    else
                    {
                        Debug.Log("Can't switch two regular cubes");
                        po = false;
                        pr = false;
                    }
              }
            }
        }
    }
}
