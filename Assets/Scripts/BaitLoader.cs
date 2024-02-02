using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaitLoader : ScrollInitializer
{
    public List<BaitsInfo> list = new();

    private void Start()
    {
        //LoadBaits();
        list = LoadArray<BaitsInfo>("baits").ToList(); //Получаем список наживок
        Init();
    }

    private void LoadBaits()
    {
        throw new NotImplementedException();
    }

    public override void ProvideData(Transform transform, int id)
    {
        transform.SendMessage("LoadInfo", list[id]);
    }

    public override void SetTotalCount() //Кол-во создаваемых элементов в списке для отображения
    {
        scroll.totalCount = list.Count;
    }


    public static string LoadJson(string name) => Resources.Load<TextAsset>("Configs/" + name).ToString(); //Загрузка файла

    public static T[] LoadArray<T>(string name) => JsonConvert.DeserializeObject<T[]>(LoadJson(name)); //Преобразование json  в массив

}