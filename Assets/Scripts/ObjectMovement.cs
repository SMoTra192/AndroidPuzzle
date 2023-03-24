using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))] 
[RequireComponent(typeof(BoxCollider2D))]

public class ObjectMovement : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Camera mainCamera;
    Vector3 offset;
    [SerializeField] private GameObject tempObject,positionToPoint;
    [SerializeField] private Transform PoolOfItemsParent,TempFolderParent;
    [SerializeField] private float multiplicatorSize = 4;
    private Vector3 position;
    
    void Awake()
    {
        gameObject.transform.position = positionToPoint.transform.position;
        mainCamera = Camera.allCameras[0];
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //if (OnEnablePoolImage.isEnable == true)
        {
            tempObject.transform.position = gameObject.transform.position;
            position = gameObject.transform.position;
            offset = transform.position - mainCamera.ScreenToWorldPoint(eventData.position);
            //GetComponent<CanvasGroup>().blocksRaycasts = false;//
            tempObject.transform.SetParent(PoolOfItemsParent);
            transform.SetParent(TempFolderParent);
            //tempObject.transform.SetSiblingIndex(transform.GetSiblingIndex());//
            gameObject.transform.localScale *= multiplicatorSize;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //if (OnEnablePoolImage.isEnable == true)
        {
            Vector3 newPos = mainCamera.ScreenToWorldPoint(eventData.position);
            Vector3 upp = new Vector3(0, 1.5f);
            transform.position = newPos;
            transform.position = newPos + offset + upp;
        }
    }




    public void OnEndDrag(PointerEventData eventData)
    {
        //if (OnEnablePoolImage.isEnable == true)
        {
            transform.SetParent(PoolOfItemsParent);
            //transform.SetSiblingIndex(tempObject.transform.GetSiblingIndex());//
            transform.position = positionToPoint.transform.position;
            tempObject.transform.SetParent(TempFolderParent);
            tempObject.transform.position = TempFolderParent.position;
            gameObject.transform.localScale /= multiplicatorSize;
        }
    }

}