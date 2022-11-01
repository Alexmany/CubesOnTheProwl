using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainScript : MonoBehaviour
{
    [SerializeField] private GameObject cube_prefab;
    [SerializeField] private Transform spawnPoint;

    [Space]
    public int speed;
    public int distance;
    public int respawn;

    [Space]
    [SerializeField] private TMP_InputField speed_InputField;
    [SerializeField] private TMP_InputField distance_InputField;
    [SerializeField] private TMP_InputField respawn_InputField;

    [Space]
    [SerializeField] private GameObject warning_panel;
    [SerializeField] private TMP_Text warning_ui;
    [SerializeField] private string[] warnings_texts;

    private float timer;

    void Start()
    {
        SpawnCube();
    }
    
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > respawn)
            SpawnCube();
    }

    void SpawnCube()
    {
        GameObject go = Instantiate(cube_prefab, spawnPoint.position, spawnPoint.rotation);

        go.GetComponent<CubeMover>().distance = distance;
        go.GetComponent<CubeMover>().speed = speed;

        timer = 0;
    }

    public void ChangeSpeed()
    {
        int current = int.Parse(speed_InputField.text);

        if(current >= 1)
        {
            speed = current;
        }            
        else if(current <= 0)
        {
            Warning(0);
            speed_InputField.text = 5.ToString();
            speed = 5;
        }
    }

    public void ChangeDistance()
    {
        int current = int.Parse(distance_InputField.text);

        if (current >= 10)
        {
            distance = current;
        }
        else if (current < 10)
        {
            Warning(1);
            distance_InputField.text = 10.ToString();
            distance = 10;
        }
    }

    public void ChangeRespawn()
    {
        int current = int.Parse(respawn_InputField.text);

        if (current >= 1)
        {
            respawn = current;
        }
        else if (current <= 0)
        {
            Warning(2);
            respawn_InputField.text = 2.ToString();
            distance = 2;
        }
    }

    void Warning(int i)
    {
        warning_panel.SetActive(true);
        warning_ui.text = warnings_texts[i];
    }
}