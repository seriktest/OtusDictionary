
using OtusDictionary;

var dic = new Map();

dic.Add(5,"Hello");
dic.Add(5,"Hello3");
dic.Add(6,"Hello3");
dic.Add(6,"");

dic[3] = "Hello10";


Console.WriteLine(dic.Get(3));

Console.ReadKey();