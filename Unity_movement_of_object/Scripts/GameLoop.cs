using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    MouseController mouseController;
    Observer observer;

    GameObject boyObject;
    GameObject userHelpObject;

    void Start()
    {
        mouseController = new MouseController();
        observer = new Observer();

        boyObject = GameObject.Find("Boy");
        Boy boy = boyObject.AddComponent<Boy>();

        userHelpObject = GameObject.Find("UserHelp");
        UserHelp userHelp = userHelpObject.AddComponent<UserHelp>();

        observer.addMouseEventsReceiver(boy);
        observer.addMouseEventsReceiver(userHelp);
        mouseController.addObserver(observer);
    }

    void Update()
    {
        mouseController.update();
        observer.sendEvents();
    }
}
