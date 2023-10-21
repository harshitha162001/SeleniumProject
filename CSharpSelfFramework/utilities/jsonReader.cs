using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelfFramework.utilities
{
    public class jsonReader
    {
        public string? extractData(String tokenName)//tokenName=username,password etc
        {
           String myJsonString= File.ReadAllText("utilities/testData.json");
           var jsonObject= JToken.Parse(myJsonString);
           return jsonObject.SelectToken(tokenName).Value<string>();//here we cant call products bcz its only string we want arrayofstring
        }
        public string[] extractDataArray(String tokenName)//tokenName=username,password etc
        {
            String myJsonString = File.ReadAllText("utilities/testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            List<String> productsList= jsonObject.SelectTokens(tokenName).Values<string>().ToList();
            return productsList.ToArray();
        }     

    }
}
