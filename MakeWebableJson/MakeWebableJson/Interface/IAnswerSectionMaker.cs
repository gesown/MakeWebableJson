using System;
using System.Collections.Generic;
using System.Json;

namespace MakeWebableJson.Facade
{
    internal interface IAnswerSectionMaker
    {
        IList<string> MakeAnswerSection(Array item);
    }
}