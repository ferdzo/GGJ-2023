using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour
{
    public void Back2Main () {
      SceneManager.LoadScene(0);
    }
}
