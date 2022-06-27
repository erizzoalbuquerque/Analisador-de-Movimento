using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Markers : MonoBehaviour, IResetable
{
    public Transform target;
    public float period = 1f;
    public Color color = Color.black;
    public Sprite sprite = null;
    public float size = 0.1f;

    private float timer;

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
        marker.transform.parent = this.transform;

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

        for (int i=0;i<this.transform.childCount;i++)
        {
            children.Add(this.transform.GetChild(i).gameObject);
        }

        foreach(GameObject child in children)
        {
            Destroy(child);
        }
    }
}
