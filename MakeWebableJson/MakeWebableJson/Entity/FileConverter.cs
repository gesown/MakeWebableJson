using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Converters;

using Microsoft.Ajax.Utilities;
using System.Json;
using System;
//using System.Text.Json.Nodes;

namespace MakeWebableJson.Facade
{
    internal class FileConverter : IFileConverter
    {
        private string fileInName;
        private IList<string> jC;
        private IEnumerable<string> ll;
        private IList<string> jA;
        private IList<string> lAll = new List<string>();

        public IList<Array> ConvertFile(string filein, string fileOut)
        {
            fileInName = Path.GetFileName(filein);
            IList<Array> listInJson = new List<Array>();
            IList<string> jvListOut = new List<string>();
            IList<string> listIn = File.ReadAllLines(filein).ToList();

            foreach (var item in listIn)
            {
                if (item.Length > 2)
                {
                    listInJson.Add(item.Split(new char[] { ',', '\"', '{', '}', ':' }, System.StringSplitOptions.RemoveEmptyEntries));
                }
            }
            foreach (Array item in listInJson)
            {
                if (item.GetValue(0).ToString() == "Question")
                {
                    if (lAll.Count() > 1)
                    {
                        var laC = lAll.Count();
                        var laCLast = lAll[laC - 1];
                        laCLast = laCLast.Substring(0, laCLast.Length - 2);
                        lAll[lAll.Count() - 1] = laCLast + "\"}},";
                    }
                    MWFacade.jKeysIx = 0; // resets key to "a"
                    jC = MWFacade.MakeQuestionSection(item);
                    ll = lAll.Concat(jC);
                    lAll = ll.ToList();
                    //    Concat(jC.AsEnumerable<string>()).ToList();
                    continue;
                }
                jA = MWFacade.MakeAnswerSection(item);
                ll = lAll.Concat(jA);
                lAll = ll.ToList();
            }
            File.WriteAllText(fileOut, "[");
            //            File.AppendAllText(fileOut, "}}]");
            // loose last comma and add }}]
            var laC1 = lAll.Count();
            var laCLast1 = lAll[laC1 - 1];
            laCLast1 = laCLast1.Substring(0, laCLast1.Length - 2);
            lAll[lAll.Count() - 1] = laCLast1 + "\"}}]";
            File.AppendAllLines(fileOut, lAll);


            return listInJson;
        }
    }
}