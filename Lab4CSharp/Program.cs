using System.Numerics;

namespace Lab3CSharp
{
    internal class Program
    {
        class Point
        {
            protected int x, y;
            protected int c;
            public int X
            {
                get { return x; }
                set { x = value; }
            }
            public int Y
            {
                get { return y; }
                set { y = value; }
            }
            public int C
            {
                get { return c; }
            }

            public int this[int index]
            {
                get
                {
                    if (index < 0 || index > 2) throw new Exception("incorect index value");
                    else if(index == 0) return x;
                    else if(index == 1) return y;
                    else return c;
                }
            }

            public Point()
            {
                this.x = 0;
                this.y = 0;
            }
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public void Show()
            {
                Console.WriteLine("X: {0}", x);
                Console.WriteLine("Y: {0}", y);
            }
            public double Distance()
            {
                return Math.Sqrt(x * x + y * y);
            }
            public void Vector(int x1, int y1)
            {
                this.x += x1;
                this.y += y1;
            }

            public static Point operator ++(Point p)
            {
                p.x += 1;
                p.y += 1;
                return p;
            }
            public static Point operator --(Point p)
            {
                p.x -= 1;
                p.y -= 1;
                return p;
            }
            public static bool operator true(Point p)
            {
                if (p.x != p.y) return false;
                return true;
            }
            public static bool operator false(Point p) 
            { 
                if (p.x == p.y) return true;
                return false;
            }
            public static Point operator +(Point p, int s)
            {
                p.x += s;
                p.y += s;
                return p;
            }

        }
        static void task1()
        {
            /*
            Завдання 1. Варіанти задач. Для розв’язання задачі згідно варіанту створити клас із полями, 
            конструкторами, методами та властивостями. 
            До запропонованих полів, методів та властивосте можна додавати власні. 

            1.1. Задано масив точок. Вивести в консоль інформацію про точку та відстань до центра координат. 
            Точки які знаходяться більше середньої відстані, перемістити на заданий вектор. 
            Створити клас Point, розробивши такі елементи класу:
             Поля (захищені):
                 координати точки ( int x, y);
                 колір точки ( int с );
             Конструктори, що дозволяють створити екземпляр класу:
                 з нульовими координатами;
                 із заданими координатами.
             Методи, що дозволяють:
                 вивести координати точки на екран;
                 розрахувати відстань від початку координат до точки;
                 перемістити точку на вектор з координатами (x1, y1).
             Властивості:
                 отримати-встановити координати точки (доступні для 
                читань і запису);
                 отримати колір точки (доступна тільки для читання) 
             */
            /*
            Доповнити клас створений в лабораторній роботі №3 згідно варіанту. 
            До запропонованих полів, методів та властивосте можна додавати власні. 
            1.1. У клас Point додати:
             Індексатор, що дозволяє по індексу 0 звертатися до поля x, по індексу 1 - до поля y, по індексу 2 – до поля колір, 
            а при інших значеннях індексу видається повідомлення про помилку. 
                 Перевантаження: 
             операції ++ (--): одночасно збільшує (зменшує) значення полів х та y на 1; 
             сталих true і false: звертання до екземпляра класу дає значення true, якщо значення полів х та y рівне, інакше false; 
             операції бінарний +: одночасно додає до полів х та y значення скаляра; 
             перетворення типу Point в string ( і навпаки).
             */


            Point[] points = new Point[5];
            points[0] = new Point(5, 9);
            points[1] = new Point(2, -3);
            points[2] = new Point(6, 7);
            points[3] = new Point(1, 5);
            points[4] = new Point(-4, 2);
            double avgDistance = 0;

            for (int i = 0; i < points.Length; i++)
            {
                points[i].Show();
                Console.WriteLine(points[i].Distance());
                avgDistance += points[i].Distance();
            }
            avgDistance /= points.Length;

            for (int i = 0; i < points.Length; i++)
            {
                if (points[i].Distance() < avgDistance)
                {
                    points[i].Vector(10, 10);
                }
                points[i].Show();
            }

            Console.Write("index = ");
            int index = int.Parse(Console.ReadLine());
            try 
            { 
                Console.WriteLine("points[0][{0}] = {1}", index, points[0][index]); 
            } 
            catch (Exception e)
            { 
                Console.WriteLine(e.Message); 
            }

            points[0]++;
            points[0].Show();
            points[0]--;
            points[0].Show();

            if (points[0]) Console.WriteLine("true");
            else Console.WriteLine("false");

            Console.Write("scalar = ");
            int scalar = int.Parse(Console.ReadLine());
            points[0] = points[0] + scalar;
            points[0].Show();
        }

        class VectorInt
        {
            int[] IntArray; // масив
            uint size; // розмір вектора
            int codeError; // код помилки
            static uint num_vec; // кількість векторів

            public VectorInt()
            {
                IntArray = new int[1] { 0 };
                size = 1;
            }
            public VectorInt(uint size)
            {
                IntArray = new int[size];
                for(int i = 0; i < IntArray.Length; i++)
                {
                    IntArray[i] = 0;
                }
                this.size = size;
            }
            public VectorInt(uint size, int value)
            {
                IntArray = new int[size];
                for(int i = 0; i < IntArray.Length; i++)
                {
                    IntArray[i] = value;
                }
                this.size = size;
            }

            ~VectorInt()
            {
                Console.WriteLine("VectorInt destroyed");
            }

            public int this[int index]
            {
                get
                {
                    if (index < 0 || index >= IntArray.Length)
                    {
                        codeError = -1;
                        return 0;
                    }
                    else
                    {
                        codeError = 0;
                        return IntArray[index];
                    }
                }
                set
                {
                    codeError = -1;
                }
            }

            public void ValueEnter()
            {
                for (int i = 0; i < IntArray.Length; i++)
                {
                    Console.WriteLine("IntArray[{0}]: ", i);
                    IntArray[i] = int.Parse(Console.ReadLine());
                }
            }
            public void Show()
            {
                for(int i = 0; i < IntArray.Length; i++)
                {
                    Console.WriteLine("IntArray[{0}]: {1}", i, IntArray[i]);
                }
            }
            public void ParametrValue(int value)
            {
                for(int i = 0; i < IntArray.Length; i++)
                {
                    IntArray[i] = value;
                }
            }

            public uint Size
            { 
                get { return size; }
                private set { size = value; }
            }
            public int CodeError
            {
                get { return codeError; }
                set { codeError = value; }
            }

            public static VectorInt operator ++(VectorInt v)
            {
                for(int i = 0; i < v.size; i++)
                {
                    v[i] += 1;
                }
                return v;
            }
            public static VectorInt operator --(VectorInt v)
            {
                for (int i = 0; i < v.size; i++)
                {
                    v[i] -= 1;
                }
                return v;
            }

            public static bool operator true(VectorInt v)
            {
                if (v.size == 0) return false;
                for(int i = 0; i < v.size; i++)
                {
                    if (v[i] == 0) return false;
                }
                return true;
            }
            public static bool operator false(VectorInt v)
            {
                if (v.size != 0) return true;
                for (int i = 0; i < v.size; i++)
                {
                    if (v[i] != 0) return true;
                }
                return false;
            }

            public static bool operator !(VectorInt v)
            {
                if (v.size != 0) return true;
                return false;
            }

            public static VectorInt operator ~(VectorInt v)
            {
                VectorInt result = new VectorInt((uint)v.IntArray.Length);
                for (int i = 0; i < v.IntArray.Length; i++)
                {
                    result.IntArray[i] = ~v.IntArray[i];
                }
                return result;
            }

            public static VectorInt operator +(VectorInt v1, VectorInt v2)
            {
                if (v1.Size != v2.Size) 
                {
                    Console.WriteLine("Vectors must be the same size");
                    VectorInt res = new VectorInt();
                    return res;
                }

                VectorInt result = new VectorInt((uint)v1.IntArray.Length);
                for (int i = 0; i < v1.IntArray.Length; i++)
                {
                    result.IntArray[i] = v1.IntArray[i] + v2.IntArray[i];
                }
                return result;
            }
            public static VectorInt operator +(VectorInt v, int scalar)
            {
                VectorInt result = new VectorInt((uint)v.IntArray.Length);
                for (int i = 0; i < v.IntArray.Length; i++)
                {
                    result.IntArray[i] = v.IntArray[i] + scalar;
                }
                return result;
            }

            public static VectorInt operator -(VectorInt v1, VectorInt v2)
            {
                if (v1.Size != v2.Size) throw new Exception("Vectors must have the same size");

                VectorInt result = new VectorInt((uint)v1.IntArray.Length);
                for (int i = 0; i < v1.IntArray.Length; i++)
                {
                    result.IntArray[i] = v1.IntArray[i] - v2.IntArray[i];
                }
                return result;
            }
            public static VectorInt operator -(VectorInt v, int scalar)
            {
                VectorInt result = new VectorInt((uint)v.IntArray.Length);
                for (int i = 0; i < v.IntArray.Length; i++)
                {
                    result.IntArray[i] = v.IntArray[i] - scalar;
                }
                return result;
            }

            public static VectorInt operator *(VectorInt v1, VectorInt v2)
            {
                if (v1.Size != v2.Size) throw new Exception("Vectors must have the same size");

                VectorInt result = new VectorInt((uint)v1.IntArray.Length);
                for (int i = 0; i < v1.IntArray.Length; i++)
                {
                    result.IntArray[i] = v1.IntArray[i] * v2.IntArray[i];
                }
                return result;
            }
            public static VectorInt operator *(VectorInt v, int scalar)
            {
                VectorInt result = new VectorInt((uint)v.IntArray.Length);
                for (int i = 0; i < v.IntArray.Length; i++)
                {
                    result.IntArray[i] = v.IntArray[i] * scalar;
                }
                return result;
            }

            public static VectorInt operator /(VectorInt v1, VectorInt v2)
            {
                if (v1.Size != v2.Size) throw new Exception("Vectors must have the same size");

                VectorInt result = new VectorInt((uint)v1.IntArray.Length);
                for (int i = 0; i < v1.IntArray.Length; i++)
                {
                    if (v2.IntArray[i] == 0)
                    {
                        throw new Exception("Division by zero");
                    }
                    result.IntArray[i] = v1.IntArray[i] / v2.IntArray[i];
                }
                return result;
            }
            public static VectorInt operator /(VectorInt v, int scalar)
            {
                if (scalar == 0) throw new Exception("Division by zero");

                VectorInt result = new VectorInt((uint)v.IntArray.Length);
                for (int i = 0; i < v.IntArray.Length; i++)
                {
                    result.IntArray[i] = v.IntArray[i] / scalar;
                }
                return result;
            }

            public static VectorInt operator %(VectorInt v1, VectorInt v2)
            {
                if (v1.Size != v2.Size) throw new Exception("Vectors must have the same size");

                VectorInt result = new VectorInt((uint)v1.IntArray.Length);
                for (int i = 0; i < v1.IntArray.Length; i++)
                {
                    if (v2.IntArray[i] == 0) throw new Exception("Modulus by zero");
                    result.IntArray[i] = v1.IntArray[i] % v2.IntArray[i];
                }
                return result;
            }
            public static VectorInt operator %(VectorInt v, int scalar)
            {
                VectorInt result = new VectorInt((uint)v.IntArray.Length);
                for (int i = 0; i < v.IntArray.Length; i++)
                {
                    result.IntArray[i] = v.IntArray[i] % scalar;
                }
                return result;
            }

            public static VectorInt operator |(VectorInt v1, VectorInt v2)
            {
                if (v1.Size != v2.Size) throw new Exception("Vectors must have the same size");

                VectorInt result = new VectorInt((uint)v1.IntArray.Length);
                for (int i = 0; i < v1.IntArray.Length; i++)
                {
                    result.IntArray[i] = v1.IntArray[i] | v2.IntArray[i];
                }
                return result;
            }
            public static VectorInt operator |(VectorInt v, int scalar)
            {
                VectorInt result = new VectorInt((uint)v.IntArray.Length);
                for (int i = 0; i < v.IntArray.Length; i++)
                {
                    result.IntArray[i] = v.IntArray[i] | scalar;
                }
                return result;
            }

            public static VectorInt operator ^(VectorInt v1, VectorInt v2)
            {
                if (v1.Size != v2.Size) throw new Exception("Vectors must have the same size");

                VectorInt result = new VectorInt((uint)v1.IntArray.Length);
                for (int i = 0; i < v1.IntArray.Length; i++)
                {
                    result.IntArray[i] = v1.IntArray[i] ^ v2.IntArray[i];
                }
                return result;
            }
            public static VectorInt operator ^(VectorInt v, int scalar)
            {
                VectorInt result = new VectorInt((uint)v.IntArray.Length);
                for (int i = 0; i < v.IntArray.Length; i++)
                {
                    result.IntArray[i] = v.IntArray[i] ^ scalar;
                }
                return result;
            }

            public static VectorInt operator &(VectorInt v1, VectorInt v2)
            {
                if (v1.Size != v2.Size) throw new Exception("Vectors must have the same size");

                VectorInt result = new VectorInt((uint)v1.IntArray.Length);
                for (int i = 0; i < v1.IntArray.Length; i++)
                {
                    result.IntArray[i] = v1.IntArray[i] & v2.IntArray[i];
                }
                return result;
            }
            public static VectorInt operator &(VectorInt v, int scalar)
            {
                VectorInt result = new VectorInt((uint)v.IntArray.Length);
                for (int i = 0; i < v.IntArray.Length; i++)
                {
                    result.IntArray[i] = v.IntArray[i] & scalar;
                }
                return result;
            }

           /* public static VectorInt operator >>(VectorInt v1, VectorInt v2)
            {
                if (v1.Size != v2.Size) throw new ArgumentException("Vectors must have the same size");

                VectorInt result = new VectorInt((uint)v1.IntArray.Length);
                for (int i = 0; i < v1.IntArray.Length; i++)
                {
                    result.IntArray[i] = v1.IntArray[i] >> v2.IntArray[i];
                }
                return result;
            }*/
            public static VectorInt operator >>(VectorInt v, int scalar)
            {
                VectorInt result = new VectorInt((uint)v.IntArray.Length);
                for (int i = 0; i < v.IntArray.Length; i++)
                {
                    result.IntArray[i] = v.IntArray[i] >> scalar;
                }
                return result;
            }
           /* public static VectorInt operator <<(VectorInt v1, VectorInt v2)
            {
                if (v1.Size != v2.Size) throw new ArgumentException("Vectors must have the same size");

                VectorInt result = new VectorInt((uint)v1.IntArray.Length);
                for (int i = 0; i < v1.IntArray.Length; i++)
                {
                    result.IntArray[i] = v1.IntArray[i] << v2.IntArray[i];
                }
                return result;
            }*/
            public static VectorInt operator <<(VectorInt v, int scalar)
            {
                VectorInt result = new VectorInt((uint)v.IntArray.Length);
                for (int i = 0; i < v.IntArray.Length; i++)
                {
                    result.IntArray[i] = v.IntArray[i] << scalar;
                }
                return result;
            }

            public static bool operator ==(VectorInt v1, VectorInt v2)
            {
                if (v1.Size != v2.Size) return false;

                for (int i = 0; i < v1.IntArray.Length; i++)
                {
                    if (v1.IntArray[i] != v2.IntArray[i]) return false;
                }

                return true;
            }
            public static bool operator !=(VectorInt v1, VectorInt v2)
            {
                return !(v1 == v2);
            }
            public static bool operator >(VectorInt v1, VectorInt v2)
            {
                if (v1.Size != v2.Size) throw new ArgumentException("Vectors must have the same size");

                for (int i = 0; i < v1.IntArray.Length; i++)
                {
                    if (v1.IntArray[i] <= v2.IntArray[i]) return false;
                }

                return true;
            }
            public static bool operator >=(VectorInt v1, VectorInt v2)
            {
                if (v1.Size != v2.Size) throw new ArgumentException("Vectors must have the same size");

                for (int i = 0; i < v1.IntArray.Length; i++)
                {
                    if (v1.IntArray[i] < v2.IntArray[i]) return false;
                }

                return true;
            }
            public static bool operator <(VectorInt v1, VectorInt v2)
            {
                if (v1.Size != v2.Size) throw new ArgumentException("Vectors must have the same size");

                for (int i = 0; i < v1.IntArray.Length; i++)
                {
                    if (v1.IntArray[i] >= v2.IntArray[i]) return false;
                }

                return true;
            }
            public static bool operator <=(VectorInt v1, VectorInt v2)
            {
                if (v1.Size != v2.Size) throw new ArgumentException("Vectors must have the same size");

                for (int i = 0; i < v1.IntArray.Length; i++)
                {
                    if (v1.IntArray[i] > v2.IntArray[i]) return false;
                }

                return true;
            }
        }
        static void task2()
        {
            /*
             Cтворити клас вектор. Визначити поля, конструктори, деструктор, методи та перевантажити операції. 
            При перевантаженні бінарних операцій функції-операції виконує певні дії над кожною парою елементів масивів 
            в об’єктах класу вектор за індексом, якщо в функції-операції в параметрі скаляр 
            то операція відбувається на елементом масиву класу вектор та скаляром; 
            у випадку коли розміри векторів, тоді повертати більший за розміром вектор, 
            також можна виконати операцію над елементами з індексами, які допустимі у меншому векторі. 
            Функції-операції рівності та порівняння виконують дії(порівняння, рівності) над кожною парою елементів векторів за індексом, 
            повертає значення true, якщо умова виконується для кожної пари, інакше false. 
            Розробити програму тестування даного класу.

            Створити клас VectorInt (вектор цілих чисел). Розробити такі елементи класу:
             Поля (захищені):
             int [] IntArray; // масив
             uint size; // розмір вектора
             int codeError; // код помилки
             static uint num_vec; // кількість векторів

             Конструктори: 
             конструктор без параметрів(виділяє місце для одного елемента та ініціалізує його в нуль);
             конструктор з одним параметром - розмір вектора (виділяє місце та ініціалізує значенням нуль);
             конструктор із двома параметрами - розмір вектора та значення ініціалізації(виділяє місце - значення першого аргументу 
                        та ініціалізує значенням другого аргументу).

             Деструктор (виводить повідомлення в консоль).

             Методи, що дозволяють:
             ввести елементи вектора з клавіатури;
             вивести елементи вектора на екран;
            присвоєння елементам масиву вектора деякого значення, яке задається як параметр;
             статичний метод, що підраховує кількість векторів даного типу;
             присвоїти елементам масиву деяке значення (параметр);

             Властивості:
             повертає розмірність вектора (доступні лише для читання);
             дозволяє отримати-встановити значення поля codeError (доступні для читання і запису).
             Індексатор, що дозволяє звертатися по індексу до масиву, якщо значення індексу невірне в поле codeError записується -1
            (при читанні повертається значення – 0, при записі – запис здійснюється тільки в поле codeError); .
            
             Перевантаження: 
             унарних операції ++ (--): одночасно збільшує (зменшує) значення елементів масиву на 1; 
             сталих true і false: звертання до екземпляра класу дає значення true, якщо size не дорівнює – нулю, 
                        або всі елементи масиву не рівні – нулю, інакше false; 
             унарної логічної операції ! (заперечення): повертає значення true, якщо елементи якщо size не дорівнює –нулю, інакше false;
             унарної побітової операції ~ (заперечення): повертає побітове заперечення для всіх елементів масиву класу вектор;
             арифметичних бінарні операції ():
            a. + додавання:
            i. для двох векторів
            ii. для вектора і скаляра типу int
            b. - (віднімання): 
            i. для двох векторів
            ii. для вектора і скаляра типу int;
            c. *(множення) 
            i. для двох векторів
            ii. для вектора і скаляра типу int;
            d. / (ділення) 
            i. для двох векторів
            ii. для вектора і скаляра типу int;
            e. % (остача від ділення) 
            i. для двох векторів
            ii. для вектора і скаляра типу int;
             побітові бінарні операції 
            a. | (побітове додавання) 
            i. для двох векторів
            ii. для вектора і скаляра типу int;
            b. ^ (побітове додавання за модулем 2) 
            i. для двох векторів
            ii. для вектора і скаляра типу int;
            c. | (побітове множення) 
            i. двох векторів
            ii. вектора і скаляра типу int;
            d. >> (побітовий зсув право)
            i. для двох векторів
            ii. для вектора і скаляра типу int;
            e. << (побітовий зсув ліво)
            i. для двох векторів
            ii. для вектора і скаляра типу int;
             операцій ==(рівності) та != (нерівності), функціяоперація виконує певні дії над кожною парою елементів векторів за індексом;
             порівняння (функція-операція виконує певні дії над кожною парою елементів векторів за індексом)
            a. > (більше) для двох векторів; 
            b. >= (більше рівне) для двох векторів;
            c. < (менше) для двох векторів;
            d. <=(менше рівне) для двох векторів.
             */

            VectorInt vector1 = new VectorInt();
            Console.WriteLine("Vector1:");
            vector1.Show();

            VectorInt vector2 = new VectorInt(5);
            Console.WriteLine("Vector2:");
            vector2.Show();

            VectorInt vector3 = new VectorInt(3, 10);
            Console.WriteLine("Vector3:");
            vector3.Show();

            Console.WriteLine("Size of Vector3: " + vector3.Size);

            Console.WriteLine("Value at index 2 of Vector3: " + vector3[2]);
            vector3[2] = 20; 
            Console.WriteLine("Updated value at index 2 of Vector3: " + vector3[2]);

            Console.WriteLine("Enter new values for Vector1:");
            vector1.ValueEnter();
            Console.WriteLine("Vector1 after entering values:");
            vector1.Show();

            VectorInt vector4 = vector3 + vector1; 
            Console.WriteLine("Vector4 (vector3 + vector1):");
            vector4.Show();

            VectorInt vector5 = vector4 * 2; 
            Console.WriteLine("Vector5 (vector4 * 2):");
            vector5.Show();

            VectorInt vector6 = ~vector5; 
            Console.WriteLine("Vector6 (bitwise complement of vector5):");
            vector6.Show();

            if (vector1) Console.WriteLine("Vector1 is true");
            else Console.WriteLine("Vector1 is false");

            if (!vector1) Console.WriteLine("Vector1 is false");
            else Console.WriteLine("Vector1 is true");

            VectorInt vector7 = new VectorInt(3, 5);
            VectorInt vector8 = new VectorInt(3, 7);
            if (vector7 > vector8) Console.WriteLine("Vector7 > Vector8");
            else if (vector7 < vector8) Console.WriteLine("Vector7 is less than Vector8");
            else Console.WriteLine("Vector7 and Vector8 are equal");
        }

        class MatrixInt
        {
            private int[,] IntArray; 
            private int n, m;
            private int codeError; 
            private static int num_vec; 

            public MatrixInt()
            {
                n = 1;
                m = 1;
                codeError = 0;
                IntArray = new int[n, m];
                num_vec++;
            }

            public MatrixInt(int rows, int cols)
            {
                n = rows;
                m = cols;
                codeError = 0;
                IntArray = new int[n, m];
                num_vec++;
            }

            public MatrixInt(int rows, int cols, int initValue)
            {
                n = rows;
                m = cols;
                codeError = 0;
                IntArray = new int[n, m];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        IntArray[i, j] = initValue;
                    }
                }
                num_vec++;
            }

            ~MatrixInt()
            {
                Console.WriteLine("Matrix destroyed");
                num_vec--;
            }

            public void InputElementsFromConsole()
            {
                Console.WriteLine("Enter elements of the matrix:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write($"Element [{i},{j}]: ");
                        IntArray[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }
            }

            public void PrintElements()
            {
                Console.WriteLine("Matrix elements:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write($"{IntArray[i, j]} ");
                    }
                    Console.WriteLine();
                }
            }

            public void AssignValueToElements(int value)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        IntArray[i, j] = value;
                    }
                }
            }

            public static int GetNumberOfMatrices()
            {
                return num_vec;
            }

            public int Rows
            {
                get { return n; }
            }

            public int Columns
            {
                get { return m; }
            }

            public int ErrorCode
            {
                get { return codeError; }
                set { codeError = value; }
            }

            public int this[int i, int j]
            {
                get
                {
                    if (i >= 0 && i < n && j >= 0 && j < m)
                    {
                        codeError = 0;
                        return IntArray[i, j];
                    }
                    else
                    {
                        codeError = -1;
                        return 0;
                    }
                }
                set
                {
                    if (i >= 0 && i < n && j >= 0 && j < m)
                    {
                        IntArray[i, j] = value;
                    }
                    else
                    {
                        codeError = -1;
                    }
                }
            }

            public int this[int k]
            {
                get
                {
                    if (k >= 0 && k < n * m)
                    {
                        codeError = 0;
                        return IntArray[k / m, k % m];
                    }
                    else
                    {
                        codeError = -1;
                        return 0;
                    }
                }
            }

            public static MatrixInt operator ++(MatrixInt matrix)
            {
                for (int i = 0; i < matrix.n; i++)
                {
                    for (int j = 0; j < matrix.m; j++)
                    {
                        matrix.IntArray[i, j]++;
                    }
                }
                return matrix;
            }

            public static MatrixInt operator --(MatrixInt matrix)
            {
                for (int i = 0; i < matrix.n; i++)
                {
                    for (int j = 0; j < matrix.m; j++)
                    {
                        matrix.IntArray[i, j]--;
                    }
                }
                return matrix;
            }

            public static bool operator true(MatrixInt matrix)
            {
                if(matrix.n == 0 || matrix.m == 0) return false;
                for(int i = 0; i < matrix.n; i++)
                {
                    for(int j = 0; j < matrix.m; j++)
                    {
                        if (matrix.IntArray[i, j] == 0) return false;
                    }
                }
                return true;
            }

            public static bool operator false(MatrixInt matrix)
            {
                if (matrix.n != 0 && matrix.m != 0) return true;
                for (int i = 0; i < matrix.n; i++)
                {
                    for (int j = 0; j < matrix.m; j++)
                    {
                        if (matrix.IntArray[i, j] != 0) return true;
                    }
                }
                return false;
            }

            public static MatrixInt operator !(MatrixInt matrix)
            {
                MatrixInt result = new MatrixInt(matrix.n, matrix.m);
                for (int i = 0; i < matrix.n; i++)
                {
                    for (int j = 0; j < matrix.m; j++)
                    {
                        result[i, j] = matrix[i, j] == 0 ? 1 : 0;
                    }
                }
                return result;
            }

            public static MatrixInt operator ~(MatrixInt matrix)
            {
                MatrixInt result = new MatrixInt(matrix.n, matrix.m);
                for (int i = 0; i < matrix.n; i++)
                {
                    for (int j = 0; j < matrix.m; j++)
                    {
                        result[i, j] = ~matrix[i, j];
                    }
                }
                return result;
            }

            public static MatrixInt operator +(MatrixInt matrix1, MatrixInt matrix2)
            {
                if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
                {
                    Console.WriteLine("Matrix dimensions must be equal for addition.");
                    MatrixInt res = new MatrixInt();
                    return res;
                }

                MatrixInt result = new MatrixInt(matrix1.n, matrix1.m);
                for (int i = 0; i < matrix1.n; i++)
                {
                    for (int j = 0; j < matrix1.m; j++)
                    {
                        result[i, j] = matrix1[i, j] + matrix2[i, j];
                    }
                }
                return result;
            }

            public static MatrixInt operator +(MatrixInt matrix, int scalar)
            {
                MatrixInt result = new MatrixInt(matrix.n, matrix.m);
                for (int i = 0; i < matrix.n; i++)
                {
                    for (int j = 0; j < matrix.m; j++)
                    {
                        result[i, j] = matrix[i, j] + scalar;
                    }
                }
                return result;
            }

            public static MatrixInt operator -(MatrixInt matrix1, MatrixInt matrix2)
            {
                if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
                {
                    throw new ArgumentException("Matrix dimensions must be equal for subtraction.");
                }

                MatrixInt result = new MatrixInt(matrix1.n, matrix1.m);
                for (int i = 0; i < matrix1.n; i++)
                {
                    for (int j = 0; j < matrix1.m; j++)
                    {
                        result[i, j] = matrix1[i, j] - matrix2[i, j];
                    }
                }
                return result;
            }

            public static MatrixInt operator -(MatrixInt matrix, int scalar)
            {
                MatrixInt result = new MatrixInt(matrix.n, matrix.m);
                for (int i = 0; i < matrix.n; i++)
                {
                    for (int j = 0; j < matrix.m; j++)
                    {
                        result[i, j] = matrix[i, j] - scalar;
                    }
                }
                return result;
            }

            public static MatrixInt operator *(MatrixInt matrix1, MatrixInt matrix2)
            {
                if (matrix1.m != matrix2.n)
                {
                    Console.WriteLine("Number of columns in the first matrix must be equal to the number of rows in the second matrix for multiplication.");
                    MatrixInt res = new MatrixInt();
                    return res;
                }

                MatrixInt result = new MatrixInt(matrix1.n, matrix2.m);
                for (int i = 0; i < matrix1.n; i++)
                {
                    for (int j = 0; j < matrix2.m; j++)
                    {
                        int sum = 0;
                        for (int k = 0; k < matrix1.m; k++)
                        {
                            sum += matrix1[i, k] * matrix2[k, j];
                        }
                        result[i, j] = sum;
                    }
                }
                return result;
            }

            public static MatrixInt operator *(MatrixInt matrix, int scalar)
            {
                MatrixInt result = new MatrixInt(matrix.n, matrix.m);
                for (int i = 0; i < matrix.n; i++)
                {
                    for (int j = 0; j < matrix.m; j++)
                    {
                        result[i, j] = matrix[i, j] * scalar;
                    }
                }
                return result;
            }

            public static MatrixInt operator /(MatrixInt matrix1, MatrixInt matrix2)
            {
                if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
                {
                    throw new ArgumentException("Matrix dimensions must be equal for division.");
                }

                MatrixInt result = new MatrixInt(matrix1.n, matrix1.m);
                for (int i = 0; i < matrix1.n; i++)
                {
                    for (int j = 0; j < matrix1.m; j++)
                    {
                        result[i, j] = matrix1[i, j] / matrix2[i, j];
                    }
                }
                return result;
            }

            public static MatrixInt operator /(MatrixInt matrix, int scalar)
            {
                if (scalar == 0)
                {
                    throw new ArgumentException("Cannot divide by zero.");
                }

                MatrixInt result = new MatrixInt(matrix.n, matrix.m);
                for (int i = 0; i < matrix.n; i++)
                {
                    for (int j = 0; j < matrix.m; j++)
                    {
                        result[i, j] = matrix[i, j] / scalar;
                    }
                }
                return result;
            }

            public static MatrixInt operator %(MatrixInt matrix1, MatrixInt matrix2)
            {
                if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
                {
                    throw new ArgumentException("Matrix dimensions must be equal for modulus operation.");
                }

                MatrixInt result = new MatrixInt(matrix1.n, matrix1.m);
                for (int i = 0; i < matrix1.n; i++)
                {
                    for (int j = 0; j < matrix1.m; j++)
                    {
                        result[i, j] = matrix1[i, j] % matrix2[i, j];
                    }
                }
                return result;
            }

            public static MatrixInt operator %(MatrixInt matrix, int scalar)
            {
                if (scalar == 0)
                {
                    throw new ArgumentException("Cannot divide by zero.");
                }

                MatrixInt result = new MatrixInt(matrix.n, matrix.m);
                for (int i = 0; i < matrix.n; i++)
                {
                    for (int j = 0; j < matrix.m; j++)
                    {
                        result[i, j] = matrix[i, j] % scalar;
                    }
                }
                return result;
            }

            public static bool operator ==(MatrixInt matrix1, MatrixInt matrix2)
            {
                if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
                {
                    return false;
                }

                for (int i = 0; i < matrix1.n; i++)
                {
                    for (int j = 0; j < matrix1.m; j++)
                    {
                        if (matrix1[i, j] != matrix2[i, j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            public static bool operator !=(MatrixInt matrix1, MatrixInt matrix2)
            {
                return !(matrix1 == matrix2);
            }

            public static bool operator >(MatrixInt matrix1, MatrixInt matrix2)
            {
                if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
                {
                    throw new ArgumentException("Matrix dimensions must be equal for comparison.");
                }

                for (int i = 0; i < matrix1.n; i++)
                {
                    for (int j = 0; j < matrix1.m; j++)
                    {
                        if (matrix1[i, j] <= matrix2[i, j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            public static bool operator >=(MatrixInt matrix1, MatrixInt matrix2)
            {
                return matrix1 == matrix2 || matrix1 > matrix2;
            }

            public static bool operator <(MatrixInt matrix1, MatrixInt matrix2)
            {
                return !(matrix1 >= matrix2);
            }

            public static bool operator <=(MatrixInt matrix1, MatrixInt matrix2)
            {
                return !(matrix1 > matrix2);
            }

        }

        static void task3()
        {
            MatrixInt matrix1 = new MatrixInt();
            MatrixInt matrix2 = new MatrixInt(2, 3);
            MatrixInt matrix3 = new MatrixInt(3, 3, 5);

            Console.WriteLine($"Matrix 1 Dimensions: {matrix1.Rows}x{matrix1.Columns}");
            Console.WriteLine($"Matrix 2 Dimensions: {matrix2.Rows}x{matrix2.Columns}");
            Console.WriteLine("Matrix 3 Elements:");
            matrix3.PrintElements();

            Console.WriteLine("Enter elements for matrix:");
            matrix1.InputElementsFromConsole();
            Console.WriteLine("Matrix 1 Elements after Input:");
            matrix1.PrintElements();

            MatrixInt sum = matrix1 + matrix2;
            MatrixInt product = matrix1 * matrix2;
            MatrixInt scalarProduct = matrix1 * 2;

            Console.WriteLine("Matrix Sum:");
            sum.PrintElements();

            Console.WriteLine("Matrix Product:");
            product.PrintElements();

            Console.WriteLine("Scalar Product:");
            scalarProduct.PrintElements();

            Console.WriteLine("Matrix Comparison:");
            Console.WriteLine($"Matrix 1 == Matrix 2: {matrix1 == matrix2}");
            Console.WriteLine($"Matrix 1 != Matrix 2: {matrix1 != matrix2}");

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Lab 3 ");
            Console.Write("Enter task number: ");
            int task_id = int.Parse(Console.ReadLine());
            switch (task_id)
            {
                case 1:
                    task1();
                    break;
                case 2:
                    task2();
                    break;
                case 3:
                    task3();
                    break;
                default:
                    Console.WriteLine("No task under such number!");
                    break;
            }
        }
    }
}