using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine.XR.ARFoundation;
using TMPro;
using UnityEngine.UI;


[System.Serializable]
public class PlanetPrefabDictionary :
SerializableDictionaryBase<string, GameObject>{ }

public class PlanetsMainMode : MonoBehaviour
{
    [SerializeField]
    PlanetPrefabDictionary planetPrefabs;
    [SerializeField]
    ARTrackedImageManager imageManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (imageManager.trackables.count == 0)
        {
            InteractionController.EnableMode("Scan");
        }
    }

    private void OnEnable()
    {
        UIController.ShowUI("Main");
        foreach (ARTrackedImage image in imageManager.trackables)
        {
            InstantiatePlanet(image);
        }
        imageManager.trackedImagesChanged +=  OnTrackedImageChanged;

    }

    void InstantiatePlanet(ARTrackedImage image)
    {
        string name =
        image.referenceImage.name.Split('-')[0];
        if (image.transform.childCount == 0)
        {
            GameObject planet =
            Instantiate(planetPrefabs[name]);
            planet.transform.SetParent(image.transform,
            false);
        }
        else
        {
            Debug.Log($"{name} already instantiated");
        }
    }

    void OnTrackedImageChanged (ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage newImage in
        eventArgs.added)
        {
            InstantiatePlanet(newImage);
        }
    }

    void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnTrackedImageChanged;
    }
}