using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Linq;

namespace Galgeleg
{
    
    class Weather
    {
        private string URLString = "https://www.yr.no/place/Denmark/Hovedstaden/K%C3%B8benhavn/forecast_hour_by_hour.xml";
        private string WeatherImgString = @"http://nrkno.github.io/yr-weather-symbols/png/100/";
        private string FileType = ".png";

        public void ReadWeather(Image ImgToChange)
        {
            // load the xml file
            XmlDocument doc = new XmlDocument();
            doc.Load(URLString);

            // get list and take values from first element (weather right now)
            XmlNodeList nodeList = doc.SelectNodes("/weatherdata/forecast/tabular/time/symbol");
            string name = nodeList[0].Attributes["name"].Value;
            string var = nodeList[0].Attributes["var"].Value;

            // setting background image to the image from yr.no
            string imageName = WeatherImgString + var + FileType;
            BitmapImage image = new BitmapImage(new Uri(imageName, UriKind.RelativeOrAbsolute));
            ImgToChange.Source = image;

            Console.WriteLine(name + " " + var);
        }
    }
}
