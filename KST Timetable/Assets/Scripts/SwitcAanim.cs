using System;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UI;

public class SwitcAanim : MonoBehaviour
{
    [SerializeField]
    private GameObject Bg1;
    [SerializeField]
    private GameObject Bg2;
    [SerializeField]
    private GameObject TextAlert;
    [SerializeField]
    private GameObject DdGroups;
    [SerializeField]
    private GameObject DdGroupsLabel;
    [SerializeField]
    private GameObject DdGroupsArrow;
    [SerializeField]
    private GameObject DdGroupsCheckmark;
    [SerializeField]
    private GameObject DdGroupsTemplate;
    [SerializeField]
    private GameObject DdGroupsItemLabel;
    [SerializeField]
    private GameObject DdGroupsScrollbar;
    [SerializeField]
    private GameObject DdGroupsHandle;
    [SerializeField]
    private GameObject DdKorpus;
    [SerializeField]
    private GameObject DdKorpusLabel;
    [SerializeField]
    private GameObject DdKorpusArrow;
    [SerializeField]
    private GameObject DdKorpusCheckmark;
    [SerializeField]
    private GameObject DdKorpusTemplate;
    [SerializeField]
    private GameObject DdKorpusItemLabel;
    [SerializeField]
    private GameObject DdKorpusScrollbar;
    [SerializeField]
    private GameObject DdKorpusHandle;
    [SerializeField]
    private GameObject BtnSelectGroup;
    [SerializeField]
    private GameObject PanGroup;
    [SerializeField]
    private GameObject PanDays;
    [SerializeField]
    private GameObject PanSettings;
    [SerializeField]
    private GameObject BtnBack;
    [SerializeField]
    private GameObject BtnSettings;
    [SerializeField]
    private Text[] TextDays;
    [SerializeField]
    private GameObject ImgTime1;
    [SerializeField]
    private GameObject ImgCab1;
    [SerializeField]
    private GameObject ImgTime2;
    [SerializeField]
    private GameObject ImgCab2;
    [SerializeField]
    private GameObject ImgTime3;
    [SerializeField]
    private GameObject ImgCab3;
    [SerializeField]
    private GameObject ImgTime4;
    [SerializeField]
    private GameObject ImgCab4;
    [SerializeField]
    private GameObject ImgTime5;
    [SerializeField]
    private GameObject ImgCab5;
    [SerializeField]
    private GameObject ImgTime6;
    [SerializeField]
    private GameObject ImgCab6;
    [SerializeField]
    private GameObject ImgTime7;
    [SerializeField]
    private GameObject ImgCab7;
    [SerializeField]
    private GameObject ImgTime8;
    [SerializeField]
    private GameObject ImgCab8;
    [SerializeField]
    private GameObject TextDdKor;
    [SerializeField]
    private GameObject TextDdGroup;
    [SerializeField]
    private GameObject TextBtnSelect;
    [SerializeField]
    private GameObject TextGroup;
    [SerializeField]
    private GameObject TextWeek;
    [SerializeField]
    private GameObject TextToday;
    [SerializeField]
    private GameObject BtnTheme1;
    [SerializeField]
    private GameObject BtnThemeCircle;

    private int switchanim = 0;
    private int btsselected = 0;
    private Animator anim;
    private readonly DateTime DateNow = DateTime.Now;
    private Save sv = new Save(); // Сохранение
    //Конвертер Hex цвета
    private int Hex(string hex1)
    {
        int dec = Convert.ToInt32(hex1, 16);
        return dec;
    }
    private float HexNorm(string hex1)
    {
        return Hex(hex1) / 255f;
    }
    private Color HeColor(string hex1)
    {
        float red = HexNorm(hex1.Substring(0, 2));
        float green = HexNorm(hex1.Substring(2, 2));
        float blue = HexNorm(hex1.Substring(4, 2));
        return new Color(red, green, blue);
    }
    //private void Awake() // До старта
    //{
    //    if (PlayerPrefs.HasKey("SaveTheme")) // Грузим сохранение
    //    {
    //        sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SaveTheme"));
    //        switchanim = sv.switchanim;
    //        if (switchanim == 0)
    //        {
    //            Bg1.GetComponent<Gradient>().enabled = false;
    //            Bg2.GetComponent<Gradient>().enabled = false;
    //            TextAlert.GetComponent<Text>().color = HeColor("000000");
    //            DdGroups.GetComponent<Gradient>().enabled = false;
    //            DdGroupsLabel.GetComponent<Text>().color = HeColor("35B2FF");
    //            DdGroupsArrow.GetComponent<SVGImage>().color = HeColor("35B2FF");
    //            DdGroupsCheckmark.GetComponent<SVGImage>().color = HeColor("35B2FF");
    //            DdGroupsTemplate.GetComponent<Image>().color = HeColor("89F1FF");
    //            DdGroupsItemLabel.GetComponent<Text>().color = HeColor("FFFFFF");
    //            DdGroupsScrollbar.GetComponent<Image>().color = HeColor("00BFD9");
    //            DdGroupsHandle.GetComponent<Image>().color = HeColor("009DB2");
    //            DdKorpus.GetComponent<Gradient>().enabled = false;
    //            DdKorpusLabel.GetComponent<Text>().color = HeColor("35B2FF");
    //            DdKorpusArrow.GetComponent<SVGImage>().color = HeColor("35B2FF");
    //            DdKorpusCheckmark.GetComponent<SVGImage>().color = HeColor("35B2FF");
    //            DdKorpusTemplate.GetComponent<Image>().color = HeColor("89F1FF");
    //            DdKorpusItemLabel.GetComponent<Text>().color = HeColor("FFFFFF");
    //            DdKorpusScrollbar.GetComponent<Image>().color = HeColor("00BFD9");
    //            DdKorpusHandle.GetComponent<Image>().color = HeColor("009DB2");
    //            BtnSelectGroup.GetComponent<Gradient>().enabled = false;
    //            PanGroup.GetComponent<SVGImage>().color = HeColor("2F678B");
    //            PanDays.GetComponent<Image>().color = HeColor("F1F1F1");
    //            PanSettings.GetComponent<SVGImage>().color = HeColor("009DB2");
    //            BtnBack.GetComponent<SVGImage>().color = HeColor("000000");
    //            BtnSettings.GetComponent<SVGImage>().color = HeColor("000000");
    //            ImgTime1.GetComponent<Gradient>().enabled = false;
    //            ImgCab1.GetComponent<Gradient>().enabled = false;
    //            ImgTime2.GetComponent<Gradient>().enabled = false;
    //            ImgCab2.GetComponent<Gradient>().enabled = false;
    //            ImgTime3.GetComponent<Gradient>().enabled = false;
    //            ImgCab3.GetComponent<Gradient>().enabled = false;
    //            ImgTime4.GetComponent<Gradient>().enabled = false;
    //            ImgCab4.GetComponent<Gradient>().enabled = false;
    //            ImgTime5.GetComponent<Gradient>().enabled = false;
    //            ImgCab5.GetComponent<Gradient>().enabled = false;
    //            ImgTime6.GetComponent<Gradient>().enabled = false;
    //            ImgCab6.GetComponent<Gradient>().enabled = false;
    //            ImgTime7.GetComponent<Gradient>().enabled = false;
    //            ImgCab7.GetComponent<Gradient>().enabled = false;
    //            ImgTime8.GetComponent<Gradient>().enabled = false;
    //            ImgCab8.GetComponent<Gradient>().enabled = false;
    //            TextDdKor.GetComponent<Text>().color = HeColor("000000");
    //            TextDdGroup.GetComponent<Text>().color = HeColor("000000");
    //            TextBtnSelect.GetComponent<Text>().color = HeColor("FFFFFF");
    //            TextGroup.GetComponent<Text>().color = HeColor("000000");
    //            TextWeek.GetComponent<Text>().color = HeColor("000000");
    //            TextToday.GetComponent<Text>().color = HeColor("000000");

    //            for (int i = 0; i < 5; i++)
    //            {
    //                TextDays[i].GetComponent<Text>().color = HeColor("2F678B");
    //            }
    //            TextDays[btsselected].GetComponent<Text>().color = HeColor("FFFFFF");
    //        }
    //        else
    //        {
    //            BtnThemeCircle.GetComponent<RectTransform>().anchoredPosition = new Vector2 (42, 0);
    //            Bg1.GetComponent<Gradient>().enabled = true;
    //            Bg2.GetComponent<Gradient>().enabled = true;
    //            TextAlert.GetComponent<Text>().color = HeColor("FFFFFF");
    //            DdGroups.GetComponent<Gradient>().enabled = true;
    //            DdGroupsLabel.GetComponent<Text>().color = HeColor("56587A");
    //            DdGroupsArrow.GetComponent<SVGImage>().color = HeColor("303256");
    //            DdGroupsCheckmark.GetComponent<SVGImage>().color = HeColor("303256");
    //            DdGroupsTemplate.GetComponent<Image>().color = HeColor("151837");
    //            DdGroupsItemLabel.GetComponent<Text>().color = HeColor("56587A");
    //            DdGroupsScrollbar.GetComponent<Image>().color = HeColor("1D2242");
    //            DdGroupsHandle.GetComponent<Image>().color = HeColor("1F2F49");
    //            DdKorpus.GetComponent<Gradient>().enabled = true;
    //            DdKorpusLabel.GetComponent<Text>().color = HeColor("56587A");
    //            DdKorpusArrow.GetComponent<SVGImage>().color = HeColor("303256");
    //            DdKorpusCheckmark.GetComponent<SVGImage>().color = HeColor("303256");
    //            DdKorpusTemplate.GetComponent<Image>().color = HeColor("151837");
    //            DdKorpusItemLabel.GetComponent<Text>().color = HeColor("56587A");
    //            DdKorpusScrollbar.GetComponent<Image>().color = HeColor("1D2242");
    //            DdKorpusHandle.GetComponent<Image>().color = HeColor("1F2F49");
    //            BtnSelectGroup.GetComponent<Gradient>().enabled = true;
    //            PanGroup.GetComponent<SVGImage>().color = HeColor("151837");
    //            PanDays.GetComponent<Image>().color = HeColor("23334D");
    //            PanSettings.GetComponent<SVGImage>().color = HeColor("1D2242");
    //            BtnBack.GetComponent<SVGImage>().color = HeColor("FFFFFF");
    //            BtnSettings.GetComponent<SVGImage>().color = HeColor("FFFFFF");
    //            ImgTime1.GetComponent<Gradient>().enabled = true;
    //            ImgCab1.GetComponent<Gradient>().enabled = true;
    //            ImgTime2.GetComponent<Gradient>().enabled = true;
    //            ImgCab2.GetComponent<Gradient>().enabled = true;
    //            ImgTime3.GetComponent<Gradient>().enabled = true;
    //            ImgCab3.GetComponent<Gradient>().enabled = true;
    //            ImgTime4.GetComponent<Gradient>().enabled = true;
    //            ImgCab4.GetComponent<Gradient>().enabled = true;
    //            ImgTime5.GetComponent<Gradient>().enabled = true;
    //            ImgCab5.GetComponent<Gradient>().enabled = true;
    //            ImgTime6.GetComponent<Gradient>().enabled = true;
    //            ImgCab6.GetComponent<Gradient>().enabled = true;
    //            ImgTime7.GetComponent<Gradient>().enabled = true;
    //            ImgCab7.GetComponent<Gradient>().enabled = true;
    //            ImgTime8.GetComponent<Gradient>().enabled = true;
    //            ImgCab8.GetComponent<Gradient>().enabled = true;
    //            TextDdKor.GetComponent<Text>().color = HeColor("FFFFFF");
    //            TextDdGroup.GetComponent<Text>().color = HeColor("FFFFFF");
    //            TextBtnSelect.GetComponent<Text>().color = HeColor("09061A");
    //            TextGroup.GetComponent<Text>().color = HeColor("FFFFFF");
    //            TextWeek.GetComponent<Text>().color = HeColor("FFFFFF");
    //            TextToday.GetComponent<Text>().color = HeColor("FFFFFF");

    //            for (int i = 0; i < 5; i++)
    //            {
    //                TextDays[i].GetComponent<Text>().color = HeColor("ADADAD");
    //            }
    //            TextDays[btsselected].GetComponent<Text>().color = HeColor("35B2FF");
    //        }
    //    }
    //}
    void Start()
    {
        //anim = BtnTheme1.GetComponent<Animator>();
        BtnSelectGroupDaysColor();
    }
    //public void BtnTheme()
    //{
    //    if (switchanim == 0)
    //    {
    //        anim.SetInteger("switchcount", 1);
    //        switchanim++;
    //        Bg1.GetComponent<Gradient>().enabled = true;
    //        Bg2.GetComponent<Gradient>().enabled = true;
    //        TextAlert.GetComponent<Text>().color = HeColor("FFFFFF");
    //        DdGroups.GetComponent<Gradient>().enabled = true;
    //        DdGroupsLabel.GetComponent<Text>().color = HeColor("56587A");
    //        DdGroupsArrow.GetComponent<SVGImage>().color = HeColor("303256");
    //        DdGroupsCheckmark.GetComponent<SVGImage>().color = HeColor("303256");
    //        DdGroupsTemplate.GetComponent<Image>().color = HeColor("151837");
    //        DdGroupsItemLabel.GetComponent<Text>().color = HeColor("56587A");
    //        DdGroupsScrollbar.GetComponent<Image>().color = HeColor("1D2242");
    //        DdGroupsHandle.GetComponent<Image>().color = HeColor("1F2F49");
    //        DdKorpus.GetComponent<Gradient>().enabled = true;
    //        DdKorpusLabel.GetComponent<Text>().color = HeColor("56587A");
    //        DdKorpusArrow.GetComponent<SVGImage>().color = HeColor("303256");
    //        DdKorpusCheckmark.GetComponent<SVGImage>().color = HeColor("303256");
    //        DdKorpusTemplate.GetComponent<Image>().color = HeColor("151837");
    //        DdKorpusItemLabel.GetComponent<Text>().color = HeColor("56587A");
    //        DdKorpusScrollbar.GetComponent<Image>().color = HeColor("1D2242");
    //        DdKorpusHandle.GetComponent<Image>().color = HeColor("1F2F49");
    //        BtnSelectGroup.GetComponent<Gradient>().enabled = true;
    //        PanGroup.GetComponent<SVGImage>().color = HeColor("151837");
    //        PanDays.GetComponent<Image>().color = HeColor("23334D");
    //        PanSettings.GetComponent<SVGImage>().color = HeColor("1D2242");
    //        BtnBack.GetComponent<SVGImage>().color = HeColor("FFFFFF");
    //        BtnSettings.GetComponent<SVGImage>().color = HeColor("FFFFFF");
    //        ImgTime1.GetComponent<Gradient>().enabled = true;
    //        ImgCab1.GetComponent<Gradient>().enabled = true;
    //        ImgTime2.GetComponent<Gradient>().enabled = true;
    //        ImgCab2.GetComponent<Gradient>().enabled = true;
    //        ImgTime3.GetComponent<Gradient>().enabled = true;
    //        ImgCab3.GetComponent<Gradient>().enabled = true;
    //        ImgTime4.GetComponent<Gradient>().enabled = true;
    //        ImgCab4.GetComponent<Gradient>().enabled = true;
    //        ImgTime5.GetComponent<Gradient>().enabled = true;
    //        ImgCab5.GetComponent<Gradient>().enabled = true;
    //        ImgTime6.GetComponent<Gradient>().enabled = true;
    //        ImgCab6.GetComponent<Gradient>().enabled = true;
    //        ImgTime7.GetComponent<Gradient>().enabled = true;
    //        ImgCab7.GetComponent<Gradient>().enabled = true;
    //        ImgTime8.GetComponent<Gradient>().enabled = true;
    //        ImgCab8.GetComponent<Gradient>().enabled = true;
    //        TextDdKor.GetComponent<Text>().color = HeColor("FFFFFF");
    //        TextDdGroup.GetComponent<Text>().color = HeColor("FFFFFF");
    //        TextBtnSelect.GetComponent<Text>().color = HeColor("09061A");
    //        TextGroup.GetComponent<Text>().color = HeColor("FFFFFF");
    //        TextWeek.GetComponent<Text>().color = HeColor("FFFFFF");
    //        TextToday.GetComponent<Text>().color = HeColor("FFFFFF");

    //        for (int i = 0; i < 5; i++)
    //        {
    //            TextDays[i].GetComponent<Text>().color = HeColor("828596");
    //        }
    //        TextDays[btsselected].GetComponent<Text>().color = HeColor("FFFFFF");
    //    }
    //    else
    //    {
    //        //anim.SetInteger("switchcount", 2);
    //        switchanim--;
    //        Bg1.GetComponent<Gradient>().enabled = false;
    //        Bg2.GetComponent<Gradient>().enabled = false;
    //        TextAlert.GetComponent<Text>().color = HeColor("000000");
    //        DdGroups.GetComponent<Gradient>().enabled = false;
    //        DdGroupsLabel.GetComponent<Text>().color = HeColor("35B2FF");
    //        DdGroupsArrow.GetComponent<SVGImage>().color = HeColor("35B2FF");
    //        DdGroupsCheckmark.GetComponent<SVGImage>().color = HeColor("35B2FF");
    //        DdGroupsTemplate.GetComponent<Image>().color = HeColor("89F1FF");
    //        DdGroupsItemLabel.GetComponent<Text>().color = HeColor("FFFFFF");
    //        DdGroupsScrollbar.GetComponent<Image>().color = HeColor("00BFD9");
    //        DdGroupsHandle.GetComponent<Image>().color = HeColor("009DB2");
    //        DdKorpus.GetComponent<Gradient>().enabled = false;
    //        DdKorpusLabel.GetComponent<Text>().color = HeColor("35B2FF");
    //        DdKorpusArrow.GetComponent<SVGImage>().color = HeColor("35B2FF");
    //        DdKorpusCheckmark.GetComponent<SVGImage>().color = HeColor("35B2FF");
    //        DdKorpusTemplate.GetComponent<Image>().color = HeColor("89F1FF");
    //        DdKorpusItemLabel.GetComponent<Text>().color = HeColor("FFFFFF");
    //        DdKorpusScrollbar.GetComponent<Image>().color = HeColor("00BFD9");
    //        DdKorpusHandle.GetComponent<Image>().color = HeColor("009DB2");
    //        BtnSelectGroup.GetComponent<Gradient>().enabled = false;
    //        PanGroup.GetComponent<SVGImage>().color = HeColor("2F678B");
    //        PanDays.GetComponent<Image>().color = HeColor("F1F1F1");
    //        PanSettings.GetComponent<SVGImage>().color = HeColor("009DB2");
    //        BtnBack.GetComponent<SVGImage>().color = HeColor("000000");
    //        BtnSettings.GetComponent<SVGImage>().color = HeColor("000000");
    //        ImgTime1.GetComponent<Gradient>().enabled = false;
    //        ImgCab1.GetComponent<Gradient>().enabled = false;
    //        ImgTime2.GetComponent<Gradient>().enabled = false;
    //        ImgCab2.GetComponent<Gradient>().enabled = false;
    //        ImgTime3.GetComponent<Gradient>().enabled = false;
    //        ImgCab3.GetComponent<Gradient>().enabled = false;
    //        ImgTime4.GetComponent<Gradient>().enabled = false;
    //        ImgCab4.GetComponent<Gradient>().enabled = false;
    //        ImgTime5.GetComponent<Gradient>().enabled = false;
    //        ImgCab5.GetComponent<Gradient>().enabled = false;
    //        ImgTime6.GetComponent<Gradient>().enabled = false;
    //        ImgCab6.GetComponent<Gradient>().enabled = false;
    //        ImgTime7.GetComponent<Gradient>().enabled = false;
    //        ImgCab7.GetComponent<Gradient>().enabled = false;
    //        ImgTime8.GetComponent<Gradient>().enabled = false;
    //        ImgCab8.GetComponent<Gradient>().enabled = false;
    //        TextDdKor.GetComponent<Text>().color = HeColor("000000");
    //        TextDdGroup.GetComponent<Text>().color = HeColor("000000");
    //        TextBtnSelect.GetComponent<Text>().color = HeColor("FFFFFF");
    //        TextGroup.GetComponent<Text>().color = HeColor("000000");
    //        TextWeek.GetComponent<Text>().color = HeColor("000000");
    //        TextToday.GetComponent<Text>().color = HeColor("000000");

    //        for (int i = 0; i < 5; i++)
    //        {
    //            TextDays[i].GetComponent<Text>().color = HeColor("ADADAD");
    //        }
    //        TextDays[btsselected].GetComponent<Text>().color = HeColor("35B2FF");
    //    }
    //}

    //Смена цвета текста на днях
    public void BtnDaysColor(int n)
    {
        if (switchanim == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                TextDays[i].GetComponent<Text>().color = HeColor("FFFFFF");
            }
            TextDays[n].GetComponent<Text>().color = HeColor("2c3e50");
            btsselected = n;
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                TextDays[i].GetComponent<Text>().color = HeColor("828596");
            }
            TextDays[n].GetComponent<Text>().color = HeColor("FFFFFF");
            btsselected = n;
        }
    }
    public void BtnSelectGroupDaysColor()
    {
        if (switchanim == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                TextDays[i].GetComponent<Text>().color = HeColor("FFFFFF");
            }
            if (DateNow.DayOfWeek == DayOfWeek.Monday)
            {
                TextDays[0].GetComponent<Text>().color = HeColor("2c3e50");
                btsselected = 0;
            }
            else if (DateNow.DayOfWeek == DayOfWeek.Tuesday)
            {
                TextDays[1].GetComponent<Text>().color = HeColor("2c3e50");
                btsselected = 1;
            }
            else if (DateNow.DayOfWeek == DayOfWeek.Wednesday)
            {
                TextDays[2].GetComponent<Text>().color = HeColor("2c3e50");
                btsselected = 2;
            }
            else if (DateNow.DayOfWeek == DayOfWeek.Thursday)
            {
                TextDays[3].GetComponent<Text>().color = HeColor("2c3e50");
                btsselected = 3;
            }
            else if (DateNow.DayOfWeek == DayOfWeek.Friday)
            {
                TextDays[4].GetComponent<Text>().color = HeColor("2c3e50");
                btsselected = 4;
            }
            else
            {
                TextDays[2].GetComponent<Text>().color = HeColor("2c3e50");
                btsselected = 2;
            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                TextDays[i].GetComponent<Text>().color = HeColor("828596");
            }
            if (DateNow.DayOfWeek == DayOfWeek.Monday)
            {
                TextDays[0].GetComponent<Text>().color = HeColor("FFFFFF");
                btsselected = 0;
            }
            else if (DateNow.DayOfWeek == DayOfWeek.Tuesday)
            {
                TextDays[1].GetComponent<Text>().color = HeColor("FFFFFF");
                btsselected = 1;
            }
            else if (DateNow.DayOfWeek == DayOfWeek.Wednesday)
            {
                TextDays[2].GetComponent<Text>().color = HeColor("FFFFFF");
                btsselected = 2;
            }
            else if (DateNow.DayOfWeek == DayOfWeek.Thursday)
            {
                TextDays[3].GetComponent<Text>().color = HeColor("FFFFFF");
                btsselected = 3;
            }
            else if (DateNow.DayOfWeek == DayOfWeek.Friday)
            {
                TextDays[4].GetComponent<Text>().color = HeColor("FFFFFF");
                btsselected = 4;
            }
            else
            {
                TextDays[2].GetComponent<Text>().color = HeColor("FFFFFF");
                btsselected = 2;
            }
        }
    }
//#if UNITY_ANDROID && !UNITY_EDITOR // Проверка на выход из игры для сохр
//    private void OnApplicationPause(bool pause)
//    {
//        if (pause)
//        {
//            sv.switchanim = switchanim;
//            PlayerPrefs.SetString("SaveTheme", JsonUtility.ToJson(sv));
//        }
//    }
//#else
//    private void OnApplicationQuit() // Проверка на выход из игры для сохр (редактор юнити)
//    {
//        sv.switchanim = switchanim;
//        PlayerPrefs.SetString("SaveTheme", JsonUtility.ToJson(sv));
//    }
//#endif
[Serializable]
    public class Save // Сохранение
    {
        public int switchanim;
    }
}
