using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;


namespace Reflection

{
    /*
    class Module1
    {
        public static void Main()
        {
            Console.WriteLine("Пользуясь оказией System тоже ковырну ");
            // Эта переменная содержит величину отступа,
            // следует использовать при отображении каждой строки информации.
            Int32 indent = 0;
            // Вывести информацию о сборке EXE.
            Assembly a = typeof(Module1).Assembly;
            Display(indent, "Идентификатор сборки ={0}", a.FullName);
            Display(indent + 1, "Кодовая база ={0}", a.CodeBase);

            // Отображает набор сборок, на которые ссылаются наши сборки.

            Display(indent, "Ссылка на сборку:");
            foreach (AssemblyName an in a.GetReferencedAssemblies())
            {
                Display(indent + 1, "Имя={0}, Версия={1}, Culture={2}, Токен публичного ключа={3}", an.Name, an.Version, an.CultureInfo.Name, (BitConverter.ToString(an.GetPublicKeyToken())));
            }
            Display(indent, "");

            // Отображает информацию о каждоv загрузке сборки в этот AppDomain.
            foreach (Assembly b in AppDomain.CurrentDomain.GetAssemblies())
            {
                Display(indent, "Сборка: {0}", b);

                // Отображает информацию о каждом модуле этой сборки
                foreach (Module m in b.GetModules(true))
                {
                    Display(indent + 1, "Модуль: {0}", m.Name);
                }

                // Отображает информацию о каждом типе, экспортированном из этой сборки

                indent += 1;
                foreach (Type t in b.GetExportedTypes())
                {
                    Display(0, "");
                    Display(indent, "Тип: {0}", t);

                    // Для каждого типа показывает его элементы и настраиваемые атрибуты

                    indent += 1;
                    foreach (MemberInfo mi in t.GetMembers())
                    {
                        Display(indent, "Участник: {0}", mi.Name);
                        DisplayAttributes(indent, mi);

                        // Если член - это метод, то отображает информацию о его параметрах

                        if (mi.MemberType == MemberTypes.Method)
                        {
                            foreach (ParameterInfo pi in ((MethodInfo)mi).GetParameters())
                            {
                                Display(indent + 1, "Параметр: Тип={0}, Имя={1}", pi.ParameterType, pi.Name);
                            }
                        }

                        // Если член - это свойство, то отображает информацию  о методах доступа свойства
                        if (mi.MemberType == MemberTypes.Property)
                        {
                            foreach (MethodInfo am in ((PropertyInfo)mi).GetAccessors())
                            {
                                Display(indent + 1, "Метод доступа: {0}", am);
                            }
                        }
                    }
                    indent -= 1;
                }
                indent -= 1;
            }
            Console.WriteLine();
            Console.WriteLine("1.1");
            Console.WriteLine(typeof(int).Assembly.FullName);
            Console.WriteLine();
            Console.WriteLine("1.2");
            Console.WriteLine(typeof(int).Attributes);
            //1.3
            Console.WriteLine(); 
            Console.WriteLine("1.3");
            Type byteType = typeof(byte);
            Type intType = typeof(int);
            Console.WriteLine("Случай byte из int " + byteType.IsAssignableFrom(intType));
            Console.WriteLine("Случай int из byte " + intType.IsAssignableFrom(byteType));

            byte lol4to = 1;
            int lal4to = lol4to;
            Console.WriteLine(lal4to);
        }

        // Отображает настраиваемые атрибуты, применённые к указанному члену
        public static void DisplayAttributes(Int32 indent, MemberInfo mi)
        {
            // Получает набор настраиваемых атрибутов. Если их нет - return
            object[] attrs = mi.GetCustomAttributes(false);
            if (attrs.Length == 0) { return; }

            // Отображает настраиваемые атрибуты, применённые к этому члену
            Display(indent + 1, "Attributes:");
            foreach (object o in attrs)
            {
                Display(indent + 2, "{0}", o.ToString());
            }
        }

        // Отображает отформатированную строку с заданным отступом
        public static void Display(Int32 indent, string format, params object[] param)

        {
            Console.Write(new string(' ', indent * 2));
            Console.WriteLine(format, param);
        }

    }
}
    */

    // 2.2
    public class ImportantAttribute : Attribute { }

    public class Person
    {
        // 2.2
        [Important]
        public string name { get; set; }
        [Important]
        public string surname { get; set; }
        public int age { get; set; }


    }
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Разведка");
            // 1.3
            Console.Write("1.1\nНазвание сборки, содержащей int:\n");
            Console.WriteLine(typeof(int).Assembly.FullName + "\n");
            // 1.2
            Console.Write("1.2\nint помечен следующими атрибутами:\n");
            Console.WriteLine(typeof(int).Attributes + "\n");
            // 1.3
            Console.WriteLine("1.3");
            Type byteType = typeof(byte);
            Type intType = typeof(int);
            Console.WriteLine("Случай byte из int: " + byteType.IsAssignableFrom(intType));
            Console.WriteLine("Случай int из byte: " + intType.IsAssignableFrom(byteType));
            Console.WriteLine("\nВозвращает True, если \n" +
                              "1) Этот тип и текущий тип представляют один и тот же тип,\n" +
                              "2) Текущий тип находится в иерархии наследования этого типа,\n" +
                              "3) Текущий тип является интерфейсом, который этот тип реализует,\n" +
                              "4) Этот тип является параметром общего типа и текущий тип представляет одно из ограничений этого типа.\n" +
                              "Возвращает False, если ни одно из этих условий не является истинным, или если переменная имеет значение null.\n");
            
            Console.WriteLine("Атрибут");
            // 2.1
            // Attribute [Important]

            // 2.3
            List<MemberInfo> importantDataList = typeof(Person).GetMembers().Where(attribute => Attribute.IsDefined(attribute, typeof(ImportantAttribute))).ToList();

            Console.Write("2,3 ");

            foreach (MemberInfo importantData in importantDataList)
            {
                Console.Write($"{importantData.Name} ");
            }
        }
    }
}