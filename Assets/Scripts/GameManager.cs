using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Slider healthSlider;
    public Slider hungerSlider;
    public Slider thirstSlider;
    public GameObject bunnyPrefab;

    [SerializeField] private float health, hunger, thirst;

    [SerializeField] private float hungerRate, thirstRate;

    [SerializeField] private float animalreleaseTimer;
    private float animalTimer;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        hunger = 100;
        thirst = 100;
    }

    // Update is called once per frame
    void Update()
    {
        hunger = hunger - hungerRate * Time.deltaTime;
        thirst = thirst - thirstRate * Time.deltaTime;

        healthSlider.value = health/100;
        hungerSlider.value = hunger/100;
        thirstSlider.value = thirst/100;

        if(hunger <= 0)
        {
            health -= .005f;
            hunger = 0;
        }
        
        if(thirst <=0)
        {
            health -= .005f;
            thirst = 0;
        }

        animalTimer -= Time.deltaTime;

        if(animalTimer <= 0)
        {
            animalTimer = animalreleaseTimer;
            Instantiate(bunnyPrefab, new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), 0) ,Quaternion.identity);
        }
    }

    public void AddFood(float food)
    {
        hunger += food;
        if(hunger >= 100)
        {
            hunger = 100;
        }
    }

    public void AddWater(float water)
    {
        thirst += water;
        if(thirst >= 100)
        {
            thirst = 100;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        #if UNITY_EDITOR

            UnityEditor.EditorApplication.isPlaying = false;

        #endif
            Application.Quit();
    }
}
