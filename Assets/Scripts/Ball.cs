using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball :MonoBehaviour, IClicObject
{
    
    [SerializeField] private Color[] _colors;
    private MeshRenderer _renderer;
    private int _actualColor = -1;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        ColorChange();
        Debug.Log(_colors[2]);
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void ClicOnObject() { ColorChange(); }
    private void ColorChange() {

        _actualColor++;
        if (_actualColor >= _colors.Length)
        {
            _actualColor = 0;
        }
        _renderer.material.color = _colors[_actualColor];
        Debug.Log("cliclicclic");
    }

    
}
