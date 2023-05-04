using System.Text.RegularExpressions;

string text = "Добро пожаловать в наш магазин, вот наши цены: 1 кг. яблоки - 90 руб., 2 кг. апельсины - 130 руб. Также в ассортименте орехи в следующей фасовке: 0.5 кг. миндаль - 500 руб";
Regex rd1 = new Regex(@"((?:\d+)?\.?\d+)?\sкг\.\s(\w+)\s\-\s(\d+)\sруб\.?"); 
var RawProducts = rd1.Matches(text);
foreach (Match RawProduct in RawProducts)
{
    foreach (Match ProductString in rd1.Matches(RawProduct.Value))
    {
        var SplitProduct = ProductString.Groups;
        Console.WriteLine($"{SplitProduct[2]} - {Convert.ToDouble(SplitProduct[3].Value) / Convert.ToDouble(SplitProduct[1].Value.Replace('.', ','))} руб/кг");
    }

}