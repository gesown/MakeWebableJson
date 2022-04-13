using System;
using System.Collections.Generic;
using System.Json;

namespace MakeWebableJson.Facade
{
    internal class AnswerSectionMaker : IAnswerSectionMaker
    {
        public IList<string> MakeAnswerSection(Array item)
        {
            IList<string> retValue = new List<string>();
            var jKey = MWFacade.Keys.GetValue(MWFacade.jKeysIx);
            retValue.Add("\""+jKey + "\":" + "\"" + item.GetValue(1).ToString() + "\",");
            MWFacade.jKeysIx++;
            return retValue;
        }
    }
}
/*    "1  Criminal History ",
    {
        "Question": "1 Age at time of assessment ",
        "answers": {
            "a": "17 or older ",
            "b": "16",
            "c": "15",
            "d": "14",
            "e": "13 and under "
        }
    },*/