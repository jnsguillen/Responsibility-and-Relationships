using System;

namespace BusinessLayer
{
    public class Menu
    {
        public static void selection() {

			Console.WriteLine("----------------------------------------");
			Console.WriteLine("EMPLOYEE LEAVES MANAGEMENT SYSTEM");
			Console.WriteLine("----------------------------------------");
			var CurrentDate = DateTime.Now;
			Console.WriteLine(CurrentDate);
			Console.WriteLine("Welcome User!");

			Start:
			int menu;
			Console.WriteLine("Type the number of which you wish to access: ");
			Console.WriteLine("----------------------------------------------");
			Console.WriteLine("\n1: Request Form \n2: Pending Requests \n3: Record of Leaves");
			menu = Convert.ToInt32(Console.ReadLine());

			switch (menu)
			{
				case 1:
					DataLayer.SqlData.InputRecord();
					goto Start;
					break;

				case 2:
					DataLayer.SqlData.ViewRequests();
					goto Start;
					break;

				case 3:
					DataLayer.SqlData.ShowRecords();
					goto Start;
					break;

				default:
					Console.WriteLine("No match found");
					goto Start;
					break;
			}
		}
    }
}
