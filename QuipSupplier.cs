using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuipSupplier : MonoBehaviour
{
    public Text outstring;
    // Start is called before the first frame update
    void Start()
    {
    }

     public void getTalking(string whatchasay)
    {
        outstring.text = whatchasay;
        Invoke("cleartext", 5);
    }

    public void cleartext()
    {
        outstring.text = "";
    }
}
