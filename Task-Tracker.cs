using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Tracker
{
    internal class Program
    {
        static int taskCounter = -1;
        const int MAX_TASKS = 100;
        static string[] taskTitle = new string[MAX_TASKS];
        static string[] taskDescription = new string[MAX_TASKS];
        static string[] taskDate = new string[MAX_TASKS];
        static string[] taskPriority = new string[MAX_TASKS];
        static string[] taskStatus = new string[MAX_TASKS];

        static void Main(string[] args)
        {
            Console.WriteLine("Hello and Welcome to Task Tracker by Ahmed Gamal Al-Sharkawi.");
            Console.WriteLine("--------------------------------------------------------------");
            while (true)
            {
                Console.Write("Choose an option:\n1: Add task\n2: Update task status\n3: View tasks\n4: Delete task\n5: Exit\nEnter your choice: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input, please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1: AddTask(); break;
                    case 2: UpdateStatus(); break;
                    case 3: ViewTasks(); break;
                    case 4: DeleteTask(); break;
                    case 5: if (ConExit()) return; break;
                    default: Console.WriteLine("Invalid choice, try again."); break;
                }
            }
        }

        static void AddTask()
        {
            if (taskCounter >= MAX_TASKS - 1)
            {
                Console.WriteLine("Task limit reached.");
                return;
            }

            taskCounter++;
            Console.WriteLine("Enter task details:");
            Console.Write("Title: ");
            taskTitle[taskCounter] = Console.ReadLine();
            Console.Write("Description: ");
            taskDescription[taskCounter] = Console.ReadLine();
            Console.Write("Due Date (DD/MM/YYYY): ");
            taskDate[taskCounter] = Console.ReadLine();
            Console.Write("Priority (High/Medium/Low): ");
            while (true)
            {
                string priority = Console.ReadLine();
                if (priority == "High" || priority == "Medium" || priority == "Low")
                {
                    taskPriority[taskCounter] = priority;
                    break;
                }
                Console.Write("Invalid priority. Enter High, Medium, or Low: ");
            }
            taskStatus[taskCounter] = "Pending";
            Console.WriteLine("Task added successfully!\n");
        }

        static void UpdateStatus()
        {
            if (taskCounter == -1)
            {
                Console.WriteLine("No tasks available to update.");
                return;
            }
            ViewTasks();
            Console.Write("Enter task number to update status: ");
            int taskNum = int.Parse(Console.ReadLine()) - 1;
            if (taskNum < 0 || taskNum > taskCounter)
            {
                Console.WriteLine("Invalid task number.");
                return;
            }
            Console.Write("Enter new status (Pending/In-Progress/Completed): ");
            while (true)
            {
                string status = Console.ReadLine();
                if (status == "Pending" || status == "In-Progress" || status == "Completed")
                {
                    taskStatus[taskNum] = status;
                    Console.WriteLine("Task status updated successfully!");
                    break;
                }
                Console.Write("Invalid status. Enter Pending, In-Progress, or Completed: ");
            }
        }

        static void ViewTasks()
        {
            if (taskCounter == -1)
            {
                Console.WriteLine("No tasks available.");
                return;
            }
            Console.WriteLine("\nTask List:");
            for (int i = 0; i <= taskCounter; i++)
            {
                Console.WriteLine($"{i + 1}. {taskTitle[i]} [{taskStatus[i]}] - Date: {taskDate[i]} - Priority: {taskPriority[i]}");
            }
            Console.WriteLine();
        }

        static void DeleteTask()
        {
            if (taskCounter == -1)
            {
                Console.WriteLine("No tasks available to delete.");
                return;
            }
            ViewTasks();
            Console.Write("Enter task number to delete: ");
            int taskNum = int.Parse(Console.ReadLine()) - 1;
            if (taskNum < 0 || taskNum > taskCounter)
            {
                Console.WriteLine("Invalid task number.");
                return;
            }
            for (int i = taskNum; i < taskCounter; i++) //Like Linked List when skipping a node and garbage collector is gonna delete it ...
            {
                taskTitle[i] = taskTitle[i + 1];
                taskDescription[i] = taskDescription[i + 1];
                taskDate[i] = taskDate[i + 1];
                taskPriority[i] = taskPriority[i + 1];
                taskStatus[i] = taskStatus[i + 1];
            }
            taskCounter--;
            Console.WriteLine("Task deleted successfully!");
        }

        static bool ConExit()
        {
            Console.Write("Are you sure you want to exit? (Yes / No): ");
            string input = Console.ReadLine().ToUpper();
            if (input == "YES")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
