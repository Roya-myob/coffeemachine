using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Net;

namespace CoffeeMachine
{
    public class Protocol
    {
        private string _stringProtocol;
        private List<string> extractedMessage = new List<string>();

        public Protocol(string stringProtocol)
        {
            _stringProtocol = stringProtocol;
        }

        public string ExtractCommand()
        {
            string[] subs = _stringProtocol.Split(':');
            var drink = "";
            var hotDrink = "";
            
            if (subs[0].Length > 1)
            {
                 drink = GetDrink(subs[0].Substring(0,1));
                string subForHotDrink = subs[0].Substring(1,1);
                hotDrink = GetTempreture(subForHotDrink);
            }

            if (subs[0].Length <= 1)
            {
                 drink = GetDrink(subs[0]);
            }
            
           
           
            var sugar = GetSugar(subs[1]);
            var stick = "";

            if (sugar.Contains("1 sugar") || sugar.Contains("2 sugars"))
            {
                stick = "and a stick";
            }

            if (drink.Contains("orange juice"))
            {
                return $"Drink maker makes 1 {drink}";
            }

            return $"Drink maker makes 1 {hotDrink}{drink} with {sugar}{stick}";

        }

        public string GetTempreture(string tempreture)
        {
            var tempreturePartOfTheSentence = "";
            switch (tempreture)
            {
                case "h":
                    tempreturePartOfTheSentence = "extra hot ";
                    break;
                default:
                    tempreturePartOfTheSentence = "";
                    break;
            }

            return tempreturePartOfTheSentence;
        }
        
        


        public string GetDrink(string drink)
        {
            var drinkPartOfTheSentence = "";
            switch (drink)
            {
                case "T":
                    drinkPartOfTheSentence = "tea";
                    break;
                case "C":
                    drinkPartOfTheSentence = "coffee";
                    break;
                case "H":
                    drinkPartOfTheSentence = "chocolate";
                    break;
                case "O":
                    drinkPartOfTheSentence = "orange juice";
                    break;
                default:
                    drinkPartOfTheSentence = "";
                    break;
            }

            return drinkPartOfTheSentence;
        }
        public string GetSugar(string sugar)
        {
            var sugarPartOfTheSentence = "";
            switch (sugar)
            {
                case "1":
                    sugarPartOfTheSentence = "1 sugar ";
                    break;
                case "2":
                    sugarPartOfTheSentence = "2 sugars ";
                    break;
                default:
                    sugarPartOfTheSentence = "no sugar";
                    break;
            }

            return sugarPartOfTheSentence;
        }
        
      
       }
}