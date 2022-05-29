Console.Write("Число N: ");
int n = 50;
//Convert.ToInt32(Console.ReadLine());

int[] numbers = new int[n];
for (var i = 0; i < numbers.Length; i++)
{
    numbers[i] = i + 1;
}

int countFreeNum = 0;
int countGroups = 0;

while(countFreeNum != n)
{
    //Console.WriteLine(countFreeNum);
    int[] tempArray = new int[1];
    if(countFreeNum == 0)
    {
        tempArray[0] = numbers[countFreeNum];
        numbers[countFreeNum] = 0;
        countFreeNum++;
        countGroups++;
        PrintArray(tempArray);
        continue;
    }
    for (var i = 0; i < numbers.Length; i++)
    {
        if(numbers[i] == 0)
        {
            continue;
        }
        if(tempArray.Length == 1 && tempArray[0] == 0)
        {
            tempArray[0] = numbers[i];
            numbers[i] = 0;
            countFreeNum++;
            continue;
        }
        else if(tempArray[0] != 0)
        {
            bool access = true;
            for (var j = 0; j < tempArray.Length; j++)
            {
                if(!Evklid(numbers[i], tempArray[j]))
                {
                    access = false;
                    break;
                }
            }
            if(access)
            {
                Array.Resize(ref tempArray, tempArray.Length + 1);
                tempArray[tempArray.Length - 1] = numbers[i];
                countFreeNum++;
                numbers[i] = 0;
            }
        }
    }
    countGroups++;
    PrintArray(tempArray);
}

void PrintArray(int[] array)
{
    Console.WriteLine($"Группа {countGroups}: ");
    for (var i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]} ");
    }
    Console.WriteLine();
}

bool Evklid(int m, int n)
{
    int nod;
    while(m != n)
    {
        if(m > n)
        {
            m -= n;
        }
        else
        {
            n -= m;
        }
    }
    nod = n;

    if(nod == 1)
    {
        return true;
    }
    else
    {
        return false;
    }
}

Console.WriteLine("-----------------------------------------------");
//-----------------------------------------------------------------------------//

double[] limits = new double[4] {1.1, 2.5, 2.2, 40};
int durationDrink = 15;
int maxPubs = 12;
int[] durationWalk = new int[maxPubs];

Random rnd = new Random();
Console.WriteLine("Временные расстояния: ");
for (var i = 0; i < durationWalk.Length; i++)
{
    durationWalk[i] = rnd.Next(15, 20);
    Console.Write(durationWalk[i] + " ");
}
Console.WriteLine();

for (var i = 0; i < limits.Length; i++)
{
    Console.WriteLine($"Друг {i + 1}");
    Counting(limits[i], 0);
}

void Counting(double limit, int countPubs)
{
    if(limit - 0.57 > 0 && countPubs != maxPubs)
    {
        countPubs++;
        Counting(limit - 0.57, countPubs);
    }
    else if(countPubs == maxPubs)
    {
        double multWalk = 0;
        for (var i = 0; i < countPubs; i++)
        {
            multWalk += durationWalk[i];
        }
        double resultDuration = durationDrink * countPubs + multWalk;
        Console.WriteLine($"Потрачено времени в пустую до падения на дно: {Math.Round(resultDuration, 2)}");
        Console.WriteLine($"Столько пабов поспособствовало: {countPubs}");
        Console.WriteLine($"Всего времени пил: {Math.Round(resultDuration - multWalk, 2)}");
        return;
    }
    else
    {
        double resultDuration = durationDrink * countPubs;
        double multWalk = 0;
        countPubs++;
        for (var i = 0; i < countPubs; i++)
        {
            multWalk += durationWalk[i];
        }
        resultDuration += multWalk;
        resultDuration += (limit * durationDrink / 0.57);

        Console.WriteLine($"Потрачено времени в пустую до падения на дно: {Math.Round(resultDuration, 2)}");
        Console.WriteLine($"Столько пабов поспособствовало: {countPubs}");
        Console.WriteLine($"Всего времени пил: {Math.Round(resultDuration - multWalk, 2)}");
    }
}
