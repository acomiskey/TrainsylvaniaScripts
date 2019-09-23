using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossFinder : MonoBehaviour
{
   Camera cam;
   public int viewlength;
   public Material highlightMaterial;
   Material original;
   GameObject lastHighlighted;

    void HighlightObject(GameObject obj)
    {
        if(lastHighlighted != obj)
        {
            ClearHighlighted();
            original = obj.GetComponent<MeshRenderer>().sharedMaterial;
            obj.GetComponent<MeshRenderer>().sharedMaterial = highlightMaterial;
            lastHighlighted = obj;
        }
    }

    void ClearHighlighted()
    {
        if (lastHighlighted != null)
        {
            lastHighlighted.GetComponent<MeshRenderer>().sharedMaterial = original;
            lastHighlighted = null;
        }
    }

    void Inspect(string name)
    {
        string output = "";
        switch (name)
        {
            case "Cube": output = "A cube... nothing much to see here."; break;
            default: output = "I don't know what the fuck this is."; break;
        }

        FindObjectOfType<QuipSupplier>().getTalking(output);
    }

    void Interact(string name)
    {
        string output = "";
        switch (name)
        {
            case "Cube": GameObject.Find("Cube").SetActive(false); output = "[ Picked up the CUBE. ]";  FindObjectOfType<InvControl>().addObject("cube");  break;
            case "vendingmachinetex": GameObject.Find("vendingmachinetex").SetActive(false); output = "[ Picked up the.... VENDING MACHINE? ]"; break;
            default: output = "I don't think I can use this."; break;
        }

        FindObjectOfType<QuipSupplier>().getTalking(output);
    }
    // Start is called before the first frame update
    void Start()
    {
        viewlength = 7;
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2));
       if(Physics.Raycast(ray, out hit, viewlength))
        {
            if (hit.collider.gameObject.tag == "selectable")
            {
                GameObject hitone = hit.collider.gameObject;
                HighlightObject(hitone);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    Inspect(hitone.name);
                }

                if(Input.GetKeyDown(KeyCode.F))
                {
                    Interact(hitone.name);
                }
            }
            else
            {
                ClearHighlighted();
            }
        }
        else
        {
            ClearHighlighted();
        }
    }
}
