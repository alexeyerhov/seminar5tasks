


// Создайте метод, который принимает список действий ( делегат Action ) и выполняет их последовательно

using seminar5;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

var listOfActions = new List<Action>();

void Print1()
{
    Console.WriteLine("111");
}
void Print2()
{
    Console.WriteLine("222");
}
void Print3()
{
    Console.WriteLine("333");
}

void doAction(List<Action> list)
{
    foreach (Action action in list)
    {
        action();
    }
}

listOfActions.Add(Print1);
listOfActions.Add(Print2);
listOfActions.Add(Print3);

doAction(listOfActions);

Console.WriteLine(String.Empty);

// ---------------------------

List<MyDeligate> myDeligates = new List<MyDeligate>()
    {
        (message =>  Console.WriteLine($"1st deligate {message}")),
        (message =>  Console.WriteLine($"2st deligate {message}"))
    };


static void PrintDeligate(List<MyDeligate> list)
{
    foreach (var item in list)
    {
        item("333");
    }
}

PrintDeligate(myDeligates);

Console.WriteLine(String.Empty);

// --------------

/* Спроектируйте интерфейс калькулятора, поддерживающего простые 
 * арифмитичесие действия, хранящего результат и также способного
 * выводить информацию о результате при помощи события */


var calc = new Calculate();
calc.MyEventHandler += Calculate_MyEventHandler;
calc.MyEventHandler += Congrat_MyEventHandler; ;

calc.Sub(10);
calc.Sum(5);
calc.Multy(2);
calc.Divide(5);

calc.CancelLast();
calc.CancelLast();
calc.CancelLast();


static void Calculate_MyEventHandler(object? sender, EventArgs e)
{
    if(sender is Calculate)
    {

        Console.WriteLine(((Calculate)sender).result);
    }
    
}

static void Congrat_MyEventHandler(object? sender, EventArgs e)
{
    Console.WriteLine("-----------------------------");
}

Console.WriteLine(String.Empty);

// --------------

/* Нужно добавить в интерфейс метод, который будет отменять последнюю операцию. Арифметические методы
 * должны выполнять как обычно, а метод CancelLast должен отменять последнее действие. При этом метод 
 * может отменить последовательно все действия вплоть до самого последнего. 
 */


Console.WriteLine(String.Empty);

// -------------------------

/* Создайте метод, который принимает список строк, функцию ( делегат Func ) для преборазования 
 * строки в число в число и действие ( делегат Action ) для выполнения какого-либо действия с числом
*/


List<string> list = new List<string>() { "1", "2", "3" };

ConvertStringsToNumbers(list, int.Parse, (x) => Console.WriteLine(x));

static void ConvertStringsToNumbers(List<string> listStr, Func<string, int> funcParser, Action<int> action)
{
     foreach(var item in listStr)
    {
        int res = funcParser(item);
        action(res);
    }
}

Console.WriteLine(String.Empty);

// 

/* Пишет женерик делегаты */
/* В данном примере public delegate TResult MyFunc<T, TResult>(T arg) - это обобщенный
 делегат, который принимает аргумент типа 'T' и возвращает щначение типо 'TResult'
Мы создайм экземпляры этого делегата и передаем им методы, соответствующие сигнатуре делегата
*/

MyFunc<int, string> intToString = ConvertIntToString;
MyFunc<double, int> doubleToInt = ConvertDoubleToInt;


static string ConvertIntToString(int value)
{
    return value.ToString();
}
static int ConvertDoubleToInt(double value)
{
    return (int)value;
}


Console.WriteLine(intToString(57));
Console.WriteLine(doubleToInt(25.5));


Console.WriteLine(String.Empty);

// 

/* Создайте метод, который принимает условие возраст, а мы проверяем, является ли этот человек совершеннолетним */

List<string> strings = new List<string> { "18", "25", "13" };

static void IsAdult(List<string> ages, Func<string, int> func, Predicate<int> predicate, Action<int> action)
{
    foreach (var age in ages)
    {
        int res = func(age);
        if (predicate(res)) action(res);
    }
}

IsAdult(strings, int.Parse, x => x >= 18, x => Console.WriteLine(x + " Совершеннолетний"));







public delegate TResult MyFunc<T, TResult>(T arg);
public delegate void MyDeligate(string message);

