using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("HideDelay");
    }

    private IEnumerator HideDelay()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

   
    
}
