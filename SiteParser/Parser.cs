using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SiteParser
{
    class Parser
    {
        public void siteParser(String link)
        {
            HtmlDocument document = new HtmlAgilityPackFactory().Factory(link);

            String innerText = document.DocumentNode.InnerText;
            String[] words = regulationWords(innerText);

            var sortedlist = addOrUpdateSortedDictionary(words);

            displayWord(sortedlist);

        }

        private String[] regulationWords(string innerText)
        {
            innerText = innerText.ToLower();
            innerText = innerText.Replace("-", String.Empty);
            innerText = innerText.Replace("\n", String.Empty);
            innerText = innerText.Replace("\r", String.Empty);
            innerText = innerText.Replace("\t", String.Empty);
            innerText = innerText.Replace(".", String.Empty);
            innerText = innerText.Replace(",", String.Empty);
            innerText = innerText.Replace("(", String.Empty);
            innerText = innerText.Replace(")", String.Empty);
            innerText = innerText.Replace("  ", String.Empty);

            string[] words= innerText.Split(" ");
          
            return words;
        }

        private  IOrderedEnumerable<KeyValuePair<string, int>> addOrUpdateSortedDictionary(String[] words)
        {
            var textListesi = new Dictionary<String, int>();

            foreach (var text in words)
            {
             
                 if (textListesi.ContainsKey(text))
                {
                    textListesi[text] = textListesi[text] + 1;
                }
                else
                {
                    textListesi.Add(text, 1);
                }

            }
            return textListesi.OrderByDescending(x => x.Value);
        }

        private  void displayWord(IOrderedEnumerable<KeyValuePair<string, int>> sortedlist)
        {
            foreach (KeyValuePair<string, int> pair in sortedlist)
            {
                Console.WriteLine($"{pair.Key}:{pair.Value}");
            }
        }
    }
}
