using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Many_to_many_Relation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            using(var Db = new MyContextDb())
            {
                Db.Database.EnsureCreated();



                List<Course> courses = new List<Course>();
                List<Student> students = new List<Student>();

                /////////////////////////////////
                ///INSERT DATA 
                //Console.WriteLine("How many Courses you want to Add : ");
                //var nbrC = Convert.ToInt32(Console.ReadLine());

                //for (int i = 1; i <= nbrC; i++)
                //{
                //    Console.WriteLine("Enter the Name of Course  : " + i);
                //    var Curse_name = Console.ReadLine();
                //    courses.Add(new Course { CourseName = Curse_name });

                //}




                //Console.WriteLine("How many Students you want to Add : ");
                //var nbr = Convert.ToInt32(Console.ReadLine());

                //for (int i = 1; i <= nbr; i++)
                //{
                //    Console.WriteLine("Enter the Name of Student  : " + i);
                //    var St_name = Console.ReadLine();
                //    students.Add(new Student { StudentName = St_name, Courses = courses });
                //}


                //Db.Students.AddRange(students);
                //Db.Courses.AddRange(courses);

                //Db.SaveChanges();

                //////////////////////////////////////////////////////////
                ///
                /// UPDATE DATA 
                Console.WriteLine("Press C to Update Course  ");
                Console.WriteLine("Press S to Update Student ");
                char value = Convert.ToChar(Console.ReadLine());

                switch (value)
                {
                    case 'c':
                        {
                            Console.WriteLine("Enter the Name of course that you want to Update :");
                            var delC = Console.ReadLine();
                            var updateddata = Db.Courses.Include(c => c.Students).FirstOrDefault(c => c.CourseName == delC);

                            if (updateddata == null)
                            {
                                Console.WriteLine("You Enter the Invalid Name");
                            }
                            else
                            {
                                Console.WriteLine("Enter the New Name of Course");
                                var updated_name = Console.ReadLine();
                                updateddata.CourseName = updated_name;
                              //  Db.Courses.Update(updateddata);
                                Console.WriteLine($"\n{updateddata.CourseName} course is Updated ");
                                Db.SaveChanges();


                            }
                            break;

                        }

                    case 's':
                        {
                            Console.WriteLine("Enter The Course from which you want to Update Student  :");
                            var delC = Console.ReadLine();
                            var updateddata = Db.Courses.Include(c => c.Students).FirstOrDefault(c => c.CourseName == delC);
                            if (updateddata.Students == null)
                            {
                                Console.WriteLine("You Enter the Invalid Name");
                            }
                            else
                            {

                                Console.WriteLine("How many Students you want to Update ");
                                int delnbr = Convert.ToInt32(Console.ReadLine());
                                if (updateddata.Students.Count < delnbr)
                                {
                                    Console.WriteLine("Students are not Enough");
                                }
                                else
                                {
                                    for (int i = 1; i <= delnbr; i++)
                                    {
                                        Console.WriteLine("Enter the Student name that you want to Update  : ");
                                        var upd = Console.ReadLine();
                                        var updts = updateddata.Students.FirstOrDefault(s => s.StudentName == upd);
                                        if (updts == null)
                                        {
                                            Console.WriteLine("You Enter the Invalid name");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Enter the Updated Name of Student");
                                            var updated_name = Console.ReadLine();
                                            updts.StudentName = updated_name;
                                           // Db.Students.Update(updts);

                                        }


                                    }

                                }

                            }
                            break;

                        }

                    default:
                        {
                            Console.WriteLine("You Enter the Invalid ");
                            break;
                        }
                }





                //////////////////////////////////////////////////////////
                ///
                ////////  DELETE DATA 

                //Console.WriteLine("Press C to Delelte Course  ");
                //Console.WriteLine("Press S to Delelte Student ");
                //char value = Convert.ToChar(Console.ReadLine());

                //switch (value)
                //{
                //    case 'c':
                //        {
                //            Console.WriteLine("Enter the Name of course that you want to delete :");
                //            var delC = Console.ReadLine();
                //            var deleted = Db.Courses.Include(c => c.Students).FirstOrDefault(c => c.CourseName == delC);
                //            Db.Courses.RemoveRange(deleted);
                //            Console.WriteLine($"\n{deleted.CourseName} course is deleted ");
                //            break;
                //        }

                //    case 's':
                //        {
                //            Console.WriteLine("Enter The Course from which you want to delete Student  :");
                //            var delC = Console.ReadLine();
                //            var deleted = Db.Courses.Include(c => c.Students).FirstOrDefault(c => c.CourseName == delC);
                //            if (deleted.Students != null)
                //            {
                //                Console.WriteLine("How many Students you want to Delete ");
                //                int delnbr = Convert.ToInt32(Console.ReadLine());
                //                if(deleted.Students.Count < delnbr)
                //                {
                //                    Console.WriteLine("Students are not Enough");
                //                }
                //                else
                //                {
                //                    Console.WriteLine("Enter the Student name that you want to delete  : ");
                //                    var del = Console.ReadLine();
                //                    var dels = deleted.Students.FirstOrDefault(s => s.StudentName == del);
                //                    Db.Students.RemoveRange(dels);


                //                }


                //            }
                //            break;

                //        }

                //    default:
                //        {
                //            Console.WriteLine("You Enter the Invalid ");
                //            break;
                //        }
                //}

                //Db.SaveChanges();











                //////////////////////////////////////////////////////////
                ///
                /////// READ DATA

                var data = Db.Courses.Include(s => s.Students).ToList();
                
                foreach (var course in data)
                {
                    
                    Console.WriteLine("\n\nCourse Name :" + course.CourseName);

                    foreach(var student in course.Students)
                    {
                        Console.WriteLine("Student :"+student.StudentName);
                    }
                }
                
                
            }
        }
    }
}