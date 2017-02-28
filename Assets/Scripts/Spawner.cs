using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public static Vector3 enemyPos;
    
    // Pieces
    public GameObject cartridge;
    
    // Checkmarks
    public Image firstCheck, secondCheck, thirdCheck;
    public Sprite checkmark;

    float Timer;
    float spawnDecrease = 0;

	void Start () {
        Timer = Time.timeSinceLevelLoad + 5f;
	}
	
	void Update () {
		if(Timer < Time.timeSinceLevelLoad)
        {
            var enemy = Instantiate(enemyPrefab);
            int choice = Random.Range(0, 2);
            if (choice == 1)
            {
                enemy.transform.position = new Vector3(0.5f, enemy.transform.position.y, enemy.transform.position.z);
            }

            if (spawnDecrease <= 6)
            {
                spawnDecrease += 0.3f;
            }

            Timer = Time.timeSinceLevelLoad + Random.Range(6f - (spawnDecrease), 18f - spawnDecrease);
        }

        // Pieces Spawning
        if (ChangingMenu.cartChanged)
        {
            Instantiate(cartridge);
            ChangingMenu.cartChanged = false;
            // Checkmarks
            var addFirst = firstCheck.GetComponent<Image>();
            addFirst.sprite = checkmark;
        }

        if (ChangingMenu.cartFilled)
        {
            Instantiate(cartridge);
            ChangingMenu.cartFilled = false;
            var addSecond = secondCheck.GetComponent<Image>();
            addSecond.sprite = checkmark;
        }

        if (ChangingMenu.cannulaFinished)
        {
            Instantiate(cartridge);
            ChangingMenu.cannulaFinished = false;
            var addThird = thirdCheck.GetComponent<Image>();
            addThird.sprite = checkmark;
        }
    }
}
