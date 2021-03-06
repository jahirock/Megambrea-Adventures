using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewPlace : MonoBehaviour
{
    public string newPlaceName = "New Scene Name Here";
    public string gotoPlaceName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            FindObjectOfType<PlayerController>().nextPlaceName = gotoPlaceName;

            SceneManager.LoadScene(newPlaceName);
        }
    }
}
