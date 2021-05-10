using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer
{
    List<MouseEvent> mouseEventsQueue;
    List<MGameObject> mouseEventsReceivers;

    public Observer()
    {
        mouseEventsQueue = new List<MouseEvent>();
        mouseEventsReceivers = new List<MGameObject>();
    }

    public void addMouseEventsReceiver(MGameObject _mGameObject)
    {
        mouseEventsReceivers.Add(_mGameObject);
    }

    public void getMouseCommand(MouseEvent _mouseEvent)
    {
        mouseEventsQueue.Add(_mouseEvent);
    }

    public void sendEvents()
    {
        for (int i = 0; i < mouseEventsQueue.Count; i++)
        {
            for(int j = 0; j < mouseEventsReceivers.Count; j++)
            {
                mouseEventsReceivers[j].getMouseEvent(mouseEventsQueue[i]);
            }
            mouseEventsQueue.RemoveAt(i);
        }
    }
}
