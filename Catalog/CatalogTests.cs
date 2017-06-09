using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog
{
    [TestClass]
    public class CatalogTests
    {

        [TestMethod]
        public void ShouldOrderStudentsAlphabetically()
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

            var result = new string[] {"Alin", "Paul", "Raul", "Zoro" };
            var function = SortAlphabetically(students);
            Assert.AreEqual(result[0], function[0].studentName);
            Assert.AreEqual(result[3], function[3].studentName);
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
        }


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

            var result = new StudentAndAverageGrade[]
            {
                new StudentAndAverageGrade("Alin", 8),
                new StudentAndAverageGrade("Paul", 7),
                new StudentAndAverageGrade("Raul", 6),
                new StudentAndAverageGrade("Zoro", 6)
            };
            var function = SortStudentsbyAverageGrade(students);
            CollectionAssert.AreEqual(result, function);
            var function2 = FindStudentsWithLowestAverageGrade(students);
            CollectionAssert.AreEqual(new StudentAndAverageGrade[] {
                new StudentAndAverageGrade("Raul", 6), new StudentAndAverageGrade("Zoro", 6) }, function2);
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



    }
}
