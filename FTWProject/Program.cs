using static System.Console;

//блок переменных
int maxlength = 3;
string[] BuiltInArray = new string[] { "hello", "2", "world", ":-)" };
int Counter = 0;
int buff = 0;

//Начало основной программы
Clear();
Write("Нажмите \"1\" для автоматического создания массива, \"2\" для ручного создания массива");
char choice = ReadKey().KeyChar;
WriteLine();
if (choice.Equals('1')) BuiltInArrayMethod();
if (choice.Equals('2')) ManualArrayMethod();
//Конец основной программы


void BuiltInArrayMethod()
{
    Counter = ArrayCountMax(BuiltInArray);
    PrintArray(FillOutputArray(BuiltInArray));
}


void ManualArrayMethod()
{
    WriteLine("Введите значения массива через пробел, по окончанию ввода нажмите Enter");
    string[] ManualArray = ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)//разделяем по пробелам, не записываем пустые
                            .ToArray();//превращаем значения в массив
    Counter = ArrayCountMax(ManualArray);
    PrintArray(FillOutputArray(ManualArray));
}

//метод подсчета количества подходящих по условию чисел
int ArrayCountMax(string[] InputArray)
{
    int result = 0;
    for (int i = 0; i < InputArray.Length; i++)
    {
        if (InputArray[i].Length <= maxlength) result++;
    }
    return result;
}

//создание нового массива из старого со значениями, удовлетворяющими условию задачи
string[] FillOutputArray(string[] WorkingArray)
{
    string[] result = new string[Counter];
    for (int j = 0; j < WorkingArray.Length; j++)
    {
        if (WorkingArray[j].Length <= maxlength)
        {
            result[buff] = WorkingArray[j];
            buff++;
        }
    }
    return result;
}

//Распечатываем массив
void PrintArray(string[] WorkingArray)
{
    Write("[");
    for (int i = 0; i < WorkingArray.Length; i++)
    {
        Write($"\"{WorkingArray[i]}\"");
        if (i < WorkingArray.Length - 1) Write(", ");
    }
    Write("]");
}