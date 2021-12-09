using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour
{
    public Camera GameCamera;
    public float PanSpeed = 10.0f;
    public GameObject Marker;
    
    private Animal selectedAnimal = null;

    private void Start()
    {
        Marker.SetActive(false);
    }

    private void Update()
    {
        CameraMovement();

        if (Input.GetMouseButtonDown(0))
        {
            HandleSelection();
        }
        else if (selectedAnimal != null && Input.GetMouseButtonDown(1))//right click give order to the unit
        {
            HandleAction();
        }

        MarkerHandling();
    }

    public void CameraMovement()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        GameCamera.transform.position = GameCamera.transform.position + new Vector3(move.y, 0, -move.x) * PanSpeed * Time.deltaTime;
    }

    public void HandleSelection()
    {
        Ray ray = GameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Animal currentAnimal = hit.collider.GetComponentInParent<Animal>();
            selectedAnimal = currentAnimal;

            if (selectedAnimal != null)
            {
                UIManager.Instance.SetAnimalName(selectedAnimal.animalName);
                selectedAnimal.IsSelected();
            }
            else
            {
                UIManager.Instance.SetAnimalName("");
            }

        }
    }

    public void HandleAction()
    {
        Ray ray = GameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Cage selectedCage = hit.collider.GetComponentInParent<Cage>();

            if (selectedCage != null)
            {
                selectedAnimal.GoTo(selectedCage);
            }
            else
            {
                selectedAnimal.GoTo(hit.point);
            }
        }
    }

    // Handle displaying the marker above the unit that is currently selected (or hiding it if no unit is selected)
    void MarkerHandling()
    {
        if (selectedAnimal == null && Marker.activeInHierarchy)
        {
            Marker.SetActive(false);
            Marker.transform.SetParent(null);
        }
        else if (selectedAnimal != null && Marker.transform.parent != selectedAnimal.transform)
        {
            Marker.SetActive(true);
            Marker.transform.SetParent(selectedAnimal.transform, false);
            Marker.transform.localPosition = Vector3.zero + new Vector3 (0, selectedAnimal.height, 0);
        }    
    }
}
