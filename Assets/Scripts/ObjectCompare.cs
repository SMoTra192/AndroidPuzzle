using System;
using UnityEngine;

public class ObjectCompare : MonoBehaviour
{
    [SerializeField] private GameObject tempObject,inGameSceneObject;
    [SerializeField] private Transform tempfolder,inGameObjectFolder;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private ParticleSystem particle;
    
    private string tagName;
    
    
    

    private void Awake()
    {
        _audioSource.GetComponent<AudioSource>();
        tagName = inGameObjectFolder.tag;
    }

    
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(tagName))
        {
            Destroy(gameObject);
            tempObject.transform.SetParent(tempfolder);
            tempObject.transform.position = tempfolder.transform.position;
            inGameSceneObject.SetActive(true);
            particle.transform.position = inGameSceneObject.transform.position;
            particle.Play();
            _audioSource.PlayOneShot(_audioSource.clip);
            RandomEnableImages.isImageSet = true;
        }
    }
    
}
