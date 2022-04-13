using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Text;

using Microsoft.Ajax.Utilities;

namespace MakeWebableJson.Facade
{
    public static class MWFacade
    {
        internal static int jKeysIx=0;
        internal static int jQuestIx = 1;

        public static Array Keys { get; internal set; }

        internal static Array GetJsonKeysArray()
        {
            var retValue = Array.CreateInstance(typeof(string),26);
            var sIn = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            for (int i = 0; i < retValue.Length; i++)
            {
                retValue.SetValue(sIn[i].ToString(),i);
            }
 
            return retValue;
        }

        internal static void ConvertFile(string filein, string fileOut)
        {
            IFileConverter ifc = new FileConverter();
            ifc.ConvertFile(filein, fileOut);
        }


        internal static IList<string> MakeAnswerSection(Array item)
        {
            IAnswerSectionMaker asm = new AnswerSectionMaker();
            return asm.MakeAnswerSection(item);
        }

        internal static IList<string> MakeQuestionSection(Array item)
        {
            IQuestionSectionMaker asm = new QuestionSectionMaker();
            return asm.MakeQuestionSection(item);
        }
    }
}
