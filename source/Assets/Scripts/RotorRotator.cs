using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class RotorRotator : MonoBehaviour
{
    private Camera mainCamera;
    private BoxCollider collider;
    [SerializeField] private RotorSlot rotorSlot;
    
    public bool IsClicked
    {
        private set;
        get;
    }

    private float clickOriginY = 0;

    private int desiredOffset = 0;
    private int currentOffset = 0;
    
    void Start()
    {
        mainCamera = Camera.main;
        collider = GetComponent<BoxCollider>();

        transform.Rotate(0f, -5f, 0f);
    }
    
    void Update()
    {

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //bool anyKeyboardKey = Input.anyKey && !Input.GetMouseButton(0);
        if(Input.GetMouseButtonDown(0) && Physics.Raycast (ray, out hit) && hit.collider == collider)
        {
            IsClicked = true;
            clickOriginY = Input.mousePosition.y;

        }
        
        if (Input.GetMouseButtonUp(0))
        {
            IsClicked = false;
            rotorSlot.OffSet = currentOffset;
            //Debug.Log("Zmieniam w rotor na " + currentOffset);
        }
        

        if (IsClicked)
            UpdateOffsetMouse();
            
        Rotate();
    }


    void UpdateOffsetMouse()
    {
        float dy = (clickOriginY - Input.mousePosition.y) / Screen.height;

        desiredOffset = (desiredOffset - (int)(dy * 26)) % 26;
        if (desiredOffset != currentOffset)
            clickOriginY = Input.mousePosition.y;
    }

    public void UpdateOffSetDirectly(int offset)
    {
        desiredOffset = offset;
    }
    
    void Rotate()
    {
        transform.Rotate(0, 13.84615f * (desiredOffset - currentOffset), 0, relativeTo:Space.Self);
        currentOffset = desiredOffset;
    }
}
