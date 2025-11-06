using Calculator;
using System.Text;
using static System.Console;

OutputEncoding = Encoding.Unicode;
ICalculator calculator = new LightCalculator(new FullCalculator());
MenuCalculator menuCalculator = new MenuCalculator(calculator);
menuCalculator.Menu();


