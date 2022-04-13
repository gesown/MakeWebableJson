using System.Collections.Generic;
using System;

namespace MakeWebableJson.Facade
{
    internal interface IFileConverter
    {
        IList<Array> ConvertFile(string filein, string fileOut);
    }
}