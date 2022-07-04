using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject countdownText;
    [SerializeField] DropGanerator dropGenerator;
    [SerializeField] List<DropController> removeDrops = new List<DropController>(); // �폜����h���b�v��c������
    [SerializeField] GameObject menuButton;
    DropController currentDraggingDrop;
    public List<DropController> drops = new List<DropController>(); // �Ֆʂɂ���S�Ẵh���b�v��c������
    public Transform dropParent;
    public string homeScene;
    public bool isOperateDrops = true;
    public bool gameOver = false;
    bool isDragging;
    bool isCalled;

    public static GameController gameController;
    private void Awake()
    {
        gameController = this;
    }

    void Start()
    {
        countdownText.SetActive(false);
        StartCoroutine(dropGenerator.Generate(45));
        AudioManager.audioManager.PlayBGM(AudioManager.BGM.Game);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnDragBegin();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnDragEnd();
        }
        else if (isDragging)
        {
            OnDragging();
        }
    }

    void OnDragBegin()
    {
        if (!IsOperateFlag() || IsGameOverFlag())
        {
            return;
        }

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit && hit.collider.GetComponent<DropController>())
        {
            DropController drop = hit.collider.GetComponent<DropController>();
            AddRemoveDrop(drop);
            isDragging = true;
        }
    }

    void OnDragging()
    {
        if (!IsOperateFlag() || IsGameOverFlag())
        {
            return;
        }

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit && hit.collider.GetComponent<DropController>())
        {
            DropController drop = hit.collider.GetComponent<DropController>();

            if (drop.id == currentDraggingDrop.id) // ������ނ�������
            {
                float distance = Vector2.Distance(drop.transform.position, currentDraggingDrop.transform.position);
                if (distance < ParamsSO.Entity.dropRemoveDistance) // �������߂�������
                {
                    AddRemoveDrop(drop);
                }
            }
        }
    }

    void OnDragEnd()
    {
        if (removeDrops.Count >= 3)
        {
            for (int i = 0; i < removeDrops.Count; i++)
            {
                drops.Remove(removeDrops[i]);
                Destroy(removeDrops[i].gameObject);
            }
            AudioManager.audioManager.PlaySE(AudioManager.SE.CrashDrops);
            StartCoroutine(dropGenerator.Generate(removeDrops.Count));
            CalculateController.calculateController.Calculation(removeDrops[0].GetComponent<DropController>().id, removeDrops.Count);
        }
        ClearDrops();
        isDragging = false;
    }

    void AddRemoveDrop(DropController drop)
    {
        currentDraggingDrop = drop;
        if (!removeDrops.Contains(drop))
        {
            AudioManager.audioManager.PlaySE(AudioManager.SE.DraggingDrops);
            drop.transform.localScale = Vector3.one * ParamsSO.Entity.touchDropSize;
            removeDrops.Add(drop);
            if(!isCalled && removeDrops.Count >= 3)
            {
                StartCoroutine(Countdown());
                isCalled = true;
            }
        }
    }

    bool IsOperateFlag()
    {
        return isOperateDrops;
    }

    bool IsGameOverFlag()
    {
        return gameOver;
    }

    IEnumerator Countdown()
    {
        countdownText.SetActive(true);
        menuButton.GetComponent<Button>().enabled = false;
        int count = 5;
        while(count >= 0)
        {
            countdownText.GetComponent<Text>().text = count.ToString();
            count--;
            yield return new WaitForSeconds(1f);
        }
        ClearDrops();
        StartCoroutine(CalculateController.calculateController.FromPlayerToEnemyAttack());
        countdownText.SetActive(false);
        isOperateDrops = false;
    }

    public void EnemyTurn()
    {
        BattleManager.battleManager.EnemyAttack();
        Invoke("ResetOperation", 1f);
    }

    void ClearDrops()
    {
        for (int i = 0; i < removeDrops.Count; i++)
        {
            removeDrops[i].transform.localScale = Vector3.one * 0.7f;
        }
        removeDrops.Clear();
    }

    void ResetOperation()
    {
        isOperateDrops = true;
        isCalled = false;
        menuButton.GetComponent<Button>().enabled = true;
    }

    public IEnumerator ToHomeScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(homeScene);
    }
}
