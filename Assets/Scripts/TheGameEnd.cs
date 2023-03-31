using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TheGameEnd : MonoBehaviour
{
    [SerializeField] private GameObject poolOfItemsFolder,
        effectOnEnd1, effectOnEnd2, effectOnEnd3,
        hintImage, hints,
        Bar,
        itemsOnSceneFolder,sticker;

    [SerializeField] private Button[] buttonToOn;
    [SerializeField] private GameObject[] images;
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource _source;
    [SerializeField] private GameObject valueOfCompletedLevels;
    private GameLoadManager _gameLoadManager;
    private bool isImageOn = false;


    private void Awake()
    {
        _gameLoadManager = gameObject.GetComponent<GameLoadManager>();
        
    }

    private void FixedUpdate()
    {
        
        if (poolOfItemsFolder.transform.childCount == 0)
        {
            Destroy(hints);
            hintImage.SetActive(false);
            Bar.SetActive(false);
           if (isImageOn == false) StartCoroutine(Image());
           effectOnEnd1.SetActive(true);
            effectOnEnd2.SetActive(true);
        }
        
    }

    private IEnumerator Image()
    {
        int level_number = _gameLoadManager.levelNumber();
        int level_count = _gameLoadManager.levelCount();
        int level_loop = _gameLoadManager.levelLoop();
        string level_name = _gameLoadManager.levelName();
        string finish = "finished";
        bool level_random = _gameLoadManager.levelRandom();
        _gameLoadManager.level_finish(level_number, level_name, level_count, level_loop, level_random, finish);
        int random = Random.Range(0, images.Length);
        images[random].SetActive(true);
        isImageOn = true;
        itemsOnSceneFolder.SetActive(false);
        sticker.SetActive(true);
        yield return new WaitForSeconds(2f);
        images[random].SetActive(false);
        yield return new WaitForSeconds(1f);
        effectOnEnd3.SetActive(true);
        Points.isTheGameEnd = true;
        _source.PlayOneShot(clip);
        yield return new WaitForSeconds(1f);
        valueOfCompletedLevels.SetActive(true);
        foreach (var button in buttonToOn)
        {
            button.gameObject.SetActive(true);
        }
    }
    
}
