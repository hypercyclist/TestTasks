using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController
{
    Observer observer;

    public MouseController()
    {
    }

    public void addObserver(Observer _observer)
    {
        observer = _observer;
    }

    public void update()
    {
        if (observer == null)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            observer.getMouseCommand( 
                new MouseEvent(
                    Camera.main.ScreenToWorldPoint(Input.mousePosition)
                )
            );
        }
    }
}
