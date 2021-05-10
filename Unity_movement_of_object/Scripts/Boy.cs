using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : MGameObject
{
    private float speed;
    private Path pathFromCode;
    private Path pathFromFile;
    private Path pathfromNetwork;
    private Path pathFromRandom;

    int stepsIndex;

    public override void getMouseEvent(MouseEvent _mouseEvent)
    {
        switch (stepsIndex)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4: pathFromCode.add(_mouseEvent.worldPosition); break;
            case 5:
            case 7:
            case 9:
            case 11: transform.position = new Vector3(0, 0, -2); break;
            default: break;
        }
        stepsIndex++;
    }

    public void walk(Path _path)
    {
        if ( transform.position == _path.getCurrentWaypoint() )
        {
            _path.setCurrentWaypointIndexNext();
        }
        transform.position = Vector3.MoveTowards
        (
            transform.position, 
            _path.getCurrentWaypoint(), 
            speed * Time.deltaTime
        );
        _path.showPath();
    }

    void Start()
    {
        speed = 5.0f;
        pathFromCode = new Path();
        pathFromFile = new Path("pathFromFile");
        pathfromNetwork = new Path("ftp://193.9.61.92/pathFromNetwork.txt");
        pathFromRandom = new Path("random");
        stepsIndex = 0;
    }

    void Update()
    {
        switch (stepsIndex)
        {
            case 5: walk(pathFromCode); break;
            case 7: walk(pathFromFile); break;
            case 9: walk(pathfromNetwork); break;
            case 11: walk(pathFromRandom); break;
            default: break;
        }
    }
}
