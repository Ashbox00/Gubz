using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    [Header("Card Positioning")]
    [SerializeField] private SortingMode _SortingMode = SortingMode.Horizontal;
    [SerializeField] public int CardLimit = 4;
    [Header("Box Collider Visualization")]
    [SerializeField] private bool _VisibleBounds = false;
    [SerializeField] private GameObject _BaseVisualizationObject = null;

    private enum SortingMode
    {
        Horizontal,
        Vertical
    };

    private BoxCollider _BoxCollider = null;
    private GameObject _BoundVis = null;

    public void OrganizeChildren()
    {
        List<GameObject> children = GetChildren();

        int count = children.Count;
        if (count == 0)
        {
            return;
        }

        Vector3 size = children[0].GetComponent<BoxCollider>().bounds.size;

        float half = count / 2.0f;

        float step = 1.1f * size.x;
        Vector3 direction = new(1, 0, 0);

        if (_SortingMode == SortingMode.Vertical)
        {
            step = 1.1f * size.z;
            direction = new(0, 0, 1);
        }

        float offset = (count - 1) * step / 2.0f;

        for (int i = 0; i < count; i++)
        {
            Vector3 pos = (-offset + i * step) * direction;
            children[i].transform.localPosition = pos;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        _BoxCollider = GetComponent<BoxCollider>();

        if (_VisibleBounds && _BaseVisualizationObject != null)
        {
            _BoundVis = Instantiate<GameObject>(_BaseVisualizationObject);
            _BoundVis.transform.SetParent(this.transform);
            _BoundVis.transform.localPosition = Vector3.zero;
            _BoundVis.transform.localScale = _BoxCollider.bounds.size;
            _BoundVis.SetActive(true);
        }
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private List<GameObject> GetChildren()
    {
        List<GameObject> children = new();
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject obj = transform.GetChild(i).gameObject;
            if (obj != _BoundVis)
            {
                children.Add(obj);
            }
        }
        return children;
    }

    private void OnTriggerEnter(Collider other)
    {
        List<GameObject> children = GetChildren();
        if (children.Count < CardLimit)
        {
            Region old = other.GetComponentInParent<Region>();
            other.gameObject.transform.SetParent(this.transform);
            if (old != null)
            {
                old.OrganizeChildren();
            }
        }
    }
}
