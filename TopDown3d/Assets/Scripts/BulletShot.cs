using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    public float Speed = 2f;
    public float TimeToDisable = 2f;

    //Каждый раз, когда наша пуля активируется
    void OnEnable()
    {
        //Мы будем запускать таймер для того чтоб выключить её
        StartCoroutine(SetDisabled(TimeToDisable));

    }

    IEnumerator SetDisabled(float TimeToDisable)
    {
        //Данный скрип приостановит свое исполнение на TimeToDisable секунд, а потом продолжит работу
        yield return new WaitForSeconds(TimeToDisable);
        //Выключаем объект, он у нас останется в пуле объектов до следующего использования
        gameObject.SetActive(false);
    }

    void Update()
    {
        //Теперь пуля будет лететь вперед до того, пока объект не будет выключен
        //Так как наша пуля уже повернута в нужную сторону, а в 2D пространстве
        //Вперед это направо, то нашей пуле надо просто лететь направо 
        //отностительно своего мирового пространства
        transform.position += transform.up * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Тут должна быть ваша обработка попадания
        //Вместо этого условия необходимо ваше, которое определит, что
        //в Collision находится именно тот объект, который вам нужен
        if (collision == null)
        {
            //Выключаем ожидание выключения чтоб в случае чего не создавать
            //несколько копий ожиданий
            StopCoroutine("SetDisabled");
            //Выключаем объект
            gameObject.SetActive(false);
            //Дальше весь тот код, который нужнен для вашей игры

        }
    }
}