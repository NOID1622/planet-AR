using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ImageInfo
{
    public Texture texture;
    public int width;
    public int height;
}
public class ImagesData : MonoBehaviour
{
    public ImageInfo[] images;
}
