using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float speed = 5f;
    public Joystick joystick;
    private float vertical;
    private float horizontal;

    public List ObjectPool;


    void Start()
    {
        //Создаем новый список, так как List - 
        //ссылка на динамический массив
        ObjectPool = new List();
    }

    void FixedUpdate()
    {
        GetKeyInput();
        GetMobileInput();

        //Выстрел будет производится при клике мышкой
        if (Input.GetMouseButtonUp(0) == true)
        {
            //diff - будет смещением нашего нажатия от объекта
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            //номализация приводит каждое значение в промежуток
            //от -1 до 1
            diff.Normalize();
            //по нормализованному виду мы находим угол, так как в diff
            //находится вектор, который можно перенести на тригонометрическую окружность
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            //и приваиваем наш угол персонажу
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
            //Показывает, нашли ли мы выключенный объект в нашем массиве
            bool freeBullet = false;
            //Теперь необходимо проверить, есть ли выключенный объект в нашем пуле
            for (int i = 0; i < ObjectPool.Count; i++)
            {
                //Смотрим, активен ли объект в игровом пространстве
                if (!ObjectPool[i].activeInHierarchy)
                {
                    //Если объект не активен
                    //То мы задаем ему все нужные параметры
                    //Позицию
                    ObjectPool[i].transform.position = transform.position;
                    //Поворот
                    ObjectPool[i].transform.rotation = transform.rotation;
                    //И опять его включаем
                    ObjectPool[i].SetActive(true);
                    //Ставим объект найденным, чтоб опять не создавать лишний
                    freeBullet = true;
                    break;
                }
            }
            //если свободный объект не был найден, то нужно создать еще один
            if (!freeBullet)
            {
                //Создаем объект с нужными значениями и заносим его в пул
                ObjectPool.Add(Instantiate(Resources.Load("Prefabs/Bullet"), transform.position, transform.rotation));
            }
        }
    }

    // Управление с пк

    private void GetKeyInput()
    {
        float move = Input.GetAxis("Horizontal");
        transform.position += new Vector3(move, 0, 0) * speed * Time.deltaTime * 2;

        float move1 = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, move1, 0) * speed * Time.deltaTime * 2;
    }

    // Управление с мобилки

    private void GetMobileInput()
    {
        vertical = joystick.Vertical;
        horizontal = joystick.Horizontal;

        //Движение вверх
        if (vertical >= 0.1)
        {
            if (vertical >= 0.5)
            {
                transform.position += new Vector3(0, 2, 0) * speed * Time.deltaTime;
            }
            else
            {
                transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
            }
        }
        //Движение вниз
        if (vertical <= -0.1)
        {
            if (vertical <= -0.5)
            {
                transform.position += new Vector3(0, -2, 0) * speed * Time.deltaTime;
            }
            else
            {
                transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
            }
        }
        //Движение влево
        if (horizontal <= -0.1)
        {
            if (horizontal <= -0.5)
            {
                transform.position += new Vector3(-2, 0, 0) * speed * Time.deltaTime;
            }
            else
            {
                transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            }
        }
        //Движение вправо
        if (horizontal >= 0.1)
        {
            if (horizontal >= 0.5)
            {
                transform.position += new Vector3(2, 0, 0) * speed * Time.deltaTime;
            }
            else
            {
                transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            }
        }
    }

}