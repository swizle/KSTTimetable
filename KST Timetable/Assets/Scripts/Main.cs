using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.Networking;
using Unity.VectorGraphics;
using System.Collections.Generic;

public class Main : MonoBehaviour
{
    [Header("Тексты занятий")]
    [SerializeField]
    private Text[] textLessons;
    [SerializeField]
    private Text[] textPrepodts;
    [SerializeField]
    private Text[] textCabinets;
    [Header("Тексты другие")]
    [SerializeField]
    private Text textWeek;
    [SerializeField]
    private Text textGroup;
    [SerializeField]
    private Text textToday;
    [Header("Обьекты")]
    [SerializeField]
    private Dropdown dpdwKorpus;
    [SerializeField]
    private Dropdown dpdwGroup;
    [SerializeField]
    private GameObject textAlert;
    [SerializeField]
    private GameObject panGroup;
    [SerializeField]
    private GameObject panSettings;
    [SerializeField]
    private SVGImage loadingImg;

    private readonly string[] days = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
    private readonly string[] daysWeek = { "Понедельник ", "Вторник ", "Среда ", "Четверг ", "Пятница ", "Суббота ", "Воскресенье " };
    private readonly string[] weekType = { "Нечётная", "Чётная" };
    private string[] groups;
    private string[] korpus;

    private int whatGroup = 0;
    private int whatKorpus = 0;
    private readonly DateTime dateNow = DateTime.Now;

    void Start()
    {
        Debug.Log(dateNow.DayOfWeek);
        dpdwKorpus.onValueChanged.AddListener(delegate { DpdwKorpusValueChanges(); });
        StartCoroutine(SendKorpusInfo());

        //Проверка какая неделя
        if ((dateNow.DayOfYear + 2) / 7 % 2 == 0)
        {
            textWeek.text = weekType[0];
        }
        else
        {
            textWeek.text = weekType[1];
        }

        //Текс сегоднешнего дня
        if (dateNow.DayOfWeek == DayOfWeek.Monday)
        {
            textToday.text = daysWeek[0] + Convert.ToString(dateNow.Day);
        }
        else if (dateNow.DayOfWeek == DayOfWeek.Tuesday)
        {
            textToday.text = daysWeek[1] + Convert.ToString(dateNow.Day);
        }
        else if (dateNow.DayOfWeek == DayOfWeek.Wednesday)
        {
            textToday.text = daysWeek[2] + Convert.ToString(dateNow.Day);
        }
        else if (dateNow.DayOfWeek == DayOfWeek.Thursday)
        {
            textToday.text = daysWeek[3] + Convert.ToString(dateNow.Day);
        }
        else if (dateNow.DayOfWeek == DayOfWeek.Friday)
        {
            textToday.text = daysWeek[4] + Convert.ToString(dateNow.Day);
        }
        else if (dateNow.DayOfWeek == DayOfWeek.Saturday)
        {
            textToday.text = daysWeek[5] + Convert.ToString(dateNow.Day);
        }
        else
        {
            textToday.text = daysWeek[6] + Convert.ToString(dateNow.Day);
        }
    }

    private void DpdwKorpusValueChanges()
    {
        StartCoroutine(SendGroupInfo(dpdwKorpus.options[dpdwKorpus.value].text));
    }

    void Update()
    {

    }

    //Кнопка выбора группы
    public void BtnSelect()
    {
        textGroup.text = Convert.ToString(dpdwGroup.options[dpdwGroup.value].text);
        whatGroup = dpdwGroup.value;
        whatKorpus = dpdwKorpus.value;

        //Начальный запуск дня
        if (dateNow.DayOfWeek == DayOfWeek.Monday)
        {
            BtnDays(0);
        }
        else if (dateNow.DayOfWeek == DayOfWeek.Tuesday)
        {
            BtnDays(1);
        }
        else if (dateNow.DayOfWeek == DayOfWeek.Wednesday)
        {
            BtnDays(2);
        }
        else if (dateNow.DayOfWeek == DayOfWeek.Thursday)
        {
            BtnDays(3);
        }
        else if (dateNow.DayOfWeek == DayOfWeek.Friday)
        {
            BtnDays(4);
        }
        else
        {
            BtnDays(2);
        }
        panGroup.SetActive(!panGroup.activeSelf);
    }

    //Кнопка назад
    public void BtnBack()
    {
        panGroup.SetActive(!panGroup.activeSelf);
    }

    //Кнопка настройки
    public void BtnSettings()
    {
        panSettings.SetActive(!panSettings.activeSelf);
    }

    //Кнопка сайта колледжа
    public void BtnOpenSite()
    {
        Application.OpenURL("https://sk12.ru");
    }

    //Кнопки с днями недели
    public void BtnDays(int v)
    {
        if (textWeek.text == weekType[1])
        {
            StartCoroutine(SendPara(groups[whatGroup], days[v], korpus[whatKorpus]));
        }
        else
        {
            StartCoroutine(SendPara(groups[whatGroup], days[v + 4], korpus[whatKorpus]));
        }
    }

    //Таймер на 3 сек для текста ошибки
    private IEnumerator Sec3()
    {
        yield return new WaitForSeconds(3);
        textAlert.SetActive(!textAlert.activeSelf);
    }

    //Запрос на сервер БД для получения пары
    private IEnumerator SendPara(string group, string lesson, string korpus)
    {
        //Форма отправки на сервер
        WWWForm formData = new WWWForm();
        formData.AddField("Group", group);
        formData.AddField("Lesson", lesson);
        formData.AddField("Korpus", korpus);

        UnityWebRequest postPara = UnityWebRequest.Post("http://ksttimetable.somee.com/Home/Para", formData);

        //Индикатор загрузки отправки
        UnityWebRequestAsyncOperation operation = postPara.SendWebRequest();
        while (!operation.isDone)
        {
            loadingImg.gameObject.SetActive(true);
            yield return null;
            loadingImg.gameObject.SetActive(false);
        }


        if (postPara.error != null)
        {
            Debug.Log(postPara.error);
            yield break;
        }

        //Расшифрова JSON в обычный текст
        Para para = JsonUtility.FromJson<Para>(postPara.downloadHandler.text);
        Debug.Log(para.lesson[0]);

        //Заполнение текстов парами, преподами и кабинетами
        for (int i = 0; i < 4; i++)
        {
            textLessons[i].text = para.lesson[i];
            textPrepodts[i].text = para.prepod[i];
            textCabinets[i].text = para.cabinet[i];

            textLessons[i + 4].text = para.lesson[i];
            textPrepodts[i + 4].text = para.prepod[i];
            textCabinets[i + 4].text = para.cabinet[i];
        }
    }

    //Запрос на сервер БД для получения корпусов
    private IEnumerator SendKorpusInfo()
    {
        //Форма отправки на сервер
        WWWForm formData = new WWWForm();
        formData.AddField("Info", "korpus");

        UnityWebRequest postKorpus = UnityWebRequest.Post("http://ksttimetable.somee.com/Home/Info", formData);

        //Индикатор загрузки отправки
        UnityWebRequestAsyncOperation operation = postKorpus.SendWebRequest();
        while (!operation.isDone)
        {
            yield return null;
        }

        if (postKorpus.error != null)
        {
            Debug.Log(postKorpus.error);
            yield break;
        }

        //Расшифрова JSON в обычный текст
        SendKorpus sendKorpus = JsonUtility.FromJson<SendKorpus>(postKorpus.downloadHandler.text);
        Debug.Log(sendKorpus.korpuses[0]);

        List<string> infoKorpusLists = new List<string>();

        dpdwKorpus.ClearOptions();

        foreach (var infoKorpusList in sendKorpus.korpuses)
        {
            infoKorpusLists.Add(infoKorpusList);
        }

        dpdwKorpus.AddOptions(infoKorpusLists);

        korpus = sendKorpus.korpuses;

        StartCoroutine(SendGroupInfo(dpdwKorpus.options[dpdwKorpus.value].text));
    }

    //Запрос на сервер БД для получения корпусов
    private IEnumerator SendGroupInfo(string korpusId)
    {
        //Форма отправки на сервер
        WWWForm formData = new WWWForm();
        formData.AddField("Info", "group");
        formData.AddField("Korpus", korpusId);

        UnityWebRequest postGroup = UnityWebRequest.Post("http://ksttimetable.somee.com/Home/Info", formData);

        //Индикатор загрузки отправки
        UnityWebRequestAsyncOperation operation = postGroup.SendWebRequest();
        while (!operation.isDone)
        {
            yield return null;
        }

        if (postGroup.error != null)
        {
            Debug.Log(postGroup.error);
            yield break;
        }

        //Расшифрова JSON в обычный текст
        SendGroup sendGroup = JsonUtility.FromJson<SendGroup>(postGroup.downloadHandler.text);
        Debug.Log(sendGroup.groups[0]);

        List<string> infoGroupLists = new List<string>();

        dpdwGroup.ClearOptions();

        foreach (var infoGroupList in sendGroup.groups)
        {
            infoGroupLists.Add(infoGroupList);
        }

        dpdwGroup.AddOptions(infoGroupLists);

        groups = sendGroup.groups;
    }

    //Классы для принятия запросов с серверов
    [System.Serializable]
    public class Para
    {
        public string[] lesson;
        public string[] prepod;
        public string[] cabinet;
    }
    public class SendKorpus
    {
        public string[] korpuses;
    }
    public class SendGroup
    {
        public string[] groups;
    }
}