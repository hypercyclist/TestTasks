using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserHelp : MGameObject
{
    private TextArray textArray;
    private Text textElement;
    int stepsIndex;

    public override void getMouseEvent(MouseEvent _mouseEvent)
    {
        stepsIndex++;
        if (stepsIndex < 5)
        {
            return;
        }
        textArray.setTextValueIndexNext();
        textElement.text = textArray.getText();
    }

    void Start()
    {
        textArray = new TextArray();
        textArray.add("Нажми Левой кнопкой мыши 5 раз для составления пути перемещения.");
        textArray.add("Смотрим на результат. Движемся по пути.");

        textArray.add("Нажми Левой кнопкой мыши 1 раз для перемещения по координатам из файла.");
        textArray.add("Смотрим на результат. Движемся по пути. Он зациклен.");

        textArray.add("Нажми Левой кнопкой мыши 1 раз для перемещения по координатам из сети.");
        textArray.add("Смотрим на результат. Движемся по пути. Файл с FTP сервера.");

        textArray.add("Нажми Левой кнопкой мыши 1 раз для перемещения по случайным координатам.");
        textArray.add("Смотрим на результат. Движемся по пути. Отрезки не пересекаются.");

        textArray.add("Конец.");
        
        textElement = gameObject.GetComponent<Text>();
        textElement.text = textArray.getText();
        stepsIndex = 0;
    }

    void Update()
    {
    }
}
