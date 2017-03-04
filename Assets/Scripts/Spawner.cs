using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public static Vector3 enemyPos;
    public static float accelerator= 0.3f;
    
    // Pieces
    float cartTimer;
    float trash = 0;
    public GameObject trash1;
    public GameObject trash2;
    public GameObject trash3;
    
    // Checkmarks
    public Image firstCheck, secondCheck, thirdCheck;
    public Sprite checkmark;

    float Timer;
    float spawnDecrease = 0;

	void Start () {
        Timer = Time.timeSinceLevelLoad + 5f;
        cartTimer = Time.timeSinceLevelLoad + 8f;
        accelerator = 50f;
	}
	
	void Update () {
		if(Timer < Time.timeSinceLevelLoad)
        {
            var enemy = Instantiate(enemyPrefab);
            int choice = Random.Range(0, 2);
            if (choice == 1)
            {
                enemy.transform.position = new Vector3(193, enemy.transform.position.y, enemy.transform.position.z);
            }

            if (spawnDecrease <= 6.4f)
            {
                spawnDecrease += 0.4f;
            }

            Timer = Time.timeSinceLevelLoad + Random.Range(6.8f - (spawnDecrease), 11.4f - spawnDecrease);
            accelerator += 15f;

        }

        // Pieces Spawning
        if(cartTimer < Time.timeSinceLevelLoad)
        {
            if(trash == 0)
            {
                var piece = Instantiate(trash1);
                trash++;
            } else if(trash == 1)
            {
                var piece = Instantiate(trash2);
                trash++;
            } else
            {
                var piece = Instantiate(trash3);
                trash = 0;
            }
            cartTimer = Time.timeSinceLevelLoad + Random.Range(7f, 18f);
        }

        // Checkmarks
        if (ChangingMenu.cartChanged)
        {
            ChangingMenu.cartChanged = false;
            var addFirst = firstCheck.GetComponent<Image>();
            addFirst.sprite = checkmark;
        }

        if (ChangingMenu.cartFilled)
        {
            ChangingMenu.cartFilled = false;
            var addSecond = secondCheck.GetComponent<Image>();
            addSecond.sprite = checkmark;
        }

        if (ChangingMenu.cannulaFinished)
        {
            ChangingMenu.cannulaFinished = false;
            var addThird = thirdCheck.GetComponent<Image>();
            addThird.sprite = checkmark;
        }
    }
}
