using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    [SerializeField] GameObject playerHealthBar;
    [SerializeField] RectTransform content;
    [SerializeField] GameObject HealthBarPrefab;

    void OnEnable() {
        //update player hp
        BaseCharacter player = GameObject.FindGameObjectWithTag("Player").GetComponent<BaseCharacter>();

        int playerHP = player.Health;

        RectTransform playerHPImage = playerHealthBar.GetComponent<RectTransform>();

        playerHPImage.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, 140 * playerHP / 100);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        //find and instantiate enemy health bars

        for (int i = 0; i < enemies.Length; i++) {
            Enemy enemy = enemies[i].GetComponent<Enemy>();
            int enemyHP = enemy.Health;

            GameObject enemyHPBar = Instantiate(HealthBarPrefab);

            enemyHPBar.transform.SetParent(content.transform, false);

            RectTransform enemyRect = enemyHPBar.GetComponent<RectTransform>();

            enemyRect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 30 + i * 50, 40);

            if(enemyHPBar != null){
                //get image rect
                RectTransform enemyHPImage = enemyHPBar.transform.GetChild(1).GetChild(0).gameObject.GetComponent<RectTransform>();

                if(enemyHPImage != null){
                    enemyHPImage.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, 140 * enemyHP / 100);
                }
            }

        }
    }
    // free the content when closed
    void OnDisable() {
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
