using System;
using System.Collections.Generic;
using System.Linq;

public class BWT_Worker
{
    public static Tuple<string, int> Encode(string s)
    {
        if(string.IsNullOrEmpty(s))
            return new ("",0);
        //Console.WriteLine((int)Convert.ToChar("a") +" " + (int)Convert.ToChar("Z") + " " + (int)Convert.ToChar("A") + " "+ (int)Convert.ToChar(" "));
        int length = s.Length;

        string[] matrix = new string[length];

        for (int i = 0; i < length; i++)
        {

            matrix[i] = string.Concat(s.Substring(length - i, i), s.Substring(0, length - i));
            // Console.WriteLine(string.Format("matrix  {0}: {1}", i, matrix[i]));

        }

        var orderedMatrix = matrix.Order(StringComparer.Ordinal).ToArray();
        string resString = "";
        int resIndex = 0;
        Tuple<string, int> result = new("", 0);
        for (int i = 0; i < length; i++)
        {
            // Console.WriteLine(string.Format("orderedMatrix  {0}: {1}", i, orderedMatrix[i]));
            resString += orderedMatrix[i].Substring(length - 1, 1);
            if (orderedMatrix[i] == s)
                resIndex = i;
        }

        //Console.WriteLine(string.Format("ResultString {0}, ResultIndex {1}", resString, resIndex));
        return new(resString, resIndex);
    }

    public static string Decode(string s, int i)
    {
        if(string.IsNullOrEmpty(s))
            return "";
        var charactersStringArray = s.Select(c => c.ToString()).ToArray();
        var orderedArray = s.Select(o => o.ToString()).Order(StringComparer.Ordinal).ToArray();
        var k= 1;
        while (k < s.Length)
        {
            orderedArray = orderedArray.Select((s,i)=> charactersStringArray[i] + s).Order(StringComparer.Ordinal).ToArray();
            k++;
        }
        return orderedArray[i];
    }


    /**
a b a r b a n a n
a n a b a r b a n
a n a n a b a r b
a r b a n a n a b
b a n a n a b a r <- 4
b a r b a n a n a
n a b a r b a n a
n a n a b a r b a
r b a n a n a b a
    **/
}
