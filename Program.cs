using System.Collections;
using System.Text;
using Лаба_15;

{
    var a = new Map<int, string>(5);
    var str = "EASYQUTION";
    for (int i = 0; i < str.Length; i++)
    {
        a.Add(11 * Convert.ToInt32(str[i]) % 5, str[i].ToString());
    }
    Console.WriteLine(a.ToString());
    Console.WriteLine();
    var b = new HashMap2<int, string>(10);
    for (int i = 0; i < str.Length; i++)
    {
        b.add(11 * Convert.ToInt32(str[i]) % 5, str[i].ToString());
    }
    Console.WriteLine(b.ToString());
}
