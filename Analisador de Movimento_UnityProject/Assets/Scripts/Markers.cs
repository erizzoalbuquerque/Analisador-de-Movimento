using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Markers : MonoBehaviour, IResetable
{
    [SerializeField] Transform target;
    [SerializeField] Transform markersParent;
    [SerializeField] float period = 1f;
    [SerializeField] Color color = Color.black;
    [SerializeField] Sprite sprite = null;
    [SerializeField] float size = 0.1f;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer >= period)
        {
            CreateMarker();
            timer = 0f;
        }

        timer += Time.fixedDeltaTime;
    }

    void CreateMarker()
    {
        GameObject marker = new GameObject("marker");

        marker.transform.position = target.position;
        marker.transform.rotation = target.rotation;
        marker.transform.localScale = Vector3.one * size;
        marker.transform.parent = markersParent;

        SpriteRenderer spriteRenderer = marker.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        spriteRenderer.color = color;
        spriteRenderer.sprite = sprite;
    }

    public void Reset()
    {
        CreateMarker();
        timer = 0;
    }

    public void ClearMarkers()
    {
        List<GameObject> children = new List<GameObject>();

        for (int i=0;i<markersParent.childCount;i++)
        {
            children.Add(markersParent.GetChild(i).gameObject);
        }

        foreach(GameObject child in children)
        {
            Destroy(child);
        }
    }
}
