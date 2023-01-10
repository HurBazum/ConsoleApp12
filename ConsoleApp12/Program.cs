using System.Xml.Serialization;

namespace ConsoleApp12
{
    abstract class A
    {
        public string? name;
        public string? description;
        public virtual string Description { get; private set; }
        public virtual string Name 
        { 
            get
            {
                return name;
            } 
            set
            {
                name = value;
            }
        }
    }
    class B : A
    {
        public override string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length > 5)
                {
                    name = value;
                }
                else
                {
                    name = "null";
                }
            }
        }
    }
    class C : A
    {
        public override string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != null)
                {
                    name = value;
                }
                else
                {
                    name = "null";
                }
            }
        }
    }
    class D<T, U> where T : A
    {
        U id;
        public T Value;
        public U Id
        {
            get
            {
                return id;
            }
            private set
            {
                id = value;
            }
        }
        public D(object idOfD, int choiceLetter, string s)
        {
            if (idOfD is string || idOfD is int)
            {
                Id = (U)idOfD;
            }
            switch (choiceLetter)
            {
                case 0:
                    Value = (T)Activator.CreateInstance(typeof(B));
                    Value.Name = s;
                    Console.WriteLine($"B {Value.Name} was created, its id is {Id}");
                    break;

                case 1:
                    Value = (T)Activator.CreateInstance(typeof(C));
                    Value.Name = s;
                    Console.WriteLine($"C {Value.Name} was created, its id is {Id}");
                    break;
            }
        }
        public D(T obj)
        {
            Console.WriteLine("D is created!");
        }
        public void ChangeValueName(string? str)
        {
            Value.Name = str;
            Console.WriteLine(Value.Name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<D<B, string>> dds = new List<D<B, string>>();
            List<D<C, int>> cds = new List<D<C, int>>();
            object Id;
            int i = 0;
            do
            {
                Console.WriteLine("Введите число: ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 0)
                {
                    Id = "jk" + $"{dds.Count}";
                    dds.Add(new D<B, string>(Id, 0, "aaabbb"));
                }
                if (choice == 1)
                {
                    Id = cds.Count;
                    D<C, int> dc = new D<C, int>(Id, 1, "h");
                }
                i++;
            } while (i < 2);
        }
    }
}