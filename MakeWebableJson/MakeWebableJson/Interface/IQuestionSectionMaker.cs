using System;
using System.Collections.Generic;
using System.Json;

namespace MakeWebableJson.Facade
{
    internal interface IQuestionSectionMaker
    {
        IList<string> MakeQuestionSection(Array item);
    }
}