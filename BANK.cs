using System;

namespace C_Project
{
    internal class BANK
    {
        
        static void Main(string[] args)
        {
            BankSystem.LogIn();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Main Menu ---");
                Console.WriteLine("1- Show Balance\n2- Deposit\n3- Withdraw\n4- Transfer\n5- Logout");
                int num = Convert.ToInt32(Console.ReadLine());
                switch (num)
                {
                    case 1:
                        BankSystem.ReturnBalance();
                break;

                    case 2:
                        BankSystem.Deposit();
                        break;

                    case 3:
                        BankSystem.Withdraw();
                        break;

                    case 4:
                        BankSystem.Transfer();
                        break;

                    
                    case 5:
                        Console.WriteLine("Logging out... Thank you!");
                        exit = true; 
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                       

                }
            }


        }
    }
    class BankSystem
    {
        static int[] IDS = { 1, 2, 3, 4 };
        static int[] PINS = { 111, 222, 333, 444 };
        static int[] BALANCE = { 1000, 2000, 3000, 4000 };
        static int ID,PIN , userIndex;
        public static void LogIn()
        {
            Console.WriteLine("**************** Welcom to bank system ****************");
            bool isValid = false;
            do
            {
                Console.Write("To log in plz Enter Account Number: ");
                ID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter PIN: ");
                PIN = Convert.ToInt32(Console.ReadLine());
                userIndex = Array.IndexOf(IDS, ID);
                if (userIndex != -1 && PINS[userIndex] == PIN)
                {
                    Console.WriteLine("LOG IN SUCCESSFULLY");
                    isValid = true;

                }
                else
                {
                    Console.WriteLine("logging in FAILD");
                }
            } while (!isValid);

        }      

        public static void ReturnBalance()
        {
            Console.WriteLine("Your current balance is:" + BALANCE[userIndex]);
       }
        public static void Withdraw()
        {
            bool isValidwithdraw = false;
            do { 

                Console.WriteLine("How much you want withdraw....");
                int Withdraw = Convert.ToInt32(Console.ReadLine());
                if (Withdraw <= BALANCE[userIndex]) {
                    BALANCE[userIndex] -= Withdraw;
                    Console.WriteLine("done successfully ,Your current balance is:" + BALANCE[userIndex]);
                    isValidwithdraw = true; 
                }
                else
                {
                Console.WriteLine("your balance less than what you want");
                }
            }while (!isValidwithdraw);
        }
        public static void Deposit()
        {
            Console.WriteLine("How much you want deposit....");
            int deposit = Convert.ToInt32(Console.ReadLine());
            BALANCE[userIndex] += deposit;
            Console.WriteLine("done successfully ,Your current balance is:" + BALANCE[userIndex]);

        }
        public static void Transfer()
        {
            bool isValid = false;
            do
            {
                Console.Write("Enter Account Number: ");
                int tranID = Convert.ToInt32(Console.ReadLine());
                int indexTransferId = Array.IndexOf(IDS, tranID);
                Console.Write("How much you want trans....");
                int transbalance = Convert.ToInt32(Console.ReadLine());
               
                if (indexTransferId !=-1 && BALANCE[userIndex] >= transbalance)
                {
                    BALANCE[userIndex] -= transbalance;
                    BALANCE[indexTransferId] += transbalance;
                    Console.WriteLine("done SUCCESSFULLY , your current balance is " + BALANCE[userIndex]);
                    isValid = true;

                }
                else
                {
                    Console.WriteLine("faild to transfer");
                }

            } while (!isValid);
     
        }
    }
}
