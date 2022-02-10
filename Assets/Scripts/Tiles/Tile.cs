using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor, _trackColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private GameObject _greenT;
    [SerializeField] private Component _towerTile;

    

    public void Init(bool isOffset, bool isTrack) 
    {
        if (isTrack)
            _renderer.color = _trackColor;
        else _renderer.color = isOffset ? _offsetColor : _baseColor;

    }

    private void OnMouseDown()
    {
        _greenT.SetActive(true);
        gameObject.GetComponent<TowerTile>().enabled  = true;
    }

    private void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }
    private void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}
