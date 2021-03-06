﻿using System;
using System.Collections.Generic;

namespace sol2
{
    abstract class Student
        {
            protected string name;
            protected string state;
            public Student()
            { }
            public Student(string s)
            {
                name = s;
            }
            public void Relax()
            {
                state += "Relax ";
            }
            public void Read()
            {
                state += "Read ";
            }
            public void Write()
            {
                state += "Write ";
            }
            public string GetName()
            {
                return name;
            }
            public string GetState()
            {
                return state;
            }
            public abstract void Study();
        }

        class Good_Student : Student
        {
            public Good_Student(string name)
                        : base(name)
            {
                state = "good ";
            }
            public override void Study()
            {
                Read();
                Write();
                Read();
                Write();
                Relax();
            }

        }

        class Bad_Student : Student
        {
            public Bad_Student(string name)
                        : base(name)
            {
                state = "bad ";
            }
            public override void Study()
            {
                Relax();
                Relax();
                Relax();
                Relax();
                Relax();
            }
        }
        class Group
        {
            private string GroupName;
            public List<Student> students = new List<Student>();
            public Group(string name)
            {
                GroupName = name;
            }
            public void AddStudent(Student s)
            {
                s.Study();
                students.Add(s);

            }
            public void GetInfo()
            {
                Console.WriteLine(GroupName);
                foreach (Student i in students)
                    Console.WriteLine(i.GetName());
            }
            public void GetFullInfo()
            {
                Console.WriteLine(GroupName);
                foreach (Student i in students)
                {
                    Console.WriteLine($"{i.GetName()} {i.GetState()}");
                }
            }
        }


        class Program
        {
            static void Help()
            {
                Console.WriteLine();
                Console.WriteLine("NEW_GROUP");
                Console.WriteLine("INFO");
                Console.WriteLine("FULL_INFO");
                Console.WriteLine("EXIT");
                Console.WriteLine();
            }

            static void Main(string[] args)
            {
                string s = "";
                List<Group> groups = new List<Group>();
                Help();
                while (true)
                {
                    s = Console.ReadLine();
                    if (s == "NEW_GROUP")
                    {
                        string groupname;
                        Console.Write("Напишiть назву групи: ");
                        groupname = Console.ReadLine();
                        Console.WriteLine();
                        Group g = new Group(groupname);
                        groups.Add(g);
                        Console.WriteLine("STOP: завершити додавання студентiв");
                        while (true)
                        {
                            string name;
                            string state;
                            Console.Write("Iмя студента: ");
                            name = Console.ReadLine();
                            if (name == "STOP")
                            {
                                Help();
                                break;
                            }

                            Console.Write("Cтан студента(good/bad): ");
                            state = Console.ReadLine();
                            if (state == "STOP")
                            {
                                Help();
                                break;
                            }

                            while (state != "good" && state != "bad" && state != "stop")
                            {
                                Console.WriteLine("ERROR");
                                Console.WriteLine("Стан студента(good/bad): ");
                                state = Console.ReadLine();
                                Console.WriteLine();
                            }
                            if (state == "STOP")
                            {
                                Help();
                                break;

                            }
                            if (state == "good")
                            {
                                g.AddStudent(new Good_Student(name));

                            }
                            else if (state == "bad")
                            {
                                g.AddStudent(new Bad_Student(name));
                            }
                        }

                    }
                    if (s == "INFO")
                    {
                        foreach (Group g in groups)
                            g.GetInfo();
                        Console.WriteLine();
                    }

                    if (s == "FULL_INFO")
                    {
                        foreach (Group gr in groups)
                            gr.GetFullInfo();
                        Console.WriteLine();
                    }
                    if (s == "EXIT")
                    {
                        break;
                    }
                    if (s != "NEW" && s != "INFO" && s != "FULL_INFO" && s != "EXIT")
                    {
                        Console.WriteLine("ERROR");
                    }
                }
            }
        }
    }
