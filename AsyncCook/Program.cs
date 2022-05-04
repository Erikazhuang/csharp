using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncCook
{
    class Program
    {
        static async Task Main(string[] args)
        {
           
            Coffee cup = PourCoffee();
            System.Console.WriteLine("coffee is ready");

            //async call, no wait
            var eggsTask = FryEggAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> {eggsTask, baconTask, toastTask};

            while(breakfastTasks.Count>0)
            {
                //get any finished task
                Task finishedTask = await Task.WhenAny(breakfastTasks);

                if (finishedTask == eggsTask)
                {
                    System.Console.WriteLine("eggs are ready");
                }
                else if (finishedTask==baconTask)
                {
                    System.Console.WriteLine("bacon is ready");
                }
                else if (finishedTask==toastTask)
                {
                    System.Console.WriteLine("toast is ready");
                }

                breakfastTasks.Remove(finishedTask);
            }

            Juice oj = PourJuice();
            System.Console.WriteLine("juce is ready");
            System.Console.WriteLine("breakfast is ready!");
        }

        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);
            return toast;
        }

        private static Coffee PourCoffee()
        {   
            Console.WriteLine("Pouring coffee!");
            return new Coffee();
        }

        private static Juice PourJuice()
        {
            System.Console.WriteLine("pouring oragne juice");
            return new Juice();
        }
        private static void ApplyJam(Toast toast) => System.Console.WriteLine("putting jam on the toast");

        private static void ApplyButter(Toast toast) => System.Console.WriteLine("putting butter on the toast");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice =0 ; slice< slices; slice++)
            {
                System.Console.WriteLine("put a slice of brea in the toaster");
            }
            System.Console.WriteLine("start toasting...");
            await Task.Delay(300);
            System.Console.WriteLine("remove toast from toaster");
            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            System.Console.WriteLine($"putting {slices} slices of bacon in the pan");
            System.Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(300);

            for(int slice=0; slice<slices; slice++)
            {
                System.Console.WriteLine("flipping a slice of bacoe");
            }
            System.Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(300);
            System.Console.WriteLine("put bacon on plate");
            return new Bacon();
        }
        private static async Task<Egg> FryEggAsync(int howMany)
        {
            System.Console.WriteLine("Warming up the pan...");
            await Task.Delay(3000);
            System.Console.WriteLine($"cracking {howMany} eggs");
            System.Console.WriteLine("cooking the eggs...");
            await Task.Delay(300);
            System.Console.WriteLine("put eggs on plate.");
            return new Egg();
        }
    }

    public class Juice{}
    public class Coffee{}
    public class Egg{}
    public class Bacon{}

    public class Toast{}
}
