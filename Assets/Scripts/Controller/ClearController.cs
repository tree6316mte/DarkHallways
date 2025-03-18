using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearController : MonoBehaviour
{
    public string endingSceneName;
    public LayerMask playerLayer;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            SceneManager.LoadScene(endingSceneName);
        }
    }
}
