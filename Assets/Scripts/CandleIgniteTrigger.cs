using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CandleIgniteTrigger : MonoBehaviour
{
    [SerializeField] private GameObject flame;
    [SerializeField] private GameObject lanternsOff;    
    [SerializeField] private GameObject lanternsOn;
    [SerializeField] private GameObject bookOff;    
    [SerializeField] private GameObject bookOn;    

    private bool isLit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isLit) return;

        if (other.CompareTag("Lighter"))
        {
            flame.SetActive(true);
	    lanternsOff.SetActive(false);
            lanternsOn.SetActive(true);
            bookOff.SetActive(false);
            bookOn.SetActive(true);
            isLit = true;
        }
    }
}