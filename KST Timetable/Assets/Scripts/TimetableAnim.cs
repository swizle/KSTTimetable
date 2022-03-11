using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimetableAnim : MonoBehaviour
{
    private Animator anim;
    private bool Isopen = false; 
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    public void OpenPan()
    {
        anim.SetInteger("RaspisanieOpen", 1);

    }
    public void ClosePan()
    {
        anim.SetInteger("RaspisanieOpen", 0);
    }
}
