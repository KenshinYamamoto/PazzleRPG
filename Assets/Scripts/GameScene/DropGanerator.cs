using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropGanerator : MonoBehaviour
{
    [SerializeField] GameObject[] drops;

    public IEnumerator Generate(int amount)
    {
        int count = 0;

        while(count < amount)
        {
            int ballID = Random.Range(0, drops.Length);
            Vector2 pos = new Vector2(Random.Range(-2.4f, 2.4f), 0);
            GameObject drop = Instantiate(drops[ballID], pos, Quaternion.identity);
            GameController.gameController.drops.Add(drop.GetComponent<DropController>());
            drop.transform.parent = GameController.gameController.dropParent;
            count++;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
