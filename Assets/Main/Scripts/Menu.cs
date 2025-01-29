using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button scene01Button;
    [SerializeField] private Button scene05Button;

    [SerializeField] private string scene01Name;
    [SerializeField] private string scene05Name;

    private void Start()
    {
        scene01Button.onClick.AddListener(() => SceneManager.LoadScene(scene01Name));
        scene05Button.onClick.AddListener(()=>  SceneManager.LoadScene(scene05Name));
    }
}
