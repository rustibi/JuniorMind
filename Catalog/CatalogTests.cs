using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog
{
    [TestClass]
    public class CatalogTests
    {

        [TestMethod]
        public void ShouldSortStudentsbyAverageGrade()
        {
            Student[] students = new Student[]
            {
                new Student("Paul", new Material[]
                {
                    new Material("Math", new int[] { 7, 7}),
                    new Material("English", new int[] { 7, 7}),
                    new Material("French", new int[] { 7, 7})
                }),
                new Student("Raul", new Material[]
                {
                    new Material("Math", new int[] { 6, 6}),
                    new Material("English", new int[] { 6, 6}),
                    new Material("French", new int[] { 6, 6})
                }),
                new Student("Alin", new Material[]
                {
                    new Material("Math", new int[] { 8, 8}),
                    new Material("English", new int[] { 8, 8}),
                    new Material("French", new int[] { 8, 8})
                }),
                 new Student("Zoro", new Material[]
                {
                    new Material("Math", new int[] { 6, 6}),
                    new Material("English", new int[] { 6, 6}),
                    new Material("French", new int[] { 6, 6})
                })
            };
            var result0 = new string[] { "Alin", "Paul", "Raul", "Zoro" };
            var result1 = new StudentAndAverageGrade[]
            {
                new StudentAndAverageGrade("Alin", 8),
                new StudentAndAverageGrade("Paul", 7),
                new StudentAndAverageGrade("Raul", 6),
                new StudentAndAverageGrade("Zoro", 6)
            };

            var function0 = SortAlphabetically(students);
            Assert.AreEqual(result0[0], function0[0].studentName);
            Assert.AreEqual(result0[3], function0[3].studentName);
            var function1 = SortStudentsbyAverageGrade(students);
            CollectionAssert.AreEqual(result1, function1);
            var function2 = FindStudentsWithLowestAverageGrade(students);
            CollectionAssert.AreEqual(new StudentAndAverageGrade[] { new StudentAndAverageGrade("Raul", 6), new StudentAndAverageGrade("Zoro", 6) }, function2);
            var function3 = FindStudentWitheSpecificAverageGrade(students, 7);
            CollectionAssert.AreEqual(new StudentAndAverageGrade[] { new StudentAndAverageGrade("Paul", 7) }, function3);
        }


        [TestMethod]
        public void ShouldReturnTheAverageGradesForOneMaterial()
        {
            Material material = new Material("English", new int[] { 10, 8, 6 });
            Assert.AreEqual(8, CalculateTheAverageGradesForOneMaterial(material));
        }


        [TestMethod]
        public void ShouldReturnTheAverageGradeFromOneStudent()
        {
            Student student = new Student("Paul", new Material[]
                {
                    new Material("Math", new int[] { 10, 10}),
                    new Material("English", new int[] { 9, 9}),
                    new Material("French", new int[] { 8, 8}),
                    new Material("History", new int[] { 7, 7}),
                    new Material("Spanish", new int[] { 6, 6, 6}),
                    new Material("Geography", new int[] { 5, 5, 5, 5}),
                    new Material("Romanian", new int[] { 4, 4}),
                    new Material("Economy", new int[] { 10, 10, 10}),
                    new Material("Sports", new int[] { 9, 9, 9}),
                    new Material("Biology", new int[] { 8, 8, 8}),
                    new Material("Info", new int[] { 7, 7, 7}),
                    new Material("Philosophy", new int[] { 6, 6, 6})
                });
            Assert.AreEqual(7.41, CalculateTheAverageGradeForOneStudent(student), 1);
            Assert.AreEqual(5, CountTheTenGradesFromAStudent(student));
        }


       [TestMethod]
       public void ShouldCountTheTenGradesFromAMaterial()
        {
            var material = new Material("Info", new int[] { 10, 8, 7, 10, 2, 10, 10, 5 });
            Assert.AreEqual(4, CountTheTenGradesFromAMaterial(material));
        }


        [TestMethod]
        public void ShouldReturnStudentsWithMostTenGrades()
        {
            Student[] students = new Student[]
            {
                new Student("Paul", new Material[]
                {
                    new Material("Math", new int[] { 10, 7}),
                    new Material("English", new int[] { 7, 10}),
                    new Material("French", new int[] { 10, 7})
                }),
                new Student("Raul", new Material[]
                {
                    new Material("Math", new int[] { 10, 6}),
                    new Material("English", new int[] { 6, 6}),
                    new Material("French", new int[] { 6, 10})
                }),
                new Student("Alin", new Material[]
                {
                    new Material("Math", new int[] { 10, 8}),
                    new Material("English", new int[] { 10, 8}),
                    new Material("French", new int[] { 10, 10})
                }),
                 new Student("Zoro", new Material[]
                {
                    new Material("Math", new int[] { 10, 6}),
                    new Material("English", new int[] { 6, 10}),
                    new Material("French", new int[] { 10, 10})
                })
            };
            var result = new StudentAndNoOfTen[]
            {
                new StudentAndNoOfTen("Alin", 4),
                new StudentAndNoOfTen("Zoro", 4)
            };
            var function = ReturnStudentsWithMostTenGrades(students);
            CollectionAssert.AreEqual(result, function);
        }



        public StudentAndNoOfTen[] ReturnStudentsWithMostTenGrades(Student[] students)
        {
            var max = CountTheTenGradesFromAStudent(students[0]);
            StudentAndNoOfTen[] bestStudents = new StudentAndNoOfTen[0];
            var counter = -1;
            for (int i = 1; i < students.Length; i++)
            {
                if (max < CountTheTenGradesFromAStudent(students[i]))
                {
                    max = CountTheTenGradesFromAStudent(students[i]);
                }
            }
            for (int i = 0; i < students.Length; i++)
            {
                if (max == CountTheTenGradesFromAStudent(students[i]))
                {
                    Array.Resize(ref bestStudents, bestStudents.Length + 1);
                    counter++;
                    bestStudents[counter] = new StudentAndNoOfTen(students[i].studentName, max);
                }
            }
            return bestStudents;
        }



        public int CountTheTenGradesFromAStudent(Student student)
        {
            var counter = 0;
            for(int i = 0; i < student.materials.Length; i++)
            {
                counter = counter + CountTheTenGradesFromAMaterial(student.materials[i]);
            }
            return counter;
        }



        public int CountTheTenGradesFromAMaterial (Material material)
        {
            var counter = 0;
            for(int i = 0; i < material.grade.Length; i++)
            {
                if(material.grade[i] == 10)
                {
                    counter++;
                }
            }
            return counter;
        }



        public StudentAndAverageGrade[] FindStudentWitheSpecificAverageGrade(Student[] students, int averageGrade)
        {
            StudentAndAverageGrade[] findTheStudent = new StudentAndAverageGrade[0];
            var counter = -1;
            for(int i = 0; i < students.Length; i++)
            {
                if (averageGrade == CalculateTheAverageGradeForOneStudent(students[i]))
                {
                    Array.Resize(ref findTheStudent, findTheStudent.Length + 1);
                    counter++;
                    findTheStudent[counter] = new StudentAndAverageGrade(students[i].studentName, averageGrade);
                }
            }
            return findTheStudent;
        }
    


        public StudentAndAverageGrade[] FindStudentsWithLowestAverageGrade(Student[] students)
        {
            StudentAndAverageGrade[] studentsLAG = new StudentAndAverageGrade[0];
            var min = CalculateTheAverageGradeForOneStudent(students[0]);
            var lowestGradeStudent = students[0];
            var counter = -1;
            for (int i = 1; i < students.Length; i++)
            {
                    if (min > CalculateTheAverageGradeForOneStudent(students[i]))
                    {
                        min = CalculateTheAverageGradeForOneStudent(students[i]);
                        lowestGradeStudent = students[i];
                    }
            }
            for (int i = 0; i < students.Length; i++)
            {
                if (min == CalculateTheAverageGradeForOneStudent(students[i]))
                {
                    Array.Resize(ref studentsLAG, studentsLAG.Length + 1);
                    counter++;
                    studentsLAG[counter] = new StudentAndAverageGrade(students[i].studentName, min);
                }
            }
            return studentsLAG;
        }



        public StudentAndAverageGrade[] SortStudentsbyAverageGrade (Student[] students)
        {
            for(int i = 0; i < students.Length; i++)
            {
                for(int j = i + 1; j < students.Length; j++)
                {
                    if (CalculateTheAverageGradeForOneStudent(students[i]) <
                        CalculateTheAverageGradeForOneStudent(students[j]))
                    {
                        Change(ref students[i], ref students[j]);
                    }
                }
            }
            StudentAndAverageGrade[] list = new StudentAndAverageGrade[students.Length];
            for (int i = 0; i < students.Length; i++)
            {
                var averageGrade = CalculateTheAverageGradeForOneStudent(students[i]);
                list[i] = new StudentAndAverageGrade(students[i].studentName, averageGrade);
            }
            return list;
        }



        public double CalculateTheAverageGradeForOneStudent(Student student)
        {
            double average = 0;
            int count = 0;
            for(int i = 0; i < student.materials.Length; i++)
            {
                average = average + CalculateTheAverageGradesForOneMaterial(student.materials[i]);
                count++;
            }
            return average/count;
        }



        public double CalculateTheAverageGradesForOneMaterial(Material materials)
        {
            double average = 0;
            int count = 0;
            for (int i = 0; i < materials.grade.Length; i++)
            {
                average = average + materials.grade[i];
                count++;
            }
            return average / count;
        }



        public Student[] SortAlphabetically(Student[] students)
        {
            for (int i = 0; i < students.Length; i++)
            {  
                for (int j = i + 1; j < students.Length; j++)
                {
                    if (String.Compare(students[i].studentName, students[j].studentName) > 0)
                        Change(ref students[i], ref students[j]);
                    else
                        continue;
                }
            }
            return students;
        }


        public void Change (ref Student firstName, ref Student secondName)
        {
            var temp = firstName;
            firstName = secondName;
            secondName = temp;
        }



        public void Change(ref string firstName, ref string secondName)
        {
            var temp = firstName;
            firstName = secondName;
            secondName = temp;
        }


        public struct Material
        {
            public string materialName;
            public int[] grade;
            public Material (string materialName, int[] grade)
            {
                this.materialName = materialName;
                this.grade = grade;
            }
        }



        public struct Student
        {
            public string studentName;
            public Material[] materials;
            public Student (string studentName, Material[] materials)
            {
                this.studentName = studentName;
                this.materials = materials;
            }
        }


        public struct StudentAndAverageGrade
        {
            public string studentName;
            public double averageGrade;
            public StudentAndAverageGrade(string studentName, double averageGrade)
            {
                this.studentName = studentName;
                this.averageGrade = averageGrade;
            }
        }



        public struct StudentAndNoOfTen
        {
            public string studentName;
            public double noOfTens;
            public StudentAndNoOfTen(string studentName, double noOfTens)
            {
                this.studentName = studentName;
                this.noOfTens = noOfTens;
            }
        }
    }
}
