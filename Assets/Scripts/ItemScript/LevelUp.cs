using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUi : MonoBehaviour
{
    public GameObject levelUpPanel;
    public GameObject LevelFront;
    private float levelExp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelExp += Time.deltaTime;
        LevelFront.transform.localScale = new Vector3(levelExp / 10f, 1f, 1f);

        if (LevelFront.transform.localScale.x >= 1)
        {
            levelExp -= 10f;
            Time.timeScale = 0;
            levelUpPanel.SetActive(true);
        }
    }
}
