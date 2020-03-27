using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAway
{
    class Program
    {
        public class Coffee
        {
            }
        public class Toast
        {

        }
        public class Juice
        {

        }
        public class Beacon { }
        public class Eggs { }

        static async Task Main(string[] args)
        {
            Coffee cup = makeCoffee();
            Console.WriteLine("Coffee ready!");

            var eggsTask = fryEggs(2);
            var beaconTask = makeBeacon(3);
            var toastTask = makeToastWithButterAndHam(2);
            var juiceTask = makeJuice();

            var allTasks = new List<Task> { eggsTask, beaconTask, toastTask, juiceTask };
            while (allTasks.Any())
            {
                Task finished = await Task.WhenAny(allTasks);
                if (finished == eggsTask)
                {
                    Console.WriteLine("Eggs ready!");
                    allTasks.Remove(eggsTask);
                    var eggs= await eggsTask;
                }else if(finished == beaconTask)
                {
                    Console.WriteLine("Beacon ready!");
                    allTasks.Remove(beaconTask);
                    var beacon = await beaconTask;
                }
                else if (finished == toastTask)
                {
                    Console.WriteLine("Toast ready");
                    allTasks.Remove(toastTask);
                    var toast = await toastTask;
                }
                else if (finished == juiceTask)
                {
                    Console.WriteLine("Juice ready!");
                    allTasks.Remove(juiceTask);
                    var juice = await juiceTask;
                }
                else
                {
                    allTasks.Remove(finished);
                }
            }
            
            Console.WriteLine("Breackfast ready!");
            Console.ReadLine();
        }

        async static Task<Toast>makeToastWithButterAndHam(int number)
        {
            var plainToast = await toastBread(number);
            putButter(plainToast);
            putHam(plainToast);
            return plainToast;

        }
        public static Coffee makeCoffee()
        {
            return new Coffee();
        }
        public static async Task<Eggs>fryEggs(int numEggs)
        {
            return new Eggs();
        }
        public static async Task<Beacon> makeBeacon(int numBeacon)
        {
            return new Beacon();
        }
        public static async Task<Toast>toastBread(int numToast)
        {
            return new Toast();
        }
        public static void putButter(Toast toast)
        {
            
        }
        public static void putHam(Toast toast)
        {

        }
        public static async Task<Juice>  makeJuice()
        {
            return new Juice();
        }
        public static async Task<Beacon> makeBeacon()
        {
            return new Beacon();
        }
    }
}
