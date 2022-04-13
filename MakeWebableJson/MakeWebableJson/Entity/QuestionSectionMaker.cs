using System;
using System.Collections;
using System.Collections.Generic;
using System.Json;
using System.Text;

namespace MakeWebableJson.Facade
{
    internal class QuestionSectionMaker : IQuestionSectionMaker
    {
        public IList<string> MakeQuestionSection(Array item)
        {
            if (MWFacade.jQuestIx == 0)
            {
                MWFacade.jQuestIx++;
            }
            IList<string> retValue = new List<string>() { "{"};
            retValue.Add("\"" + item.GetValue(0).ToString() + "\":"); 
            retValue.Add("\"" + MWFacade.jQuestIx+" " + item.GetValue(1).ToString() + "\",");
            retValue.Add("\"" + item.GetValue(2).ToString() + "\":{");
            var jKey = MWFacade.Keys.GetValue(MWFacade.jKeysIx);
            retValue.Add("\"" + jKey +"\""+":" + "\"" + item.GetValue(3).ToString() + "\",");
            MWFacade.jKeysIx++;
            MWFacade.jQuestIx++;

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

/*-		item	{string[4]}	System.Array {string[]}
		[0]	"Question"	string
		[1]	"Age at time of assessment "	string
		[2]	"Answers"	string
		[3]	"17 or older "	string
*/
//{QuestionAge at time of assessment Answers17 or older 