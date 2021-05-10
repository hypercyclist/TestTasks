using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Net;
using Random=UnityEngine.Random;

public class Path
{
    private List<Vector3> waypointsCoordinates;
    private int currentWaypointIndex;
    private bool loop;

    public Path()
    {
        waypointsCoordinates = new List<Vector3>();
        currentWaypointIndex = 0;
        loop = false;
    }

    public Path(string _path)
    {
        waypointsCoordinates = new List<Vector3>();
        currentWaypointIndex = 0;
        loop = false;
        if (_path.Substring(0, 3) == "ftp")
        {
            parseNetworkFile(_path);
        }
        else if (_path.Substring(0, 6) == "random")
        {
            generateRandomPath();
        }
        else
        {
            parseLocalFile(_path);
        }
    }

    private void parseNetworkFile(string _path)
    {
        WebClient request = new WebClient();
        request.Credentials = new NetworkCredential("anonymous", "anonymous@example.com");
        try
        {
            byte[] data = request.DownloadData(_path);
            string stringFromNetwork = System.Text.Encoding.UTF8.GetString(data);
            parseString(stringFromNetwork);
        }
        catch (WebException e)
        {
            Debug.Log(e);
        }
    }

    private void parseLocalFile(string _path)
    {
        TextAsset textAsset = (TextAsset)Resources.Load<TextAsset>(_path) as TextAsset;
        string stringFromFile = textAsset.ToString();
        parseString(stringFromFile);
    }

    private void parseString(string _longString)
    {
        if (_longString.Substring(0,4) == "loop")
        {
            _longString = _longString.Substring(6);
            loop = true;
        }
        for (int i = 0; i < _longString.Length; i++)
        {
            string x = "";
            string y = "";
            string z = "";

            while (_longString[i] != ',')
            {
                x += _longString[i];
                i++;
            }
            i++;
            while (_longString[i] != ',')
            {
                y += _longString[i];
                i++;
            }
            i++;
            while (_longString[i] != '\n')
            {
                z += _longString[i];
                i++;
            }
            // Debug.Log("x = " + x + "y = " + y + "z = " + z + "i = " + i);
            add( new Vector3(Int32.Parse(x), Int32.Parse(y), Int32.Parse(z)));
        }
    }

    public void generateRandomPath()
    {
        Vector3 coordinate = new Vector3(0, 0, -2);
        for (int i = 0; i < 5; i++)
        {
            bool solutionFounded = false;
            while (solutionFounded != true)
            {
                coordinate = new Vector3
                (
                    Random.Range(-10.0f, 10.0f), Random.Range(-7.0f, 7.0f), -2.0f
                );
                if (waypointsCoordinates.Count > 3)
                {
                    bool noIntersections = true;
                    for (int j = 0; j < waypointsCoordinates.Count - 2; j++)
                    {
                        if (lineIntersections(
                                waypointsCoordinates[j], 
                                waypointsCoordinates[j + 1], 
                                waypointsCoordinates[waypointsCoordinates.Count - 1], 
                                coordinate
                            )
                        )
                        {
                            noIntersections = false;
                        }
                    }
                    if (noIntersections)
                    {
                        solutionFounded = true;
                    }
                }
                else
                {
                    solutionFounded = true;
                }
            }
            add(coordinate);
        }
    }

    private bool lineIntersections(Vector3 a1, Vector3 a2, Vector3 b1, Vector3 b2)
    {
        float v1 = (b2.x - b1.x) * (a1.y - b1.y) - (b2.y - b1.y) * (a1.x - b1.x);
        float v2 = (b2.x - b1.x) * (a2.y - b1.y) - (b2.y - b1.y) * (a2.x - b1.x);
        float v3 = (a2.x - a1.x) * (b1.y - a1.y) - (a2.y - a1.y) * (b1.x - a1.x);
        float v4 = (a2.x - a1.x) * (b2.y - a1.y) - (a2.y - a1.y) * (b2.x - a1.x);
        return (v1 * v2 < 0) && (v3 * v4 < 0);
    }

    public void showPath()
    {
        Color color = new Color(1.0f, 1.0f, 1.0f);
        for(int i = 0; i < waypointsCoordinates.Count - 1; i++)
        {
            Debug.DrawLine(waypointsCoordinates[i], waypointsCoordinates[i + 1], color);
        }
    }

    public Vector3 getWaypointAt(int _index)
    {
        return waypointsCoordinates[_index];
    }

    public void add(Vector3 _waypoint)
    {
        waypointsCoordinates.Add(_waypoint);
    }

    public void removeAt(int _index)
    {
        waypointsCoordinates.RemoveAt(_index);
        checkValidCurrentWaypointIndex();
    }

    public int getCurrentWaypointIndex()
    {
        return currentWaypointIndex;
    }

    public Vector3 getCurrentWaypoint()
    {
        return getWaypointAt( getCurrentWaypointIndex() );
    }

    public void setCurrentWaypointIndex(int _index)
    {
        currentWaypointIndex = _index;
        checkValidCurrentWaypointIndex();
    }

    public void setCurrentWaypointIndexNext()
    {
        currentWaypointIndex++;
        checkValidCurrentWaypointIndex();
    }

    public void setLoop(bool _loop)
    {
        loop = _loop;
    }

    private void checkValidCurrentWaypointIndex()
    {
        if (loop)
        {
            currentWaypointIndex = currentWaypointIndex < waypointsCoordinates.Count
                ? currentWaypointIndex : 0;
        }
        else
        {
            currentWaypointIndex = currentWaypointIndex < waypointsCoordinates.Count
                ? currentWaypointIndex : waypointsCoordinates.Count - 1;
        }
    }
}
