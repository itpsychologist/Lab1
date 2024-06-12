using System;

namespace ArithmeticProgressionApp
{
    class ArithmeticProgression
    {
        // Поля класу
        private double initialElement;
        private double progressionCoefficient;

        // Властивості для доступу до полів класу
        public double InitialElement
        {
            get { return initialElement; }
            set { initialElement = value; }
        }

        public double ProgressionCoefficient
        {
            get { return progressionCoefficient; }
            set { progressionCoefficient = value; }
        }

        // Конструктори класу
        public ArithmeticProgression(double initialElement, double progressionCoefficient)
        {
            this.initialElement = initialElement;
            this.progressionCoefficient = progressionCoefficient;
        }

        public ArithmeticProgression() : this(0, 1) { }

        // Перевизначення функції ToString
        public override string ToString()
        {
            return $"Initial Element: {initialElement}, Progression Coefficient: {progressionCoefficient}";
        }

        // Функція порівняння об'єктів на рівність
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            ArithmeticProgression other = (ArithmeticProgression)obj;
            return initialElement == other.initialElement && progressionCoefficient == other.progressionCoefficient;
        }

        public override int GetHashCode()
        {
            return initialElement.GetHashCode() ^ progressionCoefficient.GetHashCode();
        }

        // Функції додавання, віднімання прогресій
        public static ArithmeticProgression operator +(ArithmeticProgression ap1, ArithmeticProgression ap2)
        {
            return new ArithmeticProgression(ap1.initialElement + ap2.initialElement, ap1.progressionCoefficient + ap2.progressionCoefficient);
        }

        public static ArithmeticProgression operator -(ArithmeticProgression ap1, ArithmeticProgression ap2)
        {
            return new ArithmeticProgression(ap1.initialElement - ap2.initialElement, ap1.progressionCoefficient - ap2.progressionCoefficient);
        }

        // Функції множення прогресії на число
        public static ArithmeticProgression operator *(ArithmeticProgression ap, double number)
        {
            return new ArithmeticProgression(ap.initialElement * number, ap.progressionCoefficient * number);
        }

        // Додавання до прогресії числа
        public static ArithmeticProgression operator +(ArithmeticProgression ap, double number)
        {
            return new ArithmeticProgression(ap.initialElement + number, ap.progressionCoefficient);
        }

        // Функція знаходження суми перших n елементів прогресії
        public double SumOfFirstNElements(int n)
        {
            return n * (2 * initialElement + (n - 1) * progressionCoefficient) / 2;
        }

        // Функція отримання елемента прогресії із зазначеним номером
        public double GetElementByIndex(int index)
        {
            return initialElement + (index - 1) * progressionCoefficient;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Демонстрація функціональності класу
            ArithmeticProgression ap1 = new ArithmeticProgression(1, 2);
            ArithmeticProgression ap2 = new ArithmeticProgression(2, 3);

            Console.WriteLine("AP1: " + ap1);
            Console.WriteLine("AP2: " + ap2);

            ArithmeticProgression apSum = ap1 + ap2;
            ArithmeticProgression apDiff = ap1 - ap2;
            ArithmeticProgression apMult = ap1 * 2;
            ArithmeticProgression apAddNumber = ap1 + 5;

            Console.WriteLine("AP1 + AP2: " + apSum);
            Console.WriteLine("AP1 - AP2: " + apDiff);
            Console.WriteLine("AP1 * 2: " + apMult);
            Console.WriteLine("AP1 + 5: " + apAddNumber);

            int n = 5;
            Console.WriteLine($"Sum of first {n} elements of AP1: " + ap1.SumOfFirstNElements(n));

            int index = 3;
            Console.WriteLine($"Element at index {index} of AP1: " + ap1.GetElementByIndex(index));
        }
    }
}
