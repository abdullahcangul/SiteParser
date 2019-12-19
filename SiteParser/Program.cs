using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SiteParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser=new Parser();
            parser.siteParser("https://www.haberturk.com/");
           

        }

    }
}

