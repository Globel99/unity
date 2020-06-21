using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaRotation : MonoBehaviour
{   
    Vector3 axis = new Vector3(0, 0, 1);
    Vector2 player;
    PolygonCollider2D collider;

    Vector2 playerToArea = new Vector2(0, -2);
    Vector2 playerToPoint;
    Vector2[] areaEdges = new Vector2[2];

    float angle;

    void Start()
    {
        collider = gameObject.GetComponent<PolygonCollider2D>(); 
    }

    void Update()
    {
        
    }

    public void setPlayerPosition(Vector2 _player)
    {
        this.player = _player;
    }

    void setAreaEdges()
    {
        for(int i=0;i<2;i++)
        {
            areaEdges[i] = transform.TransformPoint(collider.points[i+1]);
        }
    }

    public void Rotate(Vector2 _point)
    {
        //régi vektor a player és area között
        playerToArea = new Vector2(transform.position.x - player.x, transform.position.y - player.y);
        
        //új vektor a player és az input között, ide fordul az area
        playerToPoint  = new Vector2(_point.x - player.x, _point.y - player.y);
        
        //régi - új vektor szög
        angle = Vector2.SignedAngle(playerToArea, playerToPoint);

        //area forgatás
        transform.RotateAround(player, axis, angle);
        Debug.DrawLine(player, player + playerToArea, Color.red);

        //edge forgatás
        setAreaEdges();
        DrawLinesFromPlayer(areaEdges, Color.red);
    }

    void DrawLinesFromPlayer(Vector2[] targets, Color color)
    {
        foreach(Vector2 target in targets)
        {
            Debug.DrawLine(player, target, color);
        }
    }
}
