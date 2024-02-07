using System;
using System.Data;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore.Sqlite;
using TZ.Net;

class Solution
{
    private static MyDbContext context;
      

    static void Main(string[] args)
    {
        context = new MyDbContext();

        GetAllUsers();

        while (true)
        {

            Console.WriteLine("Выберите действие: \n" +
                "1)Добавить пользователя\n" +
                "2)Изменить данные о пользователе\n" +
                "3)Удалить пользователя\n" +
                "4)Вывести всех пользователей");

            if (int.TryParse(Console.ReadLine(), out int result))
            {
                switch (result)
                {
                    case 1:
                        AddUser();
                        break;
                    case 2:
                        EditUser();
                        break;
                    case 3:
                        DeleteUser();
                        break;
                    case 4:
                        GetAllUsers();
                        break;

                }
            }

        }
    }

    private static void AddUser()
    {
        Console.Clear();
        Console.WriteLine("Введите имя пользователя");
        var username = Console.ReadLine();
        Console.WriteLine("Введите дату рождения");
        if (!DateTime.TryParse(Console.ReadLine(), out var birth))
        {
            Console.WriteLine("Ошибка");
            return;
        }
        var user = new User { FIO = username, Birthdate = birth.ToUniversalTime() };

        context.Users.Add(user);
        context.SaveChanges();

        Console.WriteLine($"Пользователь {username} был добавлен");


    }

    public static void GetAllUsers()
    {
        Console.Clear();
        Console.WriteLine("Список всех дней рождения");
        foreach (var user in context.Users)
        {
            Console.WriteLine($"{user.FIO,2} {user.Birthdate,2}");

        }
        Console.WriteLine("Нажмите любую клавишу чтобы продолжить");
        Console.ReadKey();

    }
    private static void DeleteUser()
    {
        Console.WriteLine("Введите имя пользователя");
        var username = Console.ReadLine();

        var user = context.Users.Where(user => user.FIO == username).FirstOrDefault();

        if (user == null)
        {
            Console.WriteLine("Пользователь не найден");
            return;
        }
        context.Users.Remove(user);
        context.SaveChanges();

    }

    private static void EditUser()
    {
        Console.WriteLine("Введите имя пользователя");
        var username = Console.ReadLine();

        var user = context.Users.Where(user => user.FIO == username).FirstOrDefault();

        if (user == null)
        {
            Console.WriteLine("Пользователь не найден");
            return;
        }
        context.Users.Remove(user);

        context.Users.Remove(user);
        Console.WriteLine("Введите новое имя пользователя");
        username = Console.ReadLine();
        Console.WriteLine("Введите новую дату рождения");
        if (!DateTime.TryParse(Console.ReadLine(), out var birth))
        {
            Console.WriteLine("Ошибка");
            return;
        }
        user = new User { FIO = username, Birthdate = birth.ToUniversalTime() };

        context.Users.Add(user);
        context.SaveChanges();

        Console.WriteLine($"Пользователь {username} был добавлен");

    }



}